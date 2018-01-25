using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRS
{
    public class Rezerwacja
    {
        private int id;
        private Uzytkownik uzytkownik;
        private Sala sala;
        private DateTime czasOd;
        private DateTime czasDo;
        private String komentarz;

        public Rezerwacja(int id, Uzytkownik uzytkownik, Sala sala, DateTime czasOd, DateTime czasDo, string komentarz)
        {
            Id = id;
            Uzytkownik = uzytkownik;
            Sala = sala;
            CzasOd = czasOd;
            CzasDo = czasDo;
            Komentarz = komentarz;
        }

        public int Id { get => id; set => id = value; }
        public Uzytkownik Uzytkownik { get => uzytkownik; set => uzytkownik = value; }
        public Sala Sala { get => sala; set => sala = value; }
        public DateTime CzasOd { get => czasOd; set => czasOd = value; }
        public DateTime CzasDo { get => czasDo; set => czasDo = value; }
        public string Komentarz { get => komentarz; set => komentarz = value; }
    }
}