using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp.Views;

public partial class ProdAdd : ContentPage
{
    public ProdAdd()
    {
        InitializeComponent();
    }

    private void CreateProd(object sender, EventArgs e)
    {
        string ArtNmr, EAN, ArtCode, ProdNmr, Formule;
        ArtNmr = prodName.Text;
        EAN = eanNmr.Text;
        ArtCode = artNmr.Text;
        ProdNmr = prodNmr.Text;
        Formule = formNmr.Text;

        Create cru = new Create();
        cru.CreateProduct(ArtNmr, EAN, ArtCode, ProdNmr, Formule);
    }
}