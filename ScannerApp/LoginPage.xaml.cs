using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using ScannerApp.Classes;

namespace ScannerApp;

public partial class LoginPage : ContentPage
{
    public string id, username, password, email, role;
    private DBConnect db = new DBConnect();


    public LoginPage()
    {
        InitializeComponent();
    }

    private void LoginBtn_OnClicked(object sender, EventArgs e)
    {
        try
        {
            if (userBox.Text != "" && password != "")
            {
                db.Open();
                string query = "SELECT * FROM users WHERE username='" + userBox.Text + "' AND password='" +
                               passBox.Text + "' AND role='2'";
                MySqlDataReader row;
                row = db.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        id = row["id"].ToString();
                        username = row["username"].ToString();
                        password = row["password"].ToString();
                        email = row["email"].ToString();
                        role = row["role"].ToString();
                    }
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Debug.WriteLine("Error: Cannot Find User");
                }
            }
            else
            {
                Debug.WriteLine("Username/Password Empty");
            }
        }
        catch
        {
                Debug.WriteLine("DB Error");
        }
    }
}
