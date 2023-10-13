using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Classes;

namespace DesktopApp;

public partial class ProdEdit : ContentPage
{
    public ProdEdit()
    {
        InitializeComponent();
        string _EAN = Application.Current.Resources["EAN"].ToString();
        prodName.Text = "Product " + _EAN;
        CollectOldInfo coi = new CollectOldInfo();
        coi.Collect();
        
        oldArtName.Text = coi.ArtNaam;
        oldArtNmr.Text = coi.ArtNmr;
        oldProdCode.Text = coi.ProdCode;
        oldFormName.Text = coi.FormName;
    }

    private void UpdateSet(object sender, EventArgs e)
    {
        UpdateArtikelSet uas = new UpdateArtikelSet();
        string _name, _art, _prod, _form;
        _name = newArtName.Text;
        _art = newArtNmr.Text;
        _prod = newProdCode.Text;
        _form = newFormName.Text;
        uas.Update(_name,_art,_prod , _form);
    }
}