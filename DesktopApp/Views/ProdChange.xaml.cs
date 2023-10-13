using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp.Views;

public partial class ProdChange : ContentPage
{
    public ProdChange()
    {
        InitializeComponent();
        CollectArticals ca = new CollectArticals();
        var prodList = ca.ArtikelEANList();
        foreach (var prodItem in prodList)
        {
            listAllProducts.ItemsSource = prodList;
        }
    }
    private void ChangeProd(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        StackLayout listViewItem = (StackLayout)button.Parent;
        Label label = (Label)listViewItem.Children[0];
        String text = label.Text;
        string selEAN = label.Text;
        Application.Current.Resources["EAN"] = selEAN;
        Navigation.PushAsync(new ProdEdit());



    }
    
}
