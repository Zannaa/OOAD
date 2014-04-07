using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ProdavacHrane:Uposlenik
    {
        #region Properties
        /// <summary>
        /// Pult prodavaca
        /// </summary>
        public string Pult { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public ProdavacHrane()
        {

        }

        /// <summary>
        /// Konstruktor klase ProdavacHrane
        /// </summary>
        /// <param name="pult"> Pult prodavaca</param>
        /// <param name="ime"> Ime prodavaca</param>
        /// <param name="prezime"> Prezime prodavaca</param>
        /// <param name="jmbg"> Jmbg prodavaca</param>
        /// <param name="id"> Id prodavaca</param>
        /// <param name="koeficijent"> Koeficijent </param>
        public ProdavacHrane(string pult, string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Pult = pult;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }
        /// <summary>
        /// Konstruktor klase ProdavacHrane koji prima instancu klase ProdavacHrane
        /// </summary>
        /// <param name="noviProdavacHrane">Instanca klase ProdavacHrane</param>
        public ProdavacHrane(ProdavacHrane noviProdavacHrane)
        {
            this.Pult = noviProdavacHrane.Pult;
            this.Ime = noviProdavacHrane.Ime;
            this.Prezime = noviProdavacHrane.Prezime;
            this.Jmbg = noviProdavacHrane.Jmbg;
            this.Id_uposlenika = noviProdavacHrane.Id_uposlenika;
            this.Koeficijent = noviProdavacHrane.Koeficijent;
        }
        #endregion
    }
}
