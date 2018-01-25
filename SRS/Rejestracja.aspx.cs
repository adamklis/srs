using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace SRS
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btZaloguj_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection con = null;
                SqlCommand cmd;
                SqlParameter param;
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
                con.Open();
                cmd = con.CreateCommand();
                // This will specify that we are passing the stored procedures name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddUser"; // This will be the stored procedures name
                param = new SqlParameter("@login", tbLogin.Text);
                cmd.Parameters.Add(param);
                SHA256Managed SHA = new SHA256Managed();
                byte[] pass = Encoding.UTF8.GetBytes(tbHaslo.Text);
                byte[] hashPass = SHA.ComputeHash(pass);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashPass)
                {
                    sb.Append(b.ToString("X2"));
                }
                param = new SqlParameter("@haslo", sb.ToString());
                cmd.Parameters.Add(param);
                param = new SqlParameter("@nazwisko", tbNazwisko.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@imie", tbImie.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@kontakt", tbKontakt.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@rola", tbRola.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@uprawnienia", "0");
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("RegisterComplete.aspx");
            }
        }

        protected void LoginCV_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = null;
            SqlCommand cmd;
            SqlParameter param;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckUserExist"; // This will be the stored procedures name
            param = new SqlParameter("@login", tbLogin.Text);
            cmd.Parameters.Add(param);
            args.IsValid = ((Int32)cmd.ExecuteScalar() == 0);
            con.Close();
        }
    }
}