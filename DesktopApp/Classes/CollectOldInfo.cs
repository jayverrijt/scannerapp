using System.Diagnostics;

namespace DesktopApp.Classes;

public class CollectOldInfo
{
   public string ArtNaam, ProdCode, ArtNmr, FormName;
   public string _EAN = Application.Current.Resources["EAN"].ToString();
   public void Collect()
   {
      DBConnect db = new DBConnect();
      try
      {
          db.Open();
          var FetchName = db.ExecuteReader("SELECT `artikelnaam` FROM `products` WHERE ean = '" + _EAN + "'");
          foreach (var _FetchName in FetchName)
          {
              ArtNaam = FetchName[0].ToString();
          }
          db.Close();
          db.Open();
          var FetchArtName = db.ExecuteReader("SELECT `artcode` FROM `products` WHERE ean = '" + _EAN + "'");
          foreach (var _FetchArtName in FetchArtName)
          {
              ArtNmr = FetchArtName[0].ToString();
          }
          db.Close();
          db.Open();
          var FetchProdCode = db.ExecuteReader("SELECT `artnummer` FROM `products` WHERE ean = '" + _EAN + "'");
          foreach (var _FetchProdCode in FetchProdCode)
          {
              ProdCode = FetchProdCode[0].ToString();
          }
          db.Close();
          db.Open();
          var FetchFormule = db.ExecuteReader("SELECT `formule` FROM `products` WHERE ean = '" + _EAN + "'");
          foreach (var _FetchFormule in FetchFormule)
          {
              FormName = FetchFormule[0].ToString();
          }
          db.Close();
      }
      catch (Exception e)
      {
        Debug.WriteLine(e); 
      }
   } 
}