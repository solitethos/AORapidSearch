/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AORapidSearch
{
	partial class GUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.professionCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.factionCombo = new System.Windows.Forms.ComboBox();
			this.slYesNo = new System.Windows.Forms.CheckBox();
			this.otherExpYesNo = new System.Windows.Forms.CheckBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.skillsList = new System.Windows.Forms.ListBox();
			this.statusWindow = new System.Windows.Forms.TextBox();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.updateDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.excludedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exludedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customSkillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.level = new System.Windows.Forms.NumericUpDown();
			this.breedComboBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.level)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(183, 291);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(189, 27);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(183, 291);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(378, 27);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(183, 291);
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			// 
			// professionCombo
			// 
			this.professionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.professionCombo.FormattingEnabled = true;
			this.professionCombo.Items.AddRange(new object[] {
									"Adventurer",
									"Agent",
									"Bureaucrat",
									"Doctor",
									"Enforcer",
									"Engineer",
									"Fixer",
									"Keeper",
									"Martial Artist",
									"Metaphysicist",
									"Nanotechnician",
									"Shade",
									"Soldier",
									"Trader"});
			this.professionCombo.Location = new System.Drawing.Point(661, 54);
			this.professionCombo.Name = "professionCombo";
			this.professionCombo.Size = new System.Drawing.Size(135, 21);
			this.professionCombo.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(570, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Breed";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(570, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Profession";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(570, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Faction";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(570, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Level";
			// 
			// factionCombo
			// 
			this.factionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.factionCombo.FormattingEnabled = true;
			this.factionCombo.Items.AddRange(new object[] {
									"Clan",
									"Neutral",
									"Omni-Tek"});
			this.factionCombo.Location = new System.Drawing.Point(661, 81);
			this.factionCombo.Name = "factionCombo";
			this.factionCombo.Size = new System.Drawing.Size(135, 21);
			this.factionCombo.TabIndex = 13;
			// 
			// slYesNo
			// 
			this.slYesNo.Checked = true;
			this.slYesNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.slYesNo.Location = new System.Drawing.Point(709, 108);
			this.slYesNo.Name = "slYesNo";
			this.slYesNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.slYesNo.Size = new System.Drawing.Size(90, 24);
			this.slYesNo.TabIndex = 14;
			this.slYesNo.Text = "Shadowlands";
			this.slYesNo.UseVisualStyleBackColor = true;
			this.slYesNo.CheckedChanged += new System.EventHandler(this.SlYesNoCheckedChanged);
			// 
			// otherExpYesNo
			// 
			this.otherExpYesNo.Checked = true;
			this.otherExpYesNo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.otherExpYesNo.Location = new System.Drawing.Point(696, 133);
			this.otherExpYesNo.Name = "otherExpYesNo";
			this.otherExpYesNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.otherExpYesNo.Size = new System.Drawing.Size(104, 24);
			this.otherExpYesNo.TabIndex = 15;
			this.otherExpYesNo.Text = "AI/LE/LoX";
			this.otherExpYesNo.UseVisualStyleBackColor = true;
			this.otherExpYesNo.CheckedChanged += new System.EventHandler(this.OtherExpYesNoCheckedChanged);
			// 
			// searchButton
			// 
			this.searchButton.Enabled = false;
			this.searchButton.Location = new System.Drawing.Point(570, 134);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(145, 23);
			this.searchButton.TabIndex = 16;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.SearchButtonClick);
			// 
			// skillsList
			// 
			this.skillsList.FormattingEnabled = true;
			this.skillsList.Location = new System.Drawing.Point(570, 164);
			this.skillsList.Name = "skillsList";
			this.skillsList.Size = new System.Drawing.Size(230, 173);
			this.skillsList.Sorted = true;
			this.skillsList.TabIndex = 17;
			// 
			// statusWindow
			// 
			this.statusWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusWindow.Location = new System.Drawing.Point(0, 323);
			this.statusWindow.Name = "statusWindow";
			this.statusWindow.ReadOnly = true;
			this.statusWindow.Size = new System.Drawing.Size(561, 22);
			this.statusWindow.TabIndex = 18;
			this.statusWindow.Text = "Loading items...";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.updateDBToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem1.Text = "File";
			// 
			// updateDBToolStripMenuItem
			// 
			this.updateDBToolStripMenuItem.Name = "updateDBToolStripMenuItem";
			this.updateDBToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.updateDBToolStripMenuItem.Text = "Update DB...";
			this.updateDBToolStripMenuItem.Click += new System.EventHandler(this.UpdateDBToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1,
									this.optionsToolStripMenuItem,
									this.excludedItemsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(814, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// excludedItemsToolStripMenuItem
			// 
			this.excludedItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.exludedItemsToolStripMenuItem,
									this.customSkillsToolStripMenuItem});
			this.excludedItemsToolStripMenuItem.Name = "excludedItemsToolStripMenuItem";
			this.excludedItemsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
			this.excludedItemsToolStripMenuItem.Text = "Advanced";
			// 
			// exludedItemsToolStripMenuItem
			// 
			this.exludedItemsToolStripMenuItem.Name = "exludedItemsToolStripMenuItem";
			this.exludedItemsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.exludedItemsToolStripMenuItem.Text = "Excluded Items";
			this.exludedItemsToolStripMenuItem.Click += new System.EventHandler(this.ExludedItemsToolStripMenuItemClick);
			// 
			// customSkillsToolStripMenuItem
			// 
			this.customSkillsToolStripMenuItem.Name = "customSkillsToolStripMenuItem";
			this.customSkillsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.customSkillsToolStripMenuItem.Text = "Custom Skills";
			this.customSkillsToolStripMenuItem.Click += new System.EventHandler(this.CustomSkillsToolStripMenuItemClick);
			// 
			// level
			// 
			this.level.Location = new System.Drawing.Point(661, 109);
			this.level.Maximum = new decimal(new int[] {
									220,
									0,
									0,
									0});
			this.level.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.level.Name = "level";
			this.level.Size = new System.Drawing.Size(48, 20);
			this.level.TabIndex = 19;
			this.level.Value = new decimal(new int[] {
									220,
									0,
									0,
									0});
			// 
			// breedComboBox
			// 
			this.breedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.breedComboBox.FormattingEnabled = true;
			this.breedComboBox.Items.AddRange(new object[] {
									"Atrox",
									"Nanomage",
									"Opifex",
									"Solitus"});
			this.breedComboBox.Location = new System.Drawing.Point(661, 28);
			this.breedComboBox.Name = "breedComboBox";
			this.breedComboBox.Size = new System.Drawing.Size(135, 21);
			this.breedComboBox.TabIndex = 20;
			// 
			// GUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 353);
			this.Controls.Add(this.breedComboBox);
			this.Controls.Add(this.level);
			this.Controls.Add(this.statusWindow);
			this.Controls.Add(this.skillsList);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.otherExpYesNo);
			this.Controls.Add(this.slYesNo);
			this.Controls.Add(this.factionCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.professionCombo);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "GUI";
			this.Text = "AORapidSearch";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.level)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox breedComboBox;
		private System.Windows.Forms.ToolStripMenuItem customSkillsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exludedItemsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem excludedItemsToolStripMenuItem;
		private System.Windows.Forms.NumericUpDown level;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateDBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ListBox skillsList;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.CheckBox otherExpYesNo;
		private System.Windows.Forms.CheckBox slYesNo;
		private System.Windows.Forms.ComboBox factionCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox professionCombo;
		private System.Windows.Forms.TextBox statusWindow;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		
		void SearchButtonClick(object sender, System.EventArgs e)
		{
			this.search();
		}
	}
}
