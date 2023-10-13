using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;


namespace DesktopApp.Classes
{
    public class CollectArticals
    {
        private DBConnect db = new DBConnect();
        public List<string> ArtikelList()
        {
            var list = new List<string>();

            try
            {

                db.Open();
                MySqlDataReader row;
                row = db.ExecuteReader("SELECT artikelnaam FROM products");
                while (row.Read())
                {
                    for (int i = 0; i < row.FieldCount; i++)
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
        
         public List<string> ArtikelEANList()
         {
             var list = new List<string>();
        
             try
             {
        
                 db.Open();
                 MySqlDataReader row;
                 row = db.ExecuteReader("SELECT ean FROM products");
                 while (row.Read())
                 {
                     for (int i = 0; i < row.FieldCount; i++)
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
         public List<string> ArtikelARTCList()
         {
             var list = new List<string>();
         
             try
             {
         
                 db.Open();
                 MySqlDataReader row;
                 row = db.ExecuteReader("SELECT artcode FROM products");
                 while (row.Read())
                 {
                     for (int i = 0; i < row.FieldCount; i++)
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
          public List<string> ArtikelARTNList()
          {
              var list = new List<string>();
          
              try
              {
          
                  db.Open();
                  MySqlDataReader row;
                  row = db.ExecuteReader("SELECT artnummer FROM products");
                  while (row.Read())
                  {
                      for (int i = 0; i < row.FieldCount; i++)
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
           public List<string> ArtikelFORlist()
           {
               var list = new List<string>();
           
               try
               {
           
                   db.Open();
                   MySqlDataReader row;
                   row = db.ExecuteReader("SELECT formule FROM products");
                   while (row.Read())
                   {
                       for (int i = 0; i < row.FieldCount; i++)
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
           
         
    }
}