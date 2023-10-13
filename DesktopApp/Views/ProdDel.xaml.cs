using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp.Views;

public partial class ProdDel : ContentPage
{
    public ProdDel()
    {
        InitializeComponent();
        CollectArticals ca = new CollectArticals();
        var prodList = ca.ArtikelEANList();
        foreach (var prod in prodList)
        {
            listAllProducts.ItemsSource = prodList;
        }
        
    }

    private void DeleteProduct(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        StackLayout listViewItem = (StackLayout)button.Parent;
        Label label = (Label)listViewItem.Children[0];
        String text = label.Text;
        Delete del = new Delete();
        del.delFromProducts(text);
        CollectArticals ca = new CollectArticals();
        var NewProdList = ca.ArtikelEANList();
        foreach (var prodItem in NewProdList)
        {
            listAllProducts.ItemsSource = NewProdList;
        }

    }
}