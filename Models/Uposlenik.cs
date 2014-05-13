using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Uposlenik
    {
        /// <summary>
        /// Ime uposlenika
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime uposlenika
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Jmbg uposlenika
        /// </summary>
        public string Jmbg { get; set; }

        /// <summary>
        /// Id uposlenika
        /// </summary>
        public int Id_uposlenika { get; set; }

        /// <summary>
        /// Koeficijent
        /// </summary>
        public double Koeficijent { get; set; }

        public Uposlenik()
        {

        }
        // morala sam ovdje da maknem da je Uposlenik apstraktna klasa
        //i da napravim konstruktor, jer mi treba instanca Uposlenika
        // u DAO
        public Uposlenik(string ime, string prezime, string jmbg, int id, double koeficijent)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
            this.Id_uposlenika = id;
            this.Koeficijent = koeficijent;
        }

    }
}
