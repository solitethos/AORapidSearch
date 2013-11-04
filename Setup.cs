/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 7:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Windows.Forms;

namespace AORapidSearch
{
	/// <summary>
	/// Description of Setup.
	/// </summary>
	public class Setup
	{
		public Setup()
		{
			string aoitemspath;
			string iconspath;
			
			MessageBox.Show("Please locate aoitems.db (from either your AOIA or AOSKills installation folder)...");
			OpenFileDialog ofd = new OpenFileDialog();
			//ofd.Description = "Please locate aoitems.db...";
			ofd.Filter = "db files (*.db)|*.db";
			if(ofd.ShowDialog() == DialogResult.OK) {
				aoitemspath = ofd.FileName;
				// Save to config file
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				config.AppSettings.Settings["aoitemspath"].Value = aoitemspath;
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
			}
			else {
				MessageBox.Show("Error picking file");
			}
				
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.Description = "Please locate your icons folder...";
			if(fbd.ShowDialog() == DialogResult.OK) {
				iconspath = fbd.SelectedPath;
				// Save to config file
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				config.AppSettings.Settings["iconspath"].Value = iconspath;
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("appSettings");
			}
			else {
				MessageBox.Show("Error picking directory");
			}	
		}
	}
}
