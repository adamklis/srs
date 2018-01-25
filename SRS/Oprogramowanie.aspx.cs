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
    public partial class WebForm11 : System.Web.UI.Page
    {
        private DatabaseList<Oprogramowanie> databaseList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 2) Response.Redirect("start.aspx");

            databaseList = new DatabaseList<Oprogramowanie>(ConfigurationManager.ConnectionStrings["SRSConnectionString"].ConnectionString, "Oprogramowanie");
            databaseList.Select();
            var source = new BindingList<Oprogramowanie>(databaseList.Lista);
            gwOprogramowanie.DataSource = source;
            gwOprogramowanie.DataBind();
        }

        protected void btDodajProgram_Click(object sender, EventArgs e)
        {
            databaseList.Insert(new Oprogramowanie(tbNazwaProgramu.Text));
            gwOprogramowanie.DataBind();
        }

        protected void gwOprogramowanie_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                lblDeleteError.Text = "Nie można usunąć sprzętu który jest na wyposażeniu sali.";
                e.ExceptionHandled = true;
            }
        }

        protected void btZmien_Click(object sender, EventArgs e)
        {
            if (tbIndex.Text != "-1") databaseList.Update(new Oprogramowanie(Convert.ToInt32(tbIndex.Text), tbNazwaProgramu.Text));
            gwOprogramowanie.DataBind();
        }

        protected void gwOprogramowanie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                databaseList.Delete(databaseList.Lista[e.RowIndex]);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblDeleteError.Text = "Nie można usunąć sprzętu który jest na wyposażeniu sali.";
            }

            gwOprogramowanie.DataBind();
        }

        protected void gwOprogramowanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = databaseList.Lista[gwOprogramowanie.SelectedIndex];
            tbIndex.Text = obj.Id_Oprogramowanie.ToString();
            tbNazwaProgramu.Text = obj.Nazwa;
        }
    }
}