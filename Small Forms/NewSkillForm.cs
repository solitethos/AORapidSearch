/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/17/2013
 * Time: 11:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace AORapidSearch.Small_Forms
{
	/// <summary>
	/// Description of NewSkillForm.
	/// </summary>
	public partial class NewSkillForm : Form
	{
		public NewSkillForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();	
		}
	
		
		void Button1Click(object sender, EventArgs e)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			config.AppSettings.Settings.Add(numericUpDown1.Value.ToString(),textBox1.Text);
			config.AppSettings.Settings[String.Format("{0}",numericUpDown1.Value)].Value = textBox1.Text;
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			this.Close();
		}
	}
}
