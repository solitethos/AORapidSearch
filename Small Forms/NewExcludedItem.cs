/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/18/2013
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AORapidSearch.Small_Forms
{
	/// <summary>
	/// Description of NewExcludedItem.
	/// </summary>
	public partial class NewExcludedItem : Form
	{
		ExcludedItems exc;
		
		public NewExcludedItem(ExcludedItems ex)
		{
			exc=ex;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void AddClick(object sender, EventArgs e)
		{
			exc.addExcludedItem(numericUpDown1.Value.ToString(),true);
			exc.eForm.refreshList();
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
