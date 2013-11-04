/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/19/2013
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AORapidSearch
{
	partial class UpdateDatabase
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDatabase));
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Step 1: Locate aoitems.db:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(205, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Find aoitems.db";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(187, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Step 2: Locate and Run ExtractIcons";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(205, 33);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(98, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "ExtractIcons";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(187, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Step 3: Parse DB (several minutes)";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(205, 62);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(98, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Parse Database";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// UpdateDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 89);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "UpdateDatabase";
			this.Text = "UpdateDatabase";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}
