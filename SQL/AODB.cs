/*
 * Created by SharpDevelop.
 * User: Grayson
 * Date: 10/14/2013
 * Time: 8:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace AORapidSearch
{
	/// <summary>
	/// Description of AODB.
	/// </summary>
	public class AODB
	{
		string aoitemsfile;
		SQLiteConnection sqlc;
		
		public AODB()
		{
			// TODO work from local copy
			aoitemsfile	= String.Format("Data Source={0}",ConfigurationManager.AppSettings["aoitemspath"].ToString());
			
			try {
				
			}
			catch(Exception fail) {
				MessageBox.Show(fail.ToString());
			}
		}
		
		public DataTable Query(string sql) {
			DataSet ds = new DataSet();
			ds.EnforceConstraints = false;
			DataTable dt = new DataTable();
			ds.Tables.Add(dt);
			try {
				sqlc = new SQLiteConnection(aoitemsfile);
				sqlc.Open();
				SQLiteCommand cmd = new SQLiteCommand(sqlc);
	            cmd.CommandText = sql;
	            SQLiteDataReader reader = cmd.ExecuteReader();
	            dt.Load(reader);
				reader.Close();
				sqlc.Close();
			}
			catch(Exception fail) {
				MessageBox.Show(fail.ToString());
			}
			return dt;
		}
		
		public string ExecuteScalar(string sql)	{
			try {
				sqlc = new SQLiteConnection(aoitemsfile);
				sqlc.Open();
				SQLiteCommand cmd = new SQLiteCommand(sqlc);
				cmd.CommandText = sql;
				object v = cmd.ExecuteScalar();
				sqlc.Close();
				if(v!=null) return v.ToString();
			}
			catch(Exception fail) {
				MessageBox.Show(fail.ToString());
			}
			return "";
		}
	}
}
