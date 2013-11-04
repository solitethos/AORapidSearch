/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/19/2013
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace AORapidSearch
{
	/// <summary>
	/// Description of UpdateDatabase.
	/// </summary>
	public partial class UpdateDatabase : Form
	{
		string eipath = "";
		
		public UpdateDatabase()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			//ofd.Description = "Please locate aoitems.db...";
			ofd.Filter = "db files (*.db)|*.db";
			if(ofd.ShowDialog() == DialogResult.OK) {
				try {
					System.IO.File.Copy(ofd.FileName,@"aoitems.db",true);
					MessageBox.Show("Copy successful. Move on to Step 2!");
				}
				catch(Exception fail) { MessageBox.Show(fail.ToString()); }			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			try {
				string iconspath = String.Format("{0}\\icons",Directory.GetCurrentDirectory());
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Title = "Please locate ExtractIcons.exe from your AOSkills installation.";
				ofd.Filter = "exe files (*.exe)|*.exe";
				if(ofd.ShowDialog() == DialogResult.OK) {
					eipath=ofd.FileName;	
				}
				
				if (!Directory.Exists(iconspath)) 
	            {
	                Directory.CreateDirectory(iconspath);
	            }
				Clipboard.SetText(iconspath);
				MessageBox.Show(String.Format("The correct directory for Icon Dest. has been copied to the clipboard. Simply Paste (CTRL-V) in that box set it correctly.\nThe directory is: {0}",iconspath));
				BackgroundWorker loader = new BackgroundWorker();
				loader.DoWork += new DoWorkEventHandler(extractIcons);
				loader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(finExtractIcons);
				button1.Enabled=false;
				button2.Enabled=false;
				button3.Enabled=false;
				loader.RunWorkerAsync();
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		private void extractIcons(System.Object sender, System.EventArgs e) {
			if(String.IsNullOrEmpty(eipath)) return;
			try {
				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = eipath;
				psi.UseShellExecute = false;
				Process process = new Process();
		        process.StartInfo = psi;
		        process.Start();
			}
			catch(Exception fail) {
				MessageBox.Show(String.Format("{0} --- {1}",Directory.GetCurrentDirectory(),fail.ToString()));
			}
				
		}
		
		private void finExtractIcons(System.Object sender, System.EventArgs e) {
			button1.Enabled=true;
			button2.Enabled=true;
			button3.Enabled=true;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			SQL.SQLtoXML stx = new SQL.SQLtoXML();
			this.Hide();
			stx.Show();
		}
		
	}
}
