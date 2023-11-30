using System;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DesktopApp.Classes;

public class Create
{
    private DBConnect db = new DBConnect();

    public void CreateAccount(string userName, string passWord, string eMail, string accountType)
    {
        try
        {
            db.Open();
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(passWord);
            Debug.WriteLine(encryptedPassword);
            db.ExecuteReader("INSERT INTO `users`(`username`, `password`, `email`, `role`) VALUES ('" + userName + "','" + encryptedPassword + "','"+ eMail + "','"+ accountType +"')");
        }
        catch (Exception e)
        {
           Debug.WriteLine(e); 
        }
    }

    public void CreateProduct(string name, string ean, string artcode, string prodnmr, string formule)
    {
        try
        {
            db.Open();
            db.ExecuteReader("INSERT INTO `products`(`artikelnaam`,`ean`,`artcode`,`artnummer`,`formule`) VALUES ('" +
                             name + "','" + ean + "','" + artcode + "','" + prodnmr + "','" + formule + "')");
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}