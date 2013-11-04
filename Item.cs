/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/17/2013
 * Time: 10:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AORapidSearch
{
	/// <summary>
	/// Description of Item.
	/// </summary>
	public class Item : IComparable
	{
		public int aoid;
		public string name;
		public int ql;
		public string type;
		public int icon;
		public int slots;
		public List<Effect> effects;
		public List<Requirement> requirements;
		public int searchSkill;
		
		public Item() {
			effects = new List<Effect>();
			requirements = new List<Requirement>(); 
		}
		
		public Item(int id, string n, int q, string t, int i, int s) {
			aoid=id; name=n; ql=q; type=t; icon=i; slots=s;
			effects = new List<Effect>();
			requirements = new List<Requirement>(); 
		}
		
		public void addEffect(Effect e) {
			effects.Add(e);
		}
		
		public void addReq(Requirement r) {
			requirements.Add(r);
		}
		
		public int CompareTo(object obj) {
			int returnVal = 0;
			if (obj == null) return 1;
			Item other = obj as Item;
			if(other!=null) {
				Effect e1 = this.findEffect(searchSkill);
				Effect e2 = other.findEffect(searchSkill);
				if(e1.val<e2.val) {
					returnVal = 1;
				}
				else if(e1.val==e2.val) {
					returnVal = 0;
				}
				else if(e1.val>e2.val) {
					returnVal = -1;
				}
			} else { MessageBox.Show("Not a valid item"); return 0; }
			// Skill lock and npcostmod need to sort negatively
			if(searchSkill==382 || searchSkill==318) returnVal = -returnVal;
			return returnVal;
		}
		
		public Effect findEffect(int id) {
			foreach(Effect e in effects) {
				if(e.skill==id) return e;
			}
			MessageBox.Show("Effect not found.");
			return null;
		}
		
		public bool slotTest(int s, string w) {
			bool yay = (slots & s)==s;
			if(!yay) return false;
			if(w.Equals(type)) return true;
			if(w.Equals("Implant") && type.Equals("Spirit")) return true;
			return false;
		}
		
		public int getVal() {
			return Normalize(findEffect(searchSkill).val);
		}
		
		public int Normalize(Int64 val) {
			while(val>Int32.MaxValue) {
				val-=Int32.MaxValue;
			}
			while(val<Int32.MinValue) {
				val+=Int32.MinValue;
			}
			return Convert.ToInt32(val);
		}
	}
	
	public class Effect {
		public int skill;
		public long val;
		
		public Effect() {}
		
		public Effect(int s, long v) {
			skill=s; val = Normalize(v); // TODO find some elegant place to put the Normalize function
		}
		
		public int Normalize(Int64 v) {
			while(v>Int32.MaxValue) {
				v-=Int32.MaxValue;
			}
			while(val<Int32.MinValue) {
				v+=Int32.MinValue;
			}
			if(v>(Int32.MaxValue/2)) {
				
				v-=Int32.MaxValue;
				v-=2;
			}
			return Convert.ToInt32(v);
		}
	}
	
	public class Requirement {
		public int name;
		public int op;
		public long val;
		public int op_mod;
		public int sequence;
		
		public Requirement() {}
		
		public Requirement(int n, int o, long v, int om, int s) {
			name=n; op=o; val=v; op_mod=om; sequence=s;
		}
	}
}
