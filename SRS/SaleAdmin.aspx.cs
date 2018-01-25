using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 2) Response.Redirect("start.aspx");
            lblDeleteError.Text = "";
            if (GridView1.SelectedValue != null)
            {
                lblIlosc.Visible = true;
                LblNazwa.Visible = true;
                DDLProgram.Visible = true;
                TbIlosc.Visible = true;
                BtDodaj.Visible = true;

                lblIloscSprzet.Visible = true;
                lblNazwaSprzet.Visible = true;
                DDLSprzet.Visible = true;
                TbIloscSprzet.Visible = true;
                BtDodajSprzet.Visible = true;
            }
            else
            {
                lblIlosc.Visible = false;
                LblNazwa.Visible = false;
                DDLProgram.Visible = false;
                TbIlosc.Visible = false;
                BtDodaj.Visible = false;

                lblIloscSprzet.Visible = false;
                lblNazwaSprzet.Visible = false;
                DDLSprzet.Visible = false;
                TbIloscSprzet.Visible = false;
                BtDodajSprzet.Visible = false;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String val = e.Values["Id_Oprogramowanie"].ToString();
            programyGrid.DeleteCommand = "DELETE FROM Sale_Oprogramowanie WHERE Id_Oprogramowanie=" + val;
        }

        protected void BtDodaj_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddProgramToSala";
                SqlParameter param = new SqlParameter("@id_sala", GridView1.SelectedValue.ToString());
                cmd.Parameters.Add(param);
                param = new SqlParameter("@id_program", DDLProgram.SelectedItem.Value);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ilosc", TbIlosc.Text);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView2.DataBind();
            }
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String val = e.Values["Id_Sprzet"].ToString();
            sprzetGrid.DeleteCommand = "DELETE FROM Sale_Sprzet WHERE Id_Sprzet=" + val;
        }

        protected void BtDodajSprzet_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddSprzetToSala";
                SqlParameter param = new SqlParameter("@id_sala", GridView1.SelectedValue.ToString());
                cmd.Parameters.Add(param);
                param = new SqlParameter("@id_sprzet", DDLSprzet.SelectedItem.Value);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@ilosc", TbIloscSprzet.Text);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView3.DataBind();
            }
        }

        protected void BTdodajSale_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "AddSala";
            SqlParameter param = new SqlParameter("@nazwa", tbNazwaSali.Text);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@liczba_miejsc", tbLiczbaMiejsc.Text);
            cmd.Parameters.Add(param);
            
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIlosc.Visible = true;
            LblNazwa.Visible = true;
            DDLProgram.Visible = true;
            TbIlosc.Visible = true;
            BtDodaj.Visible = true;

            lblIloscSprzet.Visible = true;
            lblNazwaSprzet.Visible = true;
            DDLSprzet.Visible = true;
            TbIloscSprzet.Visible = true;
            BtDodajSprzet.Visible = true;
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblDeleteError.Text = "Nie można usunąć sali która jest aktualnie zarezerwowana.";
                e.ExceptionHandled = true;
            }
        }
    }
}