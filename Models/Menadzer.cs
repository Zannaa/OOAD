using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Menadzer:Uposlenik
    {
        #region Properties
        /// <summary>
        /// Telefon menadzera
        /// </summary>
        public string Telefon { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Menadzer()
        {

        }

        /// <summary>
        /// Konstruktor klase Menadzer
        /// </summary>
        /// <param name="telefon"> Telefon menadzera</param>
        /// <param name="ime"> Ime menadzera</param>
        /// <param name="prezime"> Prezime menadzera</param>
        /// <param name="jmbg"> Jmbg menadzera</param>
        /// <param name="id"> Id menadzera</param>
        /// <param name="koeficijent"> Koeficijent </param>
        public Menadzer(string telefon, string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Telefon = telefon;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }
        /// <summary>
        /// Konstruktor klase Menadzer koji prima instancu klase Menadzer
        /// </summary>
        /// <param name="noviMenadzer">Instanca klase Menadzer</param>
        public Menadzer(Menadzer noviMenadzer)
        {
            this.Telefon = noviMenadzer.Telefon;
            this.Ime = noviMenadzer.Ime;
            this.Prezime = noviMenadzer.Prezime;
            this.Jmbg = noviMenadzer.Jmbg;
            this.Id_uposlenika = noviMenadzer.Id_uposlenika;
            this.Koeficijent = noviMenadzer.Koeficijent;
        }
        #endregion
    }
}
