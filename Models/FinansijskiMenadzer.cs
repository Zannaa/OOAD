using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class FinansijskiMenadzer:Uposlenik
    {
        #region Properties
        /// <summary>
        /// Telefon finansijskog menadzera
        /// </summary>
        public string Telefon { get; set; }

        /// <summary>
        /// Budzet koji menadzer odredjuje
        /// </summary>
        public double Budzet { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public FinansijskiMenadzer()
        {

        }

        /// <summary>
        /// Konstruktor klase FinansijskiMenadzer
        /// </summary>
        /// <param name="budzet"> Budzet koji odredjuje finansijski menadzer</param>
        /// <param name="telefon"> Telefon finansijskog menadzera</param>
        /// <param name="ime"> Ime finansijskog menadzera</param>
        /// <param name="prezime"> Prezime finansijskog menadzera</param>
        /// <param name="jmbg"> Jmbg finansijskog menadzera</param>
        /// <param name="id"> Id finansijskog menadzera</param>
        /// <param name="koeficijent"> Koeficijent </param>
        public FinansijskiMenadzer(double budzet, string telefon, string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Budzet = budzet;
            this.Telefon = telefon;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }
        /// <summary>
        /// Konstruktor klase FinansijskiMenadzer koji prima instancu klase FinansijskiMenadzer
        /// </summary>
        /// <param name="noviFinansijskiMenadzer">Instanca klase FinansijskiMenadzer</param>
        public FinansijskiMenadzer(FinansijskiMenadzer noviFinansijskiMenadzer)
        {
            this.Budzet = noviFinansijskiMenadzer.Budzet;
            this.Telefon = noviFinansijskiMenadzer.Telefon;
            this.Ime = noviFinansijskiMenadzer.Ime;
            this.Prezime = noviFinansijskiMenadzer.Prezime;
            this.Jmbg = noviFinansijskiMenadzer.Jmbg;
            this.Id_uposlenika = noviFinansijskiMenadzer.Id_uposlenika;
            this.Koeficijent = noviFinansijskiMenadzer.Koeficijent;
        }
        #endregion
    }
}
