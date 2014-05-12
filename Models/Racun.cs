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
        /// Konstruktor klase Racun sa id
        /// </summary>
        /// <param name="id">ID racuna</param>
        /// <param name="sifra">Sifra fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Prodavac hrane</param>
        /// <param name="produkti">Lista proizvoda koji se kupuju</param>
        public Racun(int id, int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacHrane prodavac, List<PrehrambeniProdukt> produkti) 
        {
            this.Id = id;
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Produkti = produkti;
        }

        /// <summary>
        /// Konstruktor klase Racun bez id
        /// </summary>
        /// <param name="sifra">Sifra fakture</param>
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
        /// <summary>
        /// Konstruktor koji prima instancu klase Racun
        /// </summary>
        /// <param name="r"></param>
        public Racun(Racun r)
        {
            this.Id = r.Id;
            this.Sifra =r.Sifra;
            this.Vrijeme = r.Vrijeme;
            this.Menadzer = r.Menadzer;
            this.Prodavac = r.Prodavac;
            this.Produkti = r.Produkti;
        }
        #endregion
    }
}
