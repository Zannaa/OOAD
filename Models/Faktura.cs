using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Faktura
    {
        #region Properties
        /// <summary>
        /// ID fakture
        /// </summary>
        public int Sifra { get; set; }
        /// <summary>
        /// Vrijeme fakturisanja
        /// </summary>
        public DateTime Vrijeme { get; set; }
        /// <summary>
        /// Menadzer koji je odobrio fakturu
        /// </summary>
        public Menadzer Menadzer { get; set; }
        #endregion
        
        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Faktura()
        {

        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        public Faktura(int sifra, DateTime vrijeme, Menadzer menadzer)
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
        }
        #endregion
    }
}
