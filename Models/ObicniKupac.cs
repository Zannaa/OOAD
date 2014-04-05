using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ObicniKupac : Kupac
    {
        #region Properties
        /// <summary>
        /// Id klase ObicniKupac
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Sifra evidencije kupca
        /// </summary>
        public int Sifra { get; set; }
        #endregion

        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public ObicniKupac()
        {

        }

        /// <summary>
        /// Konstruktor klase ObicniKupac sa id
        /// </summary>
        /// <param name="id">Id klase ObicniKupac</param>
        /// <param name="sifra">Sifra evidencije kupca</param>
        /// <param name="ime">Ime kupca</param>
        /// <param name="prezime">Prezime kupca</param>
        public ObicniKupac(int id, int sifra, string ime, string prezime)
        {
            this.Id = id;
            this.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        /// <summary>
        /// Konstruktor klase ObicniKupac bez id
        /// </summary>
        /// <param name="sifra">Sifra evidencije kupca</param>
        /// <param name="ime">Ime kupca</param>
        /// <param name="prezime">Prezime kupca</param>
        public ObicniKupac(int sifra, string ime, string prezime)
        {
            this.Sifra = sifra;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        /// <summary>
        /// Konstruktor klase ObicniKupac koji prima instancu klase ObicniKupac
        /// </summary>
        /// <param name="noviOK">Instanca klase ObicniKupac</param>
        public ObicniKupac(ObicniKupac noviOK)
        {
            this.Id = noviOK.Id;
            this.Sifra = noviOK.Sifra;
            this.Ime = noviOK.Ime;
            this.Prezime = noviOK.Prezime;
        }
    }
}
