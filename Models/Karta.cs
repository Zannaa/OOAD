using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Karta : Faktura
    {
        #region Properties

        public string Sifra { get; set; }

        /// <summary>
        /// Prodavac karte
        /// </summary>
        public ProdavacKarata Prodavac { get; set; }
        /// <summary>
        /// Kupac karte
        /// </summary>
        public Kupac Kupac { get; set; }
        /// <summary>
        /// Termin filma
        /// </summary>
        public Projekcija Termin { get; set; }
        /// <summary>
        /// ID Karte
        /// </summary>
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Karta()
        {

        }
        /// <summary>
        /// Konstruktor Karta bez id-a
        /// </summary>
        /// <param name="sifra">Sifra fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(string sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Kupac kupac, Projekcija termin)
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Kupac = kupac;
            this.Termin = termin;

        }
        /// <summary>
        /// Konstruktor Karta sa id-om
        /// </summary>
        /// <param name="id">Id karte</param>
        /// <param name="sifra">Sifra fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(int id, string sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Kupac kupac, Projekcija termin)
        {
            this.Id = id;
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Kupac = kupac;
            this.Termin = termin;

        }
        /// <summary>
        /// Konstruktor klase Karta koji prima instancu klase Karta
        /// </summary>
        /// <param name="p">Instanca klase Karta</param>
        public Karta(Karta k)
        {
            this.Id = k.Id;
            this.Sifra = k.Sifra;
            this.Vrijeme = k.Vrijeme;
            this.Menadzer = k.Menadzer;
            this.Prodavac = k.Prodavac;
            this.Termin = k.Termin;

        }
        #endregion

    }
}
