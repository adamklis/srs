using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        private DatabaseList<Sprzet> databaseList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 2) Response.Redirect("start.aspx");

            databaseList = new DatabaseList<Sprzet>(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString, "Sprzet");
            databaseList.Select();
            var source = new BindingList<Sprzet>(databaseList.Lista);
            GWSprzet.DataSource = source;
            GWSprzet.DataBind();
        }

        protected void btDodajSprzet_Click(object sender, EventArgs e)
        {
            databaseList.Insert(new Sprzet(tbNazwaSprzetu.Text));
            GWSprzet.DataBind();
        }

        protected void GWSprzet_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblDeleteError.Text = "Nie można usunąć sprzętu który jest na wyposażeniu sali.";
                e.ExceptionHandled = true;

            }
        }

        protected void GWSprzet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                databaseList.Delete(databaseList.Lista[e.RowIndex]);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblDeleteError.Text = "Nie można usunąć sprzętu który jest na wyposażeniu sali.";
            }

            GWSprzet.DataBind();
        }

        protected void GWSprzet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = databaseList.Lista[GWSprzet.SelectedIndex];
            tbIndex.Text = obj.Id_Sprzet.ToString();
            tbNazwaSprzetu.Text = obj.Nazwa;
        }

        protected void btZmienSprzet_Click(object sender, EventArgs e)
        {
            if (tbIndex.Text!="-1") databaseList.Update(new Sprzet(Convert.ToInt32(tbIndex.Text),tbNazwaSprzetu.Text));
            GWSprzet.DataBind();
        }
    }
}