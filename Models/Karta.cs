using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Karta
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
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(ProdavacKarata prodavac, Kupac kupac, Projekcija termin )
        {
            this.Prodavac = prodavac;
            this.Kupac = kupac;
            this.Termin = termin;

        }
        #endregion

    }
}
