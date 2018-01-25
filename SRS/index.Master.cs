using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRS
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogged = ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated);
            if (isLogged && Session["Uprawnienia"] !=null){
                lbl_userInfo.Visible = true;
                lbl_userInfo.Text = "Zalogowano jako: "+Session["imie"]+" "+Session["Nazwisko"]+" ("+Session["login"]+")";
                Menu1.Items.Clear();
                Menu1.Items.Add(new MenuItem("Wyloguj", "Wyloguj", "", "Wylogowano.aspx"));

                if (Convert.ToInt32(Session["Uprawnienia"].ToString()) >= 1)
                {
                    Menu1.Items.Add(new MenuItem("Nowa Rezerwacja", "Nowa Rezerwacja", "", "NowaRezerwacja.aspx"));
                    if (Convert.ToInt32(Session["Uprawnienia"].ToString()) == 1)
                    {
                        Menu1.Items.Add(new MenuItem("Rezerwacje", "Rezerwacje", "", "RezerwacjeUser.aspx"));
                        Menu1.Items.Add(new MenuItem("Sale", "Sale", "", "SaleUser.aspx"));
                    }
                }

                if (Convert.ToInt32(Session["Uprawnienia"].ToString()) >= 2)
                {
                    Menu1.Items.Add(new MenuItem("Rezerwacje", "Rezerwacje", "", "Rezerwacje.aspx"));

                    Menu1.Items.Add(new MenuItem("Sale", "Sale", "", "SaleAdmin.aspx"));
                    Menu1.Items.Add(new MenuItem("Sprzęt", "Sprzęt", "", "Sprzet.aspx"));
                    Menu1.Items.Add(new MenuItem("Oprogramowanie", "Oprogramowanie", "", "Oprogramowanie.aspx"));
                }

                if (Convert.ToInt32(Session["Uprawnienia"].ToString()) >= 9)
                {
                    Menu1.Items.Add(new MenuItem("Użytkownicy", "Użytkownicy", "", "Uzytkownicy.aspx"));
                }
            }
            else
            {
                lbl_userInfo.Visible = false;
                lbl_userInfo.Text = "";
                Menu1.Items.Clear();
                Menu1.Items.Add(new MenuItem("Start", "Start", "", "start.aspx"));
                Menu1.Items.Add(new MenuItem("Zaloguj", "Zaloguj", "", "Login.aspx"));
                Menu1.Items.Add(new MenuItem("Rejestracja", "Rejestracja", "", "Rejestracja.aspx"));
            }
        }
    }
}