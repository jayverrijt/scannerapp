using System.Diagnostics;
using System;

namespace DesktopApp.Classes
{
    public class SessionCtrl
    {
        public string _Username = Application.Current.Resources["username"].ToString();
        public string _Password = Application.Current.Resources["password"].ToString();
        public string _Email = Application.Current.Resources["email"].ToString();
        public string _Role = Application.Current.Resources["role"].ToString();

    }
}