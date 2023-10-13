using System.Diagnostics;
namespace DesktopApp.Classes;

public class UpdateArtikelSet
{
    public void Update(string name, string artcode, string prodcode, string formule)
    {
       // Debug.WriteLine(name);
       // Debug.WriteLine(artcode);
       // Debug.WriteLine(prodcode);
       // Debug.WriteLine(formule);

       string _EAN = Application.Current.Resources["EAN"].ToString();
       DBConnect db = new DBConnect();
       db.Open();
       db.ExecuteReader("UPDATE `products` SET `artikelnaam`='" + name + "', `artcode`='" + artcode + "', `artnummer`='"+ prodcode +"', `formule`='" + formule + "' WHERE ean = '" + _EAN + "'");
       db.Close();
    }

}