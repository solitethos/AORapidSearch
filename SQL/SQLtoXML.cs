/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/20/2013
 * Time: 2:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AORapidSearch.SQL
{
	/// <summary>
	/// Description of SQLtoXML.
	/// </summary>
	public partial class SQLtoXML : Form
	{
		AODB db;
		DataTable items;
		DataTable effects;
		DataTable reqs;
		BackgroundWorker loader;
		BackgroundWorker converter;
		List<XmlItem> xmlItems;
		//List<XmlEffect> xmlEffects;
		//List<XmlRequirement> xmlRequirements;
		//ExcludedItems ex; // Decided against this - user would have to reload XML after every item added at runtime
		
		public SQLtoXML()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			DataSet ds = new DataSet();
			ds.EnforceConstraints = false;
			items = new DataTable(); ds.Tables.Add(items);
			effects = new DataTable(); ds.Tables.Add(effects);
			reqs = new DataTable(); ds.Tables.Add(reqs);
			
			try {
				db = new AODB();
				//numItems = Convert.ToInt32(db.ExecuteScalar("SELECT COUNT(aoid) FROM tblAO WHERE (tblAO.type='Armor' or tblAO.type='Weapon' or tblAO.type='Implant' or tblAO.type='Spirit');"));
				loader = new BackgroundWorker();
				loader.DoWork += new DoWorkEventHandler(querySQL);
				loader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(finishedQuerySQL);
				loader.ProgressChanged += new ProgressChangedEventHandler(progress);
				loader.WorkerReportsProgress = true;
				loader.RunWorkerAsync();
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		public void querySQL(System.Object sender, System.EventArgs e) {
			// 10/20/2013 - Items: 82913 Effects: 416025 Reqs: 283641			Total 782579 entries
			label1.Text = "Loading SQL...";
			items = db.Query("SELECT * from tblAO WHERE (tblAO.type='Armor' or tblAO.type='Weapon' or tblAO.type='Implant' or tblAO.type='Spirit');");
			loader.ReportProgress(11); // 82913/782579 = 10.5		
			//effects = db.Query("SELECT * from tblItemEffects;");
			loader.ReportProgress(64); // 498938/782579 = 63.7
			//reqs = db.Query("SELECT * from tblItemReqs;");
			loader.ReportProgress(100);
			label1.Update();
			//loader.ReportProgress(50);
		}
		
		public void finishedQuerySQL(System.Object sender, System.EventArgs e) {
			try {
				converter = new BackgroundWorker();
				converter.DoWork += convert;
				converter.RunWorkerCompleted += new RunWorkerCompletedEventHandler(finishedConverter);
				converter.ProgressChanged += new ProgressChangedEventHandler(xprogress);
				converter.WorkerReportsProgress = true;
				converter.RunWorkerAsync();
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		public void progress(System.Object sender, ProgressChangedEventArgs e) {
			progressBar1.Value = e.ProgressPercentage;
		}
		
		public void convert(System.Object sender, System.EventArgs e) {
			//progressBar1.Value = 0;
			//label1.Text = "Creating XML...";
			XmlItem i;
			try {
				xmlItems = new List<XmlItem>();
				foreach(DataRow dr in items.Rows) {
					int aoid = Convert.ToInt32(dr["aoid"]);
					int ql = Convert.ToInt32(dr["ql"]);
					string name = dr["name"].ToString();
					string type = dr["type"].ToString();
					int icon = Convert.ToInt32(dr["icon"]);
					int islot = Convert.ToInt32(dr["islot"]);
					i = new XmlItem(aoid,name,ql,type,icon,islot);
					// Hook=14 is PerformOnWear, Type=53 is skills as opposed to textures, etc
					effects = db.Query(String.Format("SELECT value1,value2 FROM tblItemEffects WHERE aoid={0} AND hook=14 AND type=53;",aoid));
					List<XmlEffect> tmpEffects = new List<XmlEffect>();
					foreach(DataRow de in effects.Rows) {
						int skill = Convert.ToInt32(de["value1"]);
						long val = Convert.ToInt64(de["value2"]);
						XmlEffect xe = new XmlEffect(skill,val);
						tmpEffects.Add(xe);
					}
					i.addEffects(tmpEffects);
					// Type6 is ToWear, Type8 ToWield
					reqs = db.Query(String.Format("SELECT sequence, attribute, value, operator, op_modifier FROM tblItemReqs WHERE aoid={0} AND (type=6 OR type=8)",aoid));
					List<XmlRequirement> tmpReqs = new List<XmlRequirement>();
					foreach(DataRow dq in reqs.Rows) {
						int sequence = Convert.ToInt32(dq["sequence"]);
						int attribute = Convert.ToInt32(dq["attribute"]);
						long val = Convert.ToInt64(dq["value"]);
						int op = Convert.ToInt32(dq["operator"]);
						int op_mod = Convert.ToInt32(dq["op_modifier"]);
						XmlRequirement xr = new XmlRequirement(attribute,op,val,op_mod,sequence);
						tmpReqs.Add(xr);
					}
					i.addReqs(tmpReqs);
					xmlItems.Add(i);
					converter.ReportProgress(xmlItems.Count / items.Rows.Count);
				}
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		public void xprogress(System.Object sender, ProgressChangedEventArgs e) {
			float percent = Convert.ToSingle(xmlItems.Count)/Convert.ToSingle(items.Rows.Count);
			label1.Text = String.Format("Item {0}/{1}, {2:P2} Completed",xmlItems.Count,items.Rows.Count, percent);
			progressBar1.Value = Convert.ToInt32(percent*100);
		}
		
		public void finishedConverter(System.Object sender, RunWorkerCompletedEventArgs e) {
			if (e.Error != null) { MessageBox.Show(e.Error.Message); }
			serialize();
		}
		
		public void serialize() {
			try {
				XmlSerializer serializer = new XmlSerializer(typeof(XmlItem[]));
				TextWriter writer = new StreamWriter(@"aodb.xml");
				serializer.Serialize(writer, xmlItems.ToArray());
	      		writer.Close();
				MessageBox.Show("All done!");
				this.Close();
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
			
		}
	}
	
	public class XmlItem {
		public int aoid;
		public string name;
		public int ql;
		public string type;
		public int icon;
		public int slots;
		public XmlEffect[] effects;
		public XmlRequirement[] requirements;
		
		public XmlItem() {
			effects = new XmlEffect[86]; // # of effects on Blackmane's stat buffer
			requirements = new XmlRequirement[30]; // HACK madeup number
		}
		
		public XmlItem(int id, string n, int q, string t, int i, int s) {
			aoid=id; name=n; ql=q; type=t; icon=i; slots=s;
			effects = new XmlEffect[86]; // # of effects on Blackmane's stat buffer
			requirements = new XmlRequirement[30]; // HACK madeup number
		}
		
		public void addEffects(List<XmlEffect> lxe) {
			effects = lxe.ToArray();
		}
		
		public void addReqs(List<XmlRequirement> lxr) {
			requirements = lxr.ToArray();
		}
	}
	
	public class XmlEffect {
		public int skill;
		public long val;
		
		public XmlEffect() {}
		
		public XmlEffect(int s, long v) {
			skill=s; val = v;
		}
	}
	
	public class XmlRequirement {
		public int name;
		public int op;
		public long val;
		public int op_mod;
		public int sequence;
		
		public XmlRequirement() {}
		
		public XmlRequirement(int n, int o, long v, int om, int s) {
			name=n; op=o; val=v; op_mod=om; sequence=s;
		}
	}
}
