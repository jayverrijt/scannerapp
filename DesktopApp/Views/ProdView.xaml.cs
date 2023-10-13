using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp.Views;

public partial class ProdView : ContentPage
{
    public ProdView()
    {
        InitializeComponent();
        CollectArticals ca = new CollectArticals();
        var ArtikelList = ca.ArtikelList();
        foreach (var Artikelitem in ArtikelList)
        {
            ArticalNameList.ItemsSource = ArtikelList;
        }

        var ArtikelEAN = ca.ArtikelEANList();
        foreach (var ArtikelEANitem in ArtikelEAN)
        {
            ArticalEANList.ItemsSource = ArtikelEAN;
        }
        
        var ArtikelCode = ca.ArtikelARTCList();
        foreach (var ArtikelCodeitem in ArtikelCode)
        {
            ArticalARTCList.ItemsSource = ArtikelCode;
        }

        var ArtikelNum = ca.ArtikelARTNList();
        foreach (var ArtikelNummeritem in ArtikelNum)
        {
            ArticalARTNList.ItemsSource = ArtikelNum;
        }

        var Formule = ca.ArtikelFORlist();
        foreach (var ArtikelForitem in Formule)
        {
            ArticalFORList.ItemsSource = Formule;
        }

    }
}