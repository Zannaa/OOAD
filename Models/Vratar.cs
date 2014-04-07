using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Vratar:Uposlenik
    {
        #region Properties
        /// <summary>
        /// Obuka vratara
        /// </summary>
        public string Obuka { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Vratar()
        {

        }

        /// <summary>
        /// Konstruktor klase Vratar
        /// </summary>
        /// <param name="obuka"> Obuka vratara</param>
        /// <param name="ime"> Ime vratara</param>
        /// <param name="prezime"> Prezime vratara</param>
        /// <param name="jmbg"> Jmbg vratara</param>
        /// <param name="id"> Id vratara</param>
        /// <param name="koeficijent"> Koeficijent </param>
        public Vratar(string obuka, string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Obuka = obuka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }
        /// <summary>
        /// Konstruktor klase Vratar koji prima instancu klase Vratar
        /// </summary>
        /// <param name="noviVratar">Instanca klase Vratar</param>
        public Vratar(Vratar noviVratar)
        {
            this.Obuka = noviVratar.Obuka;
            this.Ime = noviVratar.Ime;
            this.Prezime = noviVratar.Prezime;
            this.Jmbg = noviVratar.Jmbg;
            this.Id_uposlenika = noviVratar.Id_uposlenika;
            this.Koeficijent = noviVratar.Koeficijent;
        }
        #endregion
    }
}
