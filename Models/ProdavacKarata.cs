using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ProdavacKarata:Uposlenik
    {
        #region Properties
        /// <summary>
        /// Telefon prodavaca
        /// </summary>
        public string Telefon { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public ProdavacKarata()
        {

        }

        /// <summary>
        /// Konstruktor klase ProdavacKarata
        /// </summary>
        /// <param name="telefon"> Telefon prodavaca</param>
        /// <param name="ime"> Ime prodavaca</param>
        /// <param name="prezime"> Prezime prodavaca</param>
        /// <param name="jmbg"> Jmbg prodavaca</param>
        /// <param name="id"> Id prodavaca</param>
        /// <param name="koeficijent"> Koeficijent </param>
        public ProdavacKarata(string telefon, string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Telefon = telefon;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }
        /// <summary>
        /// Konstruktor klase ProdavacKarata koji prima instancu klase ProdavacKarata
        /// </summary>
        /// <param name="noviProdavacKarata">Instanca klase ProdavacKarata</param>
        public ProdavacKarata(ProdavacKarata noviProdavacKarata)
        {
            this.Telefon = noviProdavacKarata.Telefon;
            this.Ime = noviProdavacKarata.Ime;
            this.Prezime = noviProdavacKarata.Prezime;
            this.Jmbg = noviProdavacKarata.Jmbg;
            this.Id_uposlenika = noviProdavacKarata.Id_uposlenika;
            this.Koeficijent = noviProdavacKarata.Koeficijent;
        }
        #endregion
    }
}
