using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRS
{
    public class Uzytkownik
    {
        private int id;
        private String nazwisko;
        private String imie;
        private String kontakt;
        private String rola;
        private String login;
        private String haslo;
        private int uprawnienia;

        public Uzytkownik(int id, string nazwisko, string imie, string kontakt, string rola, string login, string haslo, int uprawnienia)
        {
            Id = id;
            Nazwisko = nazwisko;
            Imie = imie;
            Kontakt = kontakt;
            Rola = rola;
            Login = login;
            Haslo = haslo;
            Uprawnienia = uprawnienia;
        }

        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Kontakt { get => kontakt; set => kontakt = value; }
        public string Rola { get => rola; set => rola = value; }
        public string Login { get => login; set => login = value; }
        public string Haslo { get => haslo; set => haslo = value; }
        public int Uprawnienia { get => uprawnienia; set => uprawnienia = value; }
        public int Id { get => id; set => id = value; }
    }
}