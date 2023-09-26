using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp;

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

                    var Session = Application.Current.Resources;

                    Session["username"] = username;
                    Session["password"] = password;
                    Session["email"] = email;
                    Session["role"] = role;

                    userBox.Text = "";
                    passBox.Text = "";
                    Navigation.PushAsync(new MainPage());
                    db.Close();
                    row.Close();
                }
                else
                {
                    DisplayAlert("ScannerApp: ERROR", "Gebruiker " + userBox.Text + " niet gevonden." , "Oke");
                }
            }
            else
            {
                Debug.WriteLine("Username/Password Empty");
                DisplayAlert("ScannerApp: ERROR", "Gebruikersnaam en/of Wachtwoord niet ingevuld", "Probeer Opnieuw");
            }
        }
        catch
        {
                Debug.WriteLine("DB Error");
                DisplayAlert("ScannerApp: ERROR", "Geen verbinding met Database of fout in Database", "Oke");
        }
    }
}
