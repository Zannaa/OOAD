using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Racun : Faktura
    {
        #region Properties
        /// <summary>
        /// Prodavac koji izdaje racun
        /// </summary>
        public ProdavacHrane Prodavac { get; set; }

        /// <summary>
        /// Produkti na racunu 
        /// </summary>
        public List<PrehrambeniProdukt> Produkti { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Racun()
        {

        }
        /// <summary>
        /// Konstruktor klase Racun
        /// </summary>
        /// <param name="prodavac">Prodavac hrane</param>
        /// <param name="produkt">Produkt koji se kupuje</param>
        public Racun(ProdavacHrane prodavac, PrehrambeniProdukt produkt)
        {
            this.Prodavac = prodavac;
            Produkti = new List<PrehrambeniProdukt>();
            Produkti.Add(produkt);
        }
  
        /// <summary>
        /// Konstruktor klase s listom proizvoda
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Prodavac hrane</param>
        /// <param name="produkti">Lista proizvoda koji se kupuju</param>
        public Racun(int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacHrane prodavac, List<PrehrambeniProdukt> produkti) 
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Produkti = produkti;
        }

        #endregion
    }
}
