/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/21/2013
 * Time: 11:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace AORapidSearch
{
	/// <summary>
	/// Description of DB.
	/// </summary>
	public class DB {
		
		public List<Item> items;
		ExcludedItems ex;
		
		public DB() {
			try {
				ex = new ExcludedItems();
				XmlSerializer xs = new XmlSerializer( typeof( XmlItem[] ), new XmlRootAttribute( "ArrayOfXmlItem" ) );
				using ( FileStream myFileStream = new FileStream( @"aodb.xml", FileMode.Open ) ) {
					XmlItem[] i;
					i = ( XmlItem[] ) xs.Deserialize( myFileStream );
					items = new List<Item>();
					foreach(XmlItem xi in i) {
						if(!ex.ids.Contains(xi.aoid) && xi.test()) items.Add(xi.toItem());
					}
				}
			}
			catch(Exception fail) { MessageBox.Show(fail.ToString()); }
		}
		
		public List<Item> search(int breed, int prof, int faction, int lvl, bool sl, bool otherexp, int skill) {
			// Might be slower to generate this list and then go through it again to determine slots, but the design is simpler
			// and the results list should be relatively short (a few hundred at most, unless the user searches for something crazy like ACs)
			// Question: which tests will eliminate more items first?
			// Probably the skill check should come first
			List<Item> results = new List<Item>();
			foreach(Item i in items) {
				foreach(Effect e in i.effects) {
					if(e.skill==skill) {
						if(sl) {
							if(!slCheck(i)) break;
						}
						if(otherexp) {
							if(!otherExpCheck(i)) break;
						}
						if(breedCheck(i,breed) && profCheck(i,prof) && factionCheck(i,faction) && levelCheck(i,lvl)) {
							results.Add(i); break;
						}
					}
				}
			}
			return results;
		}
		
		private bool breedCheck(Item i, int breed) {
			foreach(Requirement r in i.requirements) {
				// Breed=4
				// Ops: 0 is ==, 24 is !=
				if(r.name==4) {
					if(r.op==0) {
						if(breed!=r.name) return false;
					}
					else if(r.op==24) {
						if(breed==r.name) return false;
					}
				}
			}
			return true;
		}
		
		private bool profCheck(Item i, int prof) {
			// Prof=60; VisualProfession=368
			// No implants for shades
			if(i.type.Equals("Implant") && prof==15) return false;
			bool reqd = false;
			foreach(Requirement r in i.requirements) {
				if(r.name==60 || r.name==368) {
					reqd = true;
					if(r.op==0 || r.op==22) {
						// How about doing a positive rather than negative test? Makes op_mod unnecessary, right?
						if(r.val==prof) return true;
						// Agents can wear all FP stuff
						if(prof==5 && r.op==368) return true;
					}
					// 3 items have operator=24 (!=), always != shade
					if(r.op==24) {
						if(prof==r.val) return false;
					}
				}
			}
			// Testing positive rather than negative test
			if(reqd) return false;
			return true;
		}
		
		private bool factionCheck(Item i, int faction) {
			foreach(Requirement r in i.requirements) {
				// Side=33
				if(r.name==33) {
					if(r.op==0) {
						if(r.val!=faction) return false;
					}
					if(r.op==24) {
						if(r.val==faction) return false;
					}
				}
			}
			return true;
		}
		
		private bool levelCheck(Item i, int level) {
			foreach(Requirement r in i.requirements) {
				// Reqs: 54=level, 37=TitleLevel
				if(r.name==54) {
					// Ops: 0 is ==, 2 is >=	there is no <= req		op=0 is usually for 220 items
					// The off by 1 seems to be +1 in this case, -1 for TitleLevel - not sure if this is universal, testing required
					if(r.op==0) {
						if(level!=r.val+1) return false;
					}
					if(r.op==2) {
						if(level<r.val+1) return false;
					}
				}
				if(r.name==37) {
					// TODO: there is 1 item thats op=0, but its not ingame (295603) - it has GMLevel so it shouldn't show up
					// There is the funny off by 1 problem in the db too
					int tl = Convert.ToInt32(r.val)+1;
					if(tl>=7 && level<205) return false;
					if(tl>=6 && level<190) return false;
					if(tl>=5 && level<150) return false;
					if(tl>=4 && level<100) return false;
					if(tl>=3 && level<50) return false;
					if(tl>=2 && level<15) return false;
					if(tl>=1 && level<1) return false;	// should be irrelevant
				}
			}
			return true;
		}
		
		private bool slCheck(Item i) {
			// Only called if SL is unchecked and should fail all items with the req
			//Expansions: Shadowlands(2)
			foreach(Requirement r in i.requirements) {
				if(r.name==389) {
					if(r.val==2) return false;
				}
				if(r.name==660) return false; // this will never show up on froobable or sloobable items
			}
			return true;
		}
		
		private bool otherExpCheck(Item i) {
			// Only called if Other is unchecked and should fail all items with the reqs
			//Expansions: AI(8), LostEden(32), LoX(128)
			foreach(Requirement r in i.requirements) {
				if(r.name==389) {
					if(r.val==8 || r.val==32 || r.val==128) return false;
				}
				if(r.name==660) return false; // this will never show up on froobable or sloobable items
			}
			return true;
		}
		
		public Item getItem(int aoid) {
			return items.Find(x => x.aoid == aoid); 
		}
	}
	
	public class XmlItem {
		public int aoid;
		public string name;
		public int ql;
		public string type;
		public int icon;
		public int slots;
		public XmlEffect[] effects;
		public XmlRequirement[] requirements;
		
		public XmlItem() {
			effects = new XmlEffect[86]; // # of effects on Blackmane's stat buffer
			requirements = new XmlRequirement[30]; // HACK madeup number
		}
		
		public XmlItem(int id, string n, int q, string t, int i, int s) {
			aoid=id; name=n; ql=q; type=t; icon=i; slots=s;
			effects = new XmlEffect[86]; // # of effects on Blackmane's stat buffer
			requirements = new XmlRequirement[30]; // HACK madeup number
		}
		
		public void addEffects(List<XmlEffect> lxe) {
			effects = lxe.ToArray();
		}
		
		public void addReqs(List<XmlRequirement> lxr) {
			requirements = lxr.ToArray();
		}
		
		public Item toItem() {
			Item i = new Item(aoid,name,ql,type,icon,slots);
			foreach(XmlRequirement xr in requirements) {
				i.addReq(xr.toReq());
			}
			foreach(XmlEffect xe in effects) {
				i.addEffect(xe.toEffect());
			}
			return i;
		}
		
		public bool test() {
			if(icon==0) return false;
			if(effects.Length<=0) return false;
			if(slots==0) return false;
			if(type.Contains("Symbiant") && aoid<220236) return false; // erroneous entries not ingame
			if(ConfigurationManager.AppSettings["simpleLoX"]=="true") {
				if((name.Contains("Skill NCU") || name.Contains("Abilities NCU") || name.Contains("Nano NCU")) && !name.Contains("6/6")) return false;
			}
			foreach(XmlRequirement xr in requirements) {
				// 455=monsters, 215=GM
				if(xr.name==455 || xr.name==215) return false;
			}
			return true;
		}
	}
	
	public class XmlEffect {
		public int skill;
		public long val;
		
		public XmlEffect() {}
		
		public XmlEffect(int s, long v) {
			skill=s; val = v;
		}
		
		public Effect toEffect() {
			return new Effect(skill,val);
		}
	}
	
	public class XmlRequirement {
		public int name;
		public int op;
		public long val;
		public int op_mod;
		public int sequence;
		
		public XmlRequirement() {}
		
		public XmlRequirement(int n, int o, long v, int om, int s) {
			name=n; op=o; val=v; op_mod=om; sequence=s;
		}
		
		public Requirement toReq() {
			return new Requirement(name,op,val,op_mod,sequence);
		}
	}
}
