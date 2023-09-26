using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;
using DesktopApp.Views;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Security;

namespace DesktopApp 
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        

        private void btnUsersList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListUser());
        }
        private void btnUsersAdd(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUser());
        }
        private void btnUsersDel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DelUser());
        }
        private void btnProdList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdView());
        }
        private void btnProdAdd(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdAdd());
        }
        private void btnProdDel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdDel());
        }
        private void btnProdChanged(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdChange());
        }
    }
}