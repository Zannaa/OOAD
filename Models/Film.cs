using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Film
    {
        #region Atributi
        private int id;
        string naziv;
        int sifra;
        #endregion

        #region Properties
        /// <summary>
        /// ID Filma
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Sifra filma
        /// </summary>

        public int Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }
        /// <summary>
        /// Naziv filma
        /// </summary>
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        #endregion

        # region Constructors
    /// <summary>
    /// Konstruktor klase Film bez id-a
    /// </summary>
    /// <param name="naziv">Naziv filma</param>
    /// <param name="sifra">Sifra film-a</param>
        public Film(string naziv, int sifra)
        {
            this.naziv = naziv;
            this.sifra = sifra;
        }

        /// <summary>
        /// Prazan konstruktor klase Film 
        /// </summary>
        public Film() { }

        /// <summary>
        /// Konstruktor Film sa id-om
        /// </summary>
        /// <param name="id">Id filma</param>
        /// <param name="naziv">Naziv filma</param>
        /// <param name="sifra">Sifra filma</param>
        public Film(int id, string naziv, int sifra)
        {
            this.id = id;
            this.naziv = naziv;
            this.sifra =sifra;

        }
        /// <summary>
        /// Konstruktor klase Film koji prima instancu klase Film
        /// </summary>
        /// <param name="f">instanca klase Film</param>
        public Film(Film f) {
            this.id = f.id;
            this.naziv = f.naziv;
            this.sifra = f.sifra;

        
        }
        #endregion 

    }
}
