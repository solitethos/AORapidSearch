/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/19/2013
 * Time: 9:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AORapidSearch.Small_Forms
{
	/// <summary>
	/// Description of ListofItems.
	/// </summary>
	public partial class ListofItems : Form
	{
		public ListofItems(List<Item> list)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			List<int> itemList = new List<int>();
			foreach(Item i in list) {
				itemList.Add(i.aoid);
			}
			listBox1.DataSource=itemList;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
