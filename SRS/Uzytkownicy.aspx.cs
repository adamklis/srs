using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 9) Response.Redirect("start.aspx");
        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }


        protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            String tbPass = e.NewValues["Haslo"].ToString();
            if (tbPass != "")
            {
                SHA256Managed SHA = new SHA256Managed();
                byte[] pass = Encoding.UTF8.GetBytes(tbPass);
                byte[] hashPass = SHA.ComputeHash(pass);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashPass)
                {
                    sb.Append(b.ToString("X2"));
                }
                e.NewValues["Haslo"] = sb.ToString();
            }
            else
            {
                SqlDataReader rdr = null;
                // create a connection object
                SqlConnection con = null;
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
                // create a command object
                SqlCommand cmd = new SqlCommand("select Haslo from Uzytkownik WHERE Login='"+ e.OldValues["Login"].ToString() + "'", con);
                try
                {
                    String haslo="";
                    // open the connection
                    con.Open();
                    // 1. get an instance of the SqlDataReader
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        haslo = (string)rdr["Haslo"].ToString();
                    }
                    e.NewValues["Haslo"] = haslo;
                }
                finally
                {
                    // 3. close the reader
                    if (rdr != null) { rdr.Close(); }
                    // close the connection
                    if (con != null) { con.Close(); }
                }

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataKey dk = GridView1.SelectedDataKey;
            int a = 0;
            FormView1.PageIndex = 0;
            FormView1.DataBind();
            while (FormView1.DataKey.Value.ToString() != dk.Value.ToString() && a < FormView1.PageCount)
            {
                if (a + 1 < FormView1.PageCount)
                {
                    FormView1.PageIndex++;
                    FormView1.DataBind();
                }
            }
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            String tbPass = e.Values["Haslo"].ToString();
            SHA256Managed SHA = new SHA256Managed();
            byte[] pass = Encoding.UTF8.GetBytes(tbPass);
            byte[] hashPass = SHA.ComputeHash(pass);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashPass)
            {
                sb.Append(b.ToString("X2"));
            }
            e.Values["Haslo"] = sb.ToString();
        }

        protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblDeleteError.Text = "Nie można usunąć użytkownika który posiada zarezerwowane sale.";
                e.ExceptionHandled = true;
            }
        }
    }
}