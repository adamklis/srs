using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["Uprawnienia"].ToString()) < 2) Response.Redirect("start.aspx");
        }

        protected void gwRezerwacje_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String val = e.Keys["Id_Rezerwacja"].ToString();
            sdsRezerwacje.DeleteCommand = "DELETE FROM Rezerwacja WHERE Id_Rezerwacja=" + val;
        }


    }
}