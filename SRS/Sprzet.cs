using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRS
{
    public class Sprzet
    {
        private int id;
        private String nazwa;

        public int Id_Sprzet { get => id; set => id = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        

        public Sprzet()
        {
            id = 0;
            nazwa = null;
        }

        public Sprzet(String nazwa)
        {
            id = 0;
            Nazwa = nazwa;
        }
        public Sprzet(int id, String nazwa)
        {
            Id_Sprzet = id;
            Nazwa = nazwa;
        }
    }
}