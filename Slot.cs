/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/23/2013
 * Time: 1:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace AORapidSearch
{
	/// <summary>
	/// Description of Slot.
	/// </summary>
	public class Slot : System.Windows.Forms.PictureBox
	{
		public int id; public string window;
		//string search;
		// img?
		// popup?
		List<Item> items;
		int sItem;
		bool selected;
		GUI gui;
		ContextMenu cmenu;
		bool menuVisible;
		// default icon: 288332 (lol)
		
		public Slot(int x, int y, int i, string w, GUI g, PictureBox p)
		{
			Location = new Point(x,y);
			id=i; window=w; gui=g; Parent = p;
			clearItems();
			Size = new Size(48,48);
			this.BackColor = Color.Transparent;
			cmenu = new ContextMenu();
			this.ContextMenu = cmenu;
			sItem=0;
			this.DoubleClick += new EventHandler(slotClick);			
			selected=false;
			menuVisible=false;
		}
		
		public void changeIcon(int id) {
			if(id<=0) id=270365;
			try {
				Bitmap bm = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				Graphics g = Graphics.FromImage(bm);
				g.Clear(Color.Transparent);
				g.DrawImage(Image.FromFile(String.Format(@"icons/{0}.png",id)),0,0);
				g.Dispose();
				bm.MakeTransparent(Color.FromArgb(0, 255, 0));
				Image = bm;
				SizeMode = PictureBoxSizeMode.StretchImage;
				BringToFront();
				Show();
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		public void process() {
			int max = items.Count;
			if(Convert.ToBoolean(ConfigurationManager.AppSettings["itemLimit"])) {
				max = Convert.ToInt32(ConfigurationManager.AppSettings["itemNum"]);
			}
			int count = Math.Min(max,items.Count);
			MenuItem[] mi = new MenuItem[count];
			int index = 0;
			items.Sort();
			foreach(Item i in items) {
				string n = String.Format("{0} - QL{1} {2}",i.getVal(),i.ql,i.name);
				mi[index] = new MenuItem(n, MenuItem_Click);
				//MenuItem m = new MenuItem("",eventHandlerOnClick);
				index++;
				if(index>=count) break;
			}
			cmenu = new ContextMenu(mi);
			this.ContextMenu = cmenu;
			if(items.Count>0) setItem(0);
			cmenu.Popup += new EventHandler(openCMenu);
			cmenu.Collapse += new EventHandler(closeCMenu);
		}
		
		private void MenuItem_Click(object sender, EventArgs e) {
			MenuItem mi = sender as MenuItem;
			setItem(mi.Index);
		}
		
		private void openCMenu(object sender, EventArgs e) {
			menuVisible=true;
		}
		
		private void closeCMenu(object sender, EventArgs e) {
			menuVisible=false;
		}
		
		private void slotClick(object sender, EventArgs e) {
			if(!selected) return;
			if(menuVisible) return;
			if(items.Count<=0) return;
        	string url = "";
        	if(Convert.ToBoolean(ConfigurationManager.AppSettings["isDBPreset"])) {
        		string snum = ConfigurationManager.AppSettings["presetDB"];
        		int num;
        		int.TryParse(snum,out num);
        		switch(num) {
        			case 0: url = String.Format("https://aoitems.com/item/{0}/",items[sItem].aoid); break;
        			case 1: url = String.Format("http://aodb.us/item.php?id={0}",items[sItem].aoid); break;
        			case 2: url = String.Format("http://auno.org/ao/db.php?id={0}",items[sItem].aoid); break;
        			case 3: url = String.Format("http://www.xyphos.com/ao/aodb.php?id={0}",items[sItem].aoid); break;
        			default: return;
        		}
        	}
        	else {
        		url = String.Format("{0}{1}",ConfigurationManager.AppSettings["customDB"].ToString(),items[sItem].aoid);
        	}
        	if(!String.IsNullOrEmpty(url)) {
        		try {
        			System.Diagnostics.Process.Start(url);
        		}
        		catch(Exception fail) { MessageBox.Show(fail.ToString()); }
        	}		
		}
		
		public void addItem(Item i) {
			if(items.Contains(i)) return;
			if(i.type.Equals("Implant") && ConfigurationManager.AppSettings["simpleImp"].ToString().Equals("true")) {
				foreach(Item j in items) {
					if(i.name.Contains("Refined") && j.name.Contains("Refined")) return;
					if(i.name.Contains("Implant") && !i.name.Contains("Refined") 
					   && j.name.Contains("Implant") && !j.name.Contains("Refined")) return;
				}
			}
			items.Add(i);
		}
		
		public void clearItems() {
			items = new List<Item>();
			cmenu = null;
			Image = null;
		}
		
		public void setItem(int i) {
			if(i>items.Count) return;
			selected=true;
			sItem=i;
			changeIcon(items[i].icon);
		}
	}
}
