using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DesktopApp.Classes;

namespace DesktopApp.Views
{
    public partial class ListUser : ContentPage
    {
        public ListUser()
        {
            InitializeComponent();
            CollectUsers cu = new CollectUsers();
            var Adminlist = cu.getAdminUsers();
            foreach(var Adminitem in Adminlist)
            {
                MyAdminListView.ItemsSource = Adminlist;
            }

            var Clientlist = cu.getClientUsers();
            foreach (var Clientitem in Clientlist)
            {
                MyClientListView.ItemsSource = Clientlist;
            }


        }
    }
}