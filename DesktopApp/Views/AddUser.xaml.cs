using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp.Views;

public partial class AddUser : ContentPage
{
    public AddUser()
    {
        InitializeComponent();
    }

    private void CreateUser(object sender, EventArgs e)
    {
        string accountType = "";
        string userName = userBox.Text;
        string passWord = passBox.Text;
        string eMail = emailBox.Text;

        if (radioOne.IsChecked == true)
        {
            accountType = "1";
        } else if (radioTwo.IsChecked == true)
        {
            accountType = "2";
        }
        Create cru = new Create();
        cru.CreateAccount(userName, passWord, eMail, accountType);
        userBox.Text = "";
        passBox.Text = "";
        emailBox.Text = "";
        radioOne.IsChecked = false;
        radioTwo.IsChecked = false;
        DisplayAlert("Account Toegevoegd", "Account " + userName + " is toegevoegd!", "OK");

    }
}