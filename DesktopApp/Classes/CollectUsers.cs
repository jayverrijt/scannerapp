using System;
using System.Diagnostics;
using MySql;
using MySql.Data.MySqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace DesktopApp.Classes
{
    public class CollectUsers
    {
        private DBConnect db = new DBConnect();
      
        public List<string> getAdminUsers()
        {
            var list = new List<string>();
            
            try
            {

                db.Open();
                MySqlDataReader row;
                row = db.ExecuteReader("SELECT username FROM users WHERE role = 2");
                while (row.Read())
                {
                    for(int i=0; i<row.FieldCount; i++)
                        list.Add(row.GetValue(i).ToString());
                }

                Debug.WriteLine(list);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERR " + ex);
                return null;
            }   
        }
        
         public List<string> getClientUsers()
         {
             var listc = new List<string>();
             
             try
             {
        
                 db.Open();
                 MySqlDataReader rowc;
                 rowc = db.ExecuteReader("SELECT username FROM users WHERE role = 1");
                 while (rowc.Read())
                 {
                     for(int i=0; i<rowc.FieldCount; i++)
                         listc.Add(rowc.GetValue(i).ToString());
                 }
        
                 Debug.WriteLine(listc);
                 return listc;
             }
             catch (Exception ex)
             {
                 Debug.WriteLine("ERR " + ex);
                 return null;
             }   
         }
   public List<string> getAllUsers()
         {
             var listc = new List<string>();
             
             try
             {
        
                 db.Open();
                 MySqlDataReader rowc;
                 rowc = db.ExecuteReader("SELECT username FROM users");
                 while (rowc.Read())
                 {
                     for(int i=0; i<rowc.FieldCount; i++)
                         listc.Add(rowc.GetValue(i).ToString());
                 }
        
                 Debug.WriteLine(listc);
                 return listc;
             }
             catch (Exception ex)
             {
                 Debug.WriteLine("ERR " + ex);
                 return null;
             }   
         }

         
    }
}