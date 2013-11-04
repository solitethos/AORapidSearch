/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 2:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace AORapidSearch
{
	/// <summary>
	/// Description of Options().
	/// </summary>
	public partial class Options : Form
	{
		public Options()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			System.Windows.Forms.ToolTip loxToolTip = new System.Windows.Forms.ToolTip();
    		loxToolTip.SetToolTip(this.loxNCU, "Omits skill NCUs with less than six cells.");
			System.Windows.Forms.ToolTip impToolTip = new System.Windows.Forms.ToolTip();
    		impToolTip.SetToolTip(this.implants, "Displays only one regular (and one refined if applicable) implant per slot.");
    		
    		string s = getSetting("simpleLoX"); 
    		if(s.Equals("true")) {
    			loxNCU.Checked = true;
    		}
    		else loxNCU.Checked = false;
    		s = getSetting("simpleImp");
    		if(s.Equals("true")) {
    			implants.Checked = true;
    		}
    		else implants.Checked = false;
    		s = getSetting("itemLimit");
    		if(s.Equals("true")) {
    			itemLimit.Checked = true;
    			limitNum.Enabled = true;
    		}
    		else {
    			itemLimit.Checked = false;
    			limitNum.Enabled = false;
    		}
    		s = getSetting("itemNum");
    		int n = Convert.ToInt32(s);
    		if(n<1) n=1;
    		if(n>limitNum.Maximum) n=Convert.ToInt32(limitNum.Maximum);
    		limitNum.Value = n; 
    		s = getSetting("isDBPreset");
    		if(s.Equals("true")) {
    			presetDBSite.Checked = true;
    			try {
    				presetDBSites.SelectedIndex = Convert.ToInt32(getSetting("presetDB"));	
    			}
    			catch(Exception fail) { presetDBSites.SelectedIndex=0; Console.WriteLine(fail.ToString()); }
    			
    			presetDBSites.Enabled = true;
    			customDBUrl.Enabled = false;
    		}
    		else {
    			try {
    				customDBSite.Enabled = true;
    				presetDBSite.Checked = false;
    				customDBSite.Checked = true;
					customDBUrl.Enabled = true;
					presetDBSites.Enabled = true;	
    			}
    			catch(Exception fail) { customDBUrl.Text = fail.ToString(); }
    		}
    		customDBUrl.Text = getSetting("customDB");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ItemLimitCheckedChanged(object sender, EventArgs e)
		{
			if(itemLimit.Checked) {
				limitNum.Enabled = true;
				setSetting("itemLimit","true");
			}
			else {
				limitNum.Enabled = false;
				setSetting("itemLimit","false");
			}
		}
		
		void CustomDBSiteCheckedChanged(object sender, EventArgs e)
		{
			if(customDBSite.Checked) {
				customDBUrl.Enabled = true;
				presetDBSites.Enabled = false;
				setSetting("isDBPreset","false");
			}
			else {
				customDBUrl.Enabled = false;
				presetDBSites.Enabled = true;
				setSetting("isDBPreset","true");
			}
		}
		
		string getSetting(string name) {
			if(String.IsNullOrEmpty(ConfigurationManager.AppSettings[name])) {
				return "";
			}
			else {
				return ConfigurationManager.AppSettings[name];
			}
		}
		
		void setSetting(string name, string val) {
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			config.AppSettings.Settings[name].Value = val;
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}
		
		void CustomDBUrlTextChanged(object sender, EventArgs e)
		{
			setSetting("customDB",customDBUrl.Text);
		}
		
		void ImplantsCheckedChanged(object sender, EventArgs e)
		{
			if(implants.Checked) {
				setSetting("simpleImp","true");
			}
			else {
				setSetting("simpleImp","false");
			}
		}
		
		void PresetDBSiteCheckedChanged(object sender, EventArgs e)
		{
			if(customDBSite.Checked) {
				customDBUrl.Enabled = true;
				presetDBSites.Enabled = false;
				setSetting("isDBPreset","false");
				setSetting("customDB",customDBUrl.Text);
			}
			else {
				customDBUrl.Enabled = false;
				presetDBSites.Enabled = true;
				setSetting("isDBPreset","true");
				setSetting("presetDB",presetDBSites.SelectedIndex.ToString());
			}
		}
		
		void PresetDBSitesSelectedIndexChanged(object sender, EventArgs e)
		{
			setSetting("presetDB",presetDBSites.SelectedIndex.ToString());
		}
		
		void LimitNumValueChanged(object sender, EventArgs e)
		{
			setSetting("itemNum",limitNum.Value.ToString());
		}
		
		void LoxNCUCheckedChanged(object sender, EventArgs e)
		{
			if(loxNCU.Checked) {
				setSetting("simpleLoX","true");
			}
			else {
				setSetting("simpleLoX","false");
			}
		}
	}
}

  /*
   *
	<add key="simpleLoX" value="true"/>
	<add key="simpleImp" value="true"/>
	<add key="itemLimit" value="true"/>
	<add key="itemNum" value="20"/>
	<add key="isDBPreset" value="true"/>
	<add key="presetDB" value="aoitems.com"/>
	<add key="customDB" value=""/>
   */