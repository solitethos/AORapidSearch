/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 2:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AORapidSearch
{
	partial class Options
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
			this.button1 = new System.Windows.Forms.Button();
			this.loxNCU = new System.Windows.Forms.CheckBox();
			this.implants = new System.Windows.Forms.CheckBox();
			this.itemLimit = new System.Windows.Forms.CheckBox();
			this.limitNum = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.presetDBSite = new System.Windows.Forms.RadioButton();
			this.presetDBSites = new System.Windows.Forms.ComboBox();
			this.customDBSite = new System.Windows.Forms.RadioButton();
			this.customDBUrl = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.limitNum)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(197, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// loxNCU
			// 
			this.loxNCU.Checked = true;
			this.loxNCU.CheckState = System.Windows.Forms.CheckState.Checked;
			this.loxNCU.Location = new System.Drawing.Point(13, 13);
			this.loxNCU.Name = "loxNCU";
			this.loxNCU.Size = new System.Drawing.Size(113, 24);
			this.loxNCU.TabIndex = 1;
			this.loxNCU.Text = "Simple LoX NCUs";
			this.loxNCU.UseVisualStyleBackColor = true;
			this.loxNCU.CheckedChanged += new System.EventHandler(this.LoxNCUCheckedChanged);
			// 
			// implants
			// 
			this.implants.Checked = true;
			this.implants.CheckState = System.Windows.Forms.CheckState.Checked;
			this.implants.Location = new System.Drawing.Point(13, 44);
			this.implants.Name = "implants";
			this.implants.Size = new System.Drawing.Size(104, 24);
			this.implants.TabIndex = 2;
			this.implants.Text = "Simple Implants";
			this.implants.UseVisualStyleBackColor = true;
			this.implants.CheckedChanged += new System.EventHandler(this.ImplantsCheckedChanged);
			// 
			// itemLimit
			// 
			this.itemLimit.Checked = true;
			this.itemLimit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.itemLimit.Location = new System.Drawing.Point(13, 75);
			this.itemLimit.Name = "itemLimit";
			this.itemLimit.Size = new System.Drawing.Size(113, 24);
			this.itemLimit.TabIndex = 3;
			this.itemLimit.Text = "Limit items per slot";
			this.itemLimit.UseVisualStyleBackColor = true;
			this.itemLimit.CheckedChanged += new System.EventHandler(this.ItemLimitCheckedChanged);
			// 
			// limitNum
			// 
			this.limitNum.Location = new System.Drawing.Point(50, 103);
			this.limitNum.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.limitNum.Name = "limitNum";
			this.limitNum.Size = new System.Drawing.Size(54, 20);
			this.limitNum.TabIndex = 4;
			this.limitNum.Value = new decimal(new int[] {
									20,
									0,
									0,
									0});
			this.limitNum.ValueChanged += new System.EventHandler(this.LimitNumValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Limit:";
			// 
			// presetDBSite
			// 
			this.presetDBSite.Checked = true;
			this.presetDBSite.Location = new System.Drawing.Point(132, 12);
			this.presetDBSite.Name = "presetDBSite";
			this.presetDBSite.Size = new System.Drawing.Size(104, 24);
			this.presetDBSite.TabIndex = 6;
			this.presetDBSite.TabStop = true;
			this.presetDBSite.Text = "Preset DB Site";
			this.presetDBSite.UseVisualStyleBackColor = true;
			this.presetDBSite.CheckedChanged += new System.EventHandler(this.PresetDBSiteCheckedChanged);
			// 
			// presetDBSites
			// 
			this.presetDBSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.presetDBSites.FormattingEnabled = true;
			this.presetDBSites.Items.AddRange(new object[] {
									"aoitems.com",
									"aodb.us",
									"auno.org",
									"xyphos.com"});
			this.presetDBSites.Location = new System.Drawing.Point(132, 43);
			this.presetDBSites.Name = "presetDBSites";
			this.presetDBSites.Size = new System.Drawing.Size(121, 21);
			this.presetDBSites.TabIndex = 7;
			this.presetDBSites.SelectedIndexChanged += new System.EventHandler(this.PresetDBSitesSelectedIndexChanged);
			// 
			// customDBSite
			// 
			this.customDBSite.Location = new System.Drawing.Point(132, 71);
			this.customDBSite.Name = "customDBSite";
			this.customDBSite.Size = new System.Drawing.Size(104, 24);
			this.customDBSite.TabIndex = 8;
			this.customDBSite.Text = "Custom DB Site";
			this.customDBSite.UseVisualStyleBackColor = true;
			this.customDBSite.CheckedChanged += new System.EventHandler(this.CustomDBSiteCheckedChanged);
			// 
			// customDBUrl
			// 
			this.customDBUrl.Enabled = false;
			this.customDBUrl.Location = new System.Drawing.Point(133, 102);
			this.customDBUrl.Name = "customDBUrl";
			this.customDBUrl.Size = new System.Drawing.Size(120, 20);
			this.customDBUrl.TabIndex = 9;
			this.customDBUrl.TextChanged += new System.EventHandler(this.CustomDBUrlTextChanged);
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 158);
			this.Controls.Add(this.customDBUrl);
			this.Controls.Add(this.customDBSite);
			this.Controls.Add(this.presetDBSites);
			this.Controls.Add(this.presetDBSite);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.limitNum);
			this.Controls.Add(this.itemLimit);
			this.Controls.Add(this.implants);
			this.Controls.Add(this.loxNCU);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Options";
			this.Text = "Options";
			((System.ComponentModel.ISupportInitialize)(this.limitNum)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox customDBUrl;
		private System.Windows.Forms.RadioButton customDBSite;
		private System.Windows.Forms.ComboBox presetDBSites;
		private System.Windows.Forms.RadioButton presetDBSite;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown limitNum;
		private System.Windows.Forms.CheckBox itemLimit;
		private System.Windows.Forms.CheckBox implants;
		private System.Windows.Forms.CheckBox loxNCU;
		private System.Windows.Forms.Button button1;
	}
}
