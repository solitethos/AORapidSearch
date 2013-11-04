/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 9:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AORapidSearch.Small_Forms
{
	partial class ExcludedItemsForm
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
			this.itemsList = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// itemsList
			// 
			this.itemsList.FormattingEnabled = true;
			this.itemsList.Location = new System.Drawing.Point(13, 13);
			this.itemsList.Name = "itemsList";
			this.itemsList.Size = new System.Drawing.Size(279, 238);
			this.itemsList.Sorted = true;
			this.itemsList.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(298, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(66, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(298, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(66, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Remove";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(298, 70);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(66, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Import";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(298, 227);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(66, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "Close";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// ExcludedItemsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 262);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.itemsList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "ExcludedItemsForm";
			this.Text = "ExcludedItems";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox itemsList;
	}
}
