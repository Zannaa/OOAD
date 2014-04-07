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
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Karta()
        {

        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Kupac kupac, Projekcija termin )
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Kupac = kupac;
            this.Termin = termin;

        }
        #endregion

    }
}
