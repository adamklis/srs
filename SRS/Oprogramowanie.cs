using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRS
{
    public class Oprogramowanie
    {
        private int id;
        private String nazwa;

        public int Id_Oprogramowanie { get => id; set => id = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }


        public Oprogramowanie()
        {
            id = 0;
            nazwa = null;
        }

        public Oprogramowanie(String nazwa)
        {
            id = 0;
            Nazwa = nazwa;
        }
        public Oprogramowanie(int id, String nazwa)
        {
            Id_Oprogramowanie = id;
            Nazwa = nazwa;
        }
    }
}