using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRS
{
    public class Sala
    {
        private Lista<Sprzet> sprzet;
        private Lista<Oprogramowanie> oprogramowanie;

        private int id;
        private String nazwa;
        private int liczbaMiejsc;

        public Sala(int id, String nazwa, int miejsca)
        {
            Id = id;
            Nazwa = nazwa;
            LiczbaMiejsc = liczbaMiejsc;
            sprzet = new List<Sprzet>();
            oprogramowanie = new List<Oprogramowanie>();
        }

        public List<Sprzet> Sprzet { get => sprzet; set => sprzet = value; }
        public List<Oprogramowanie> Oprogramowanie { get => oprogramowanie; set => oprogramowanie = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int LiczbaMiejsc { get => liczbaMiejsc; set => liczbaMiejsc = value; }
        public int Id { get => id; set => id = value; }
    }
}