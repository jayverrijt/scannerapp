using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;
using DesktopApp.Classes;

namespace DesktopApp.Views
{
    public partial class DelUser : ContentPage
    {
        public DelUser()
        {
            InitializeComponent();
            CollectUsers cu = new CollectUsers();

            
            var ProdEANlist = cu.getAllUsers();
            foreach (var EANitem in ProdEANlist)
            {
                listAllUsers.ItemsSource = ProdEANlist;
            }
            
            

            
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];
            String text = label.Text;
            Delete del = new Delete();
            del.delFromUsers(text);
            CollectUsers cu = new CollectUsers();
            var Userlist = cu.getAllUsers();
            foreach (var Useritem in Userlist)
            {
                listAllUsers.ItemsSource = Userlist;
            }

        }
    }
}