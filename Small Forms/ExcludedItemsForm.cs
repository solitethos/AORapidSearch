/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 9:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace AORapidSearch.Small_Forms
{
	/// <summary>
	/// Description of ExcludedItems.
	/// </summary>
	public partial class ExcludedItemsForm : Form
	{
		ExcludedItems ex;
		
		public ExcludedItemsForm(ExcludedItems e, DB db)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			ex = e;
			InitializeComponent();
			refreshList();	
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Comma Separated Files (.csv)|*.csv|Txt Files (.txt)|*.txt|All Files (*.*)|*.*";
			ofd.FilterIndex = 1;
			if(ofd.ShowDialog() == DialogResult.OK) {
				try {
					String[] values = File.ReadAllText(String.Format("{0}",ofd.FileName)).Split(',');
					
					// TODO: call the addExcludedItems method instead of duping the code
					foreach(string v in values) {
						if(!String.IsNullOrEmpty(v)) {
							int vn;
							try {
								vn = Convert.ToInt32(v);	
								if ((ex != null) && (ex.ids != null)) {
								}
								if(!ex.ids.Contains(vn)) ex.ids.Add(vn);
							}
							catch (System.FormatException fe) { System.Console.Write(fe.ToString()); }
						}
						
					}
					ex.saveFile();
					refreshList();
				}	
				catch (Exception fail) {
					MessageBox.Show(String.Format("Failed to load {0}. Error: {1}",ofd.FileName,fail.ToString()));
				}
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			Small_Forms.NewExcludedItem nex = new Small_Forms.NewExcludedItem(ex);
			nex.Show();
			refreshList();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			string[] temp = itemsList.SelectedItem.ToString().Split('-');
			int i = Convert.ToInt32(temp[0]);
			ex.removeExcludedItem(i);
			refreshList();
		}
		
		public void refreshList() {
			List<string> namesList = new List<string>();
			itemsList.DataSource = null;
			AODB aodb = new AODB();
			foreach(int v in ex.ids) {
				string name = aodb.ExecuteScalar(String.Format("SELECT name FROM tblAO WHERE aoid={0};",v));
				if(!String.IsNullOrEmpty(name)) {
					namesList.Add(String.Format("{0} - {1}",v,name));
				}
				else {
					namesList.Add(v.ToString());
				}
			}
			itemsList.DataSource = namesList.ToArray();
		}
	}
}
