using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Racun
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
        /// <param name="prodavac">Prodavac hrane</param>
        /// <param name="produkti">Lista proizvoda koji se kupuju</param>
        public Racun(ProdavacHrane prodavac, List<PrehrambeniProdukt> produkti) 
        {
            this.Prodavac = prodavac;
            this.Produkti = produkti;
        }
        #endregion
    }
}
