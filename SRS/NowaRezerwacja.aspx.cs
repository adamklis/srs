using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 1) Response.Redirect("start.aspx");
        }

        protected void btRezerwuj_Click(object sender, EventArgs e)
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
                cmd.CommandText = "AddRezerwacja"; // This will be the stored procedures name


                param = new SqlParameter("@Id_Uzytkownik", Session["Id_Uzytkownik"]);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Id_Sala", ddlSale.SelectedItem.Value.ToString());
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Czas_Od", tbDataOd.Text + " " + tbCzasOd.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Czas_Do", tbDataDo.Text + " " + tbCzasDo.Text);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@Komentarz", tbKomentarz.Text);
                cmd.Parameters.Add(param);
                SqlDataReader sdr = cmd.ExecuteReader();
                lblBlad.Text = "";
                while (sdr.Read())
                {
                    String nazwa, nazwisko, imie, czas_od, czas_do, komentarz, kontakt;
                    nazwa = (string)sdr["Nazwa"].ToString();
                    nazwisko = (string)sdr["Nazwisko"].ToString();
                    imie = (string)sdr["Imie"].ToString();
                    czas_od = (string)sdr["Czas_Od"].ToString();
                    czas_do = (string)sdr["Czas_Do"].ToString();
                    komentarz = (string)sdr["Komentarz"].ToString();
                    kontakt = (string)sdr["Kontakt"].ToString();
                    lblBlad.Text = "Sala: " + nazwa + " jest zajęta w terminie: " + czas_od + " do " + czas_do + " Przez: " + imie + " " + nazwisko + " ( " + kontakt + " ) " + "<br>" + "Komentarz: " + komentarz;
                }

                con.Close();
            }
        }

        protected void cvCzas_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int yo, mco, dao, ho, mo;
                int yd, mcd, dad, hd, md;
                string[] od = tbDataOd.Text.Split('-');
                yo = Convert.ToInt32(od[0]);
                mco = Convert.ToInt32(od[1]);
                dao = Convert.ToInt32(od[2]);
                od = tbCzasOd.Text.Split(':');
                ho = Convert.ToInt32(od[0]);
                mo = Convert.ToInt32(od[1]);

                string[] doo = tbDataDo.Text.Split('-');
                yd = Convert.ToInt32(doo[0]);
                mcd = Convert.ToInt32(doo[1]);
                dad = Convert.ToInt32(doo[2]);
                doo = tbCzasDo.Text.Split(':');
                hd = Convert.ToInt32(doo[0]);
                md = Convert.ToInt32(doo[1]);

                DateTime dtOd = new DateTime(yo, mco, dao, ho, mo, 0);
                DateTime dtDo = new DateTime(yd, mcd, dad, hd, md, 0);

                args.IsValid = (dtOd < dtDo);
            }
            catch (FormatException)
            {
                args.IsValid = false;
            }
        }

    }
}