/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/16/2013
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Configuration;

namespace AORapidSearch
{
	/// <summary>
	/// Description of GUI.
	/// </summary>
	public partial class GUI : Form
	{	
		DB db;
		ExcludedItems ex;
		List<Slot> slots;
				
		public GUI()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			professionCombo.SelectedIndex=0;
			factionCombo.SelectedIndex=0;
			breedComboBox.SelectedIndex=0;			
			searchButton.Enabled=false;
			excludedItemsToolStripMenuItem.Enabled = false;
			BackgroundWorker loader = new BackgroundWorker();
			loader.DoWork += new DoWorkEventHandler(init);
			loader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(finishedInit);
			loader.RunWorkerAsync();
		}
			
		private void init(System.Object sender, System.EventArgs e) {
			// Parts of the init that are expected to take some time
			ex = new ExcludedItems();
			db = new DB();
		}
		
		private void finishedInit(System.Object sender, RunWorkerCompletedEventArgs e) {
			fillSkillsList();
			addSlots();
			statusWindow.Text = String.Format("Finished. Loaded {0} items and {1} skills.",db.items.Count,skillsList.Items.Count);
			searchButton.Enabled = true;
			excludedItemsToolStripMenuItem.Enabled = true;			
		}
		
		private void fillSkillsList() {
			AODB aodb = new AODB();
			DataTable dt = aodb.Query("SELECT DISTINCT value1 FROM tblItemEffects INNER JOIN tblAO ON (tblItemEffects.aoid=tblAO.aoid AND (tblAO.type='Weapon' OR tblAO.type='Armor' OR tblAO.type='Implant' OR tblAO.type='Spirit') AND tblItemEffects.type=53 AND tblItemEffects.value1!=214);");
			List<string> skills = new List<string>();
			foreach(DataRow dr in dt.Rows) {
				string name = ConfigurationManager.AppSettings[dr["value1"].ToString()];
				skills.Add(name);
			}
			skillsList.DataSource = skills;
		}
		
		public void search() {
			searchButton.Enabled=false;
			foreach(Slot s in slots) {
				s.clearItems();
			}
			// HACK
			//public List<Item> search(int breed, int prof, int faction, int lvl, bool sl, bool otherexp, int skill) {
			int breed = breedComboBox.SelectedIndex;
			int prof = getProf(professionCombo.Text);
			int faction = getFaction(factionCombo.Text);
			int lvl = Convert.ToInt32(level.Value);
			bool sl = !slYesNo.Checked;
			bool other = !otherExpYesNo.Checked;
			int skill = getSkill(skillsList.Text); // TODO: move these get functions into the DB class, pass strings instead
			
			List<Item> results = db.search(breed,prof,faction,lvl,sl,other,skill);
			foreach(Item i in results) {
				foreach(Slot s in slots) {
					if(i.aoid==224709) { // HACK
					
					}
					if(i.slotTest(s.id,s.window)) {
						i.searchSkill=skill;
						s.addItem(i);
					}
				}
			}
			foreach(Slot s in slots) {
				s.process();
			}
			searchButton.Enabled=true;
		}
				
		void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Options options = new Options();
			options.Show();
		}
		
		void UpdateDBToolStripMenuItemClick(object sender, EventArgs e)
		{
			UpdateDatabase upd = new UpdateDatabase();
			upd.Show();
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}	
	
		void CustomSkillsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Small_Forms.NewSkillForm f = new Small_Forms.NewSkillForm();
			f.Show();
		}
		
		void ExludedItemsToolStripMenuItemClick(object sender, EventArgs e)
		{
			ex.displayForm(db);
		}
		
		void OtherExpYesNoCheckedChanged(object sender, EventArgs e)
		{
			//if(otherExpYesNo.Checked==false) slYesNo.Checked=false;
			if(otherExpYesNo.Checked==true) slYesNo.Checked=true;
		}
		
		void SlYesNoCheckedChanged(object sender, EventArgs e)
		{
			if(slYesNo.Checked==false) otherExpYesNo.Checked=false;
		}
		
		void addSlots() {
			slots = new List<Slot>();
			Slot s;
			s = new Slot(7,6,2,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(68,6,32768,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(129,6,4,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(7,64,8,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(68,64,16,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(129,64,32,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(7,122,64,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(68,122,128,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(129,122,256,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(7,180,512,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(68,180,1024,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(129,180,2048,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(7,238,4096,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(68,238,8192,"Weapon",this,pictureBox1); slots.Add(s);
			s = new Slot(129,238,16384,"Weapon",this,pictureBox1); slots.Add(s);
			
			s = new Slot(7,6,2,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(68,6,4,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(129,6,8,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(7,64,16,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(68,64,32,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(129,64,64,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(7,122,128,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(68,122,256,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(129,122,512,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(7,180,1024,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(68,180,2048,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(129,180,4096,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(7,238,8192,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(68,238,16384,"Armor",this,pictureBox2); slots.Add(s);
			s = new Slot(129,238,32768,"Armor",this,pictureBox2); slots.Add(s);
			
			s = new Slot(7,6,2,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(68,6,4,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(129,6,8,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(7,64,16,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(68,64,32,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(129,64,64,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(7,122,128,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(68,122,256,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(129,122,512,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(7,180,1024,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(68,180,2048,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(129,180,4096,"Implant",this,pictureBox3); slots.Add(s);
			s = new Slot(68,238,8192,"Implant",this,pictureBox3); slots.Add(s);
		}
		
		private int getProf(string name) {
			//Soldier1 MartialArtist2 Engineer3	Fixer4 Agent5 Adventurer6 Trader7 Bureaucrat8 Enforcer9 Doctor10 NanoTechnician11 MetaPhysicist12 Monster13 Keeper14 Shade15
			switch(name) {
				case "Soldier": return 1;
				case "Martial Artist": return 2;
				case "Engineer": return 3;
				case "Fixer": return 4;
				case "Agent": return 5;	
				case "Adventurer": return 6;
				case "Trader": return 7;
				case "Bureaucrat": return 8;
				case "Enforcer": return 9;
				case "Doctor": return 10;
				case "Nanotechnician": return 11;
				case "Metaphysicist": return 12;
				case "Keeper": return 14;
				case "Shade": return 15;
			}
			return -1;
		}
		
		private int getFaction(string name) {
			// 0=Neut, 1=Clan, 2=Omni-Tek
			switch(name) {
				case "Neutral": return 0;
				case "Clan": return 1;
				case "Omni-Tek": return 2;
			}
			return -1;
		}
		
		private int getSkill(string name) {
			switch(name) {
				case "ChemicalAC": return 93;   
				case "ColdAC": return 95;   
				case "EnergyAC": return 92;   
				case "FireAC": return 97;   
				case "MeleeAC": return 91;   
				case "PoisonAC": return 96;   
				case "ProjectileAC": return 90;   
				case "RadiationAC": return 94;   
				case "Adventuring": return 137;   
				case "RunSpeed": return 156;   
				case "Treatment": return 124;   
				case "FirstAid": return 123;   
				case "DodgeRanged": return 154;   
				case "DuckExp": return 153;   
				case "EvadeClsC": return 155;   
				case "BeltSlots": return 45;   
				case "MaxNCU": return 181;   
				case "NPCostModifier": return 318;   
				case "Scale": return 360;   
				case "MaxHealth": return 1;   
				case "MaxNanoEnergy": return 221;   
				case "AddAllDef": return 277;   
				case "AddAllOff": return 276;   
				case "XPModifier": return 319;   
				case "ProjectileDamageModifier": return 278;   
				case "ChemicalDamageModifier": return 281;   
				case "RadiationDamageModifier": return 282;   
				case "PoisonDamageModifier": return 317;   
				case "MeleeDamageModifier": return 279;   
				case "EnergyDamageModifier": return 280;   
				case "ColdDamageModifier": return 311;   
				case "FireDamageModifier": return 316;   
				case "Perception": return 136;   
				case "Concealment": return 164;   
				case "ShieldProjectileAC": return 226;   
				case "ShieldChemicalAC": return 229;   
				case "ShieldRadiationAC": return 230;   
				case "ShieldPoisonAC": return 234;   
				case "ShieldNanoAC": return 232;   
				case "ShieldMeleeAC": return 227;   
				case "ShieldEnergyAC": return 228;   
				case "ShieldColdAC": return 231;   
				case "ShieldFireAC": return 233;   
				case "MaxReflectedProjectileDmg": return 475;   
				case "ReflectProjectileAC": return 205;   
				case "ReflectChemicalAC": return 208;   
				case "ReflectRadiationAC": return 216;   
				case "ReflectPoisonAC": return 225;   
				case "MaxReflectedChemicalDmg": return 478;   
				case "MaxReflectedRadiationDmg": return 479;   
				case "MaxReflectedPoisonDmg": return 483;   
				case "MaxReflectedNanoDmg": return 481;   
				case "ReflectNanoAC": return 218;   
				case "MaxReflectedMeleeDmg": return 476;   
				case "ReflectMeleeAC": return 206;   
				case "MaxReflectedEnergyDmg": return 477;   
				case "ReflectEnergyAC": return 207;   
				case "MaxReflectedFireDmg": return 482;   
				case "MaxReflectedColdDmg": return 480;   
				case "ReflectFireAC": return 219;   
				case "ReflectColdAC": return 217;   
				case "WeaponRange": return 380;   
				case "MeleeInit.": return 118;   
				case "RangedInit.": return 119;   
				case "PhysicalInit.": return 120;   
				case "AimedShot": return 151;   
				case "CriticalIncrease": return 379;   
				case "InterruptModifier": return 383;   
				case "NanoRange": return 381;   
				case "NanoC.Init": return 149;   
				case "Swimming": return 138;   
				case "Strength": return 16;   
				case "NanoResist": return 168;   
				case "NanoProgramming": return 160;   
				case "ComputerLiteracy": return 161;   
				case "Health": return 27;   
				case "HealDelta": return 343;   
				case "NanoDelta": return 364;   
				case "SharpObject": return 108;   
				case "MultiMelee": return 101;   
				case "Rifle": return 113;   
				case "TrapDisarm": return 135;   
				case "VehicleWater": return 117;   
				case "VehicleAir": return 139;   
				case "1hBlunt": return 102;   
				case "2hBlunt": return 107;   
				case "Brawl": return 142;   
				case "MeleeEnergy": return 104;   
				case "MartialArts": return 100;   
				case "FastAttack": return 147;   
				case "ElectricalEngineering": return 126;   
				case "MapNavigation": return 140;   
				case "Tutoring": return 141;   
				case "Grenade": return 109;   
				case "HeavyWeapons": return 110;   
				case "SensoryImprovement": return 122;   
				case "MechanicalEngineering": return 125;   
				case "PsychologicalModification": return 129;   
				case "RangedEnergy": return 133;   
				case "QuantumFT": return 157;   
				case "Pharmaceuticals": return 159;   
				case "Chemistry": return 163;   
				case "VehicleGround": return 166;   
				case "Intelligence": return 19;   
				case "Bow": return 111;   
				case "Pistol": return 112;   
				case "AssaultRifle": return 116;   
				case "MaterialCreation": return 130;   
				case "SpaceTime": return 131;   
				case "MultiRanged": return 134;   
				case "SneakAttack": return 146;   
				case "WeaponSmithing": return 158;   
				case "Psychology": return 162;   
				case "BowSpecialAttack": return 121;   
				case "MaterialMetamorphosis": return 127;   
				case "BiologicalMetamorphosis": return 128;   
				case "Psychic": return 21;   
				case "NanoPool": return 132;   
				case "Dimach": return 144;   
				case "Sense": return 20;   
				case "1hEdged": return 103;   
				case "BreakingEntry": return 165;   
				case "FullAuto": return 167;   
				case "Burst": return 148;   
				case "2hEdged": return 105;   
				case "Piercing": return 106;   
				case "MG/SMG": return 114;   
				case "Shotgun": return 115;   
				case "FlingShot": return 150;   
				case "Riposte": return 143;   
				case "Parry": return 145;   
				case "BodyDevelopment": return 152;   
				case "Stamina": return 18;   
				case "Agility": return 17;   
				case "AggDef": return 51;   
				case "Energy": return 26;   
				case "SkillLockModifier": return 382;   
				case "CritialResistance": return 391;   
				case "ShadowBreed": return 532;   
				case "NanoDamageMultiplier": return 536;   
				case "HealMultiplier": return 535;   
				case "RegainXPPercentage": return 593;   
				case "NanoDamageModifier": return 315;   
				case "AMS": return 22;   
				case "DamageToNano": return 659;
			}
			return -1;
		}
	}
}
