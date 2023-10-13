using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace DesktopApp.Classes
{
    public class Delete
    {
        private DBConnect db = new DBConnect();
        public void delFromUsers(string id)
        {
            db.Open();
            db.ExecuteReader("DELETE FROM users WHERE username = '" + id + "'");
        }

        public void delFromProducts(string id)
        {
            db.Open();
            db.ExecuteReader("DELETE FROM products WHERE ean = '" + id + "'");
        }

    }
}