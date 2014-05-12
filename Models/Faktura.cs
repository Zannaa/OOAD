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
        public int Id { get; set; }
        /// <summary>
        /// Sifra fakture
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
        /// Konstruktor sa id
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        public Faktura(int id, int sifra, DateTime vrijeme, Menadzer menadzer)
        {
            this.Id = id;
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
        }

        /// <summary>
        /// Konstruktor bez id
        /// </summary>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        public Faktura(int sifra, DateTime vrijeme, Menadzer menadzer)
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
        }
        /// <summary>
        /// Konstruktor koji prima instancu klase Faktura
        /// </summary>
        /// <param name="f">Instanca klase Faktura</param>
        public Faktura(Faktura f) 
        {
            this.Id = f.Id;
            this.Sifra = f.Sifra;
            this.Vrijeme = f.Vrijeme;
            this.Menadzer = f.Menadzer;
        }
        #endregion
    }
}
