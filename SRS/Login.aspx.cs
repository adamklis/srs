using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btZaloguj_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(tbLogin.Text, false);
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserInfo";
                SqlParameter param = new SqlParameter("@login", tbLogin.Text);
                cmd.Parameters.Add(param);
                SqlDataReader SDR= cmd.ExecuteReader();
                while (SDR.Read())
                {
                    Session["id_uzytkownik"] = (string)SDR["Id_Uzytkownik"].ToString();
                    Session["imie"] = (string)SDR["Imie"].ToString();
                    Session["nazwisko"] = (string)SDR["Nazwisko"].ToString();
                    Session["kontakt"] = (string)SDR["Kontakt"].ToString();
                    Session["rola"] = (string)SDR["Rola"].ToString();
                    Session["login"] = (string)SDR["Login"].ToString();
                    Session["uprawnienia"] = (string)SDR["Uprawnienia"].ToString();
                }
                con.Close();
                
                Response.Redirect("Zalogowano.aspx");
            }
        }

        protected void LoginCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = null;
            SqlCommand cmd;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
            con.Open();
            cmd = con.CreateCommand();
            // This will specify that we are passing the stored procedures name
            SHA256Managed SHA = new SHA256Managed();
            byte[] pass = Encoding.UTF8.GetBytes(tbHaslo.Text);
            byte[] hashPass = SHA.ComputeHash(pass);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashPass)
            {
                sb.Append(b.ToString("X2"));
            }
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT count(haslo) FROM uzytkownik WHERE login='"+tbLogin.Text +"' AND haslo='" + sb.ToString() + "'"; // This will be the stored procedures name
            if ((Int32)cmd.ExecuteScalar() != 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
            con.Close();
        }
    }
}