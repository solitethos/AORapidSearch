/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/17/2013
 * Time: 10:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AORapidSearch
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class ExcludedItems
	{
		public Small_Forms.ExcludedItemsForm eForm;
		public List<int> ids;
		
		public ExcludedItems()
		{
			loadFile();
		}
		
		public void addExcludedItem(string i, bool save) {
			if(String.IsNullOrEmpty(i)) return;
			try {
				int vn = Convert.ToInt32(i);
				ids.Add(vn);
				if(save) saveFile();
			}
			catch (System.FormatException fe) { System.Console.Write(fe.ToString()); }
		}
		
		public void removeExcludedItem(int i) {
			if(ids.Contains(i)) {
				ids.Remove(i);
				saveFile();
			}
		}
		
		public void loadFile() {
			try {
				String[] values = File.ReadAllText(@"ExcludedItems.csv").Split(',');
				ids = new List<int>();
				foreach(string v in values) {
					addExcludedItem(v,false);
				}
			}
			catch (Exception fail) {
				MessageBox.Show(String.Format("Failed to load ExcludedItems.csv. Error: {0}",fail.ToString()));
			}
		}
		
		public void saveFile() {
			try {
				string savestring ="";
				foreach(int id in ids) {
					savestring += String.Format("{0},",id);
				}
				System.IO.File.WriteAllLines(@"ExcludedItems.csv", new string[]{savestring});
			}
			catch (Exception fail) {
				MessageBox.Show(String.Format("Failed to save ExcludedItems.csv. Error: {0}",fail.ToString()));
			}
		}
		
		public void displayForm(DB db) {
			eForm = new Small_Forms.ExcludedItemsForm(this,db);
			eForm.Show();
		}
	}
}
