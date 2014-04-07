using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Obracun
    {
        #region Properties
        /// <summary>
        /// Id klase Obracun
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fin. menadzer koji je izvrsio obracun
        /// </summary>
        public FinansijskiMenadzer Obracunao { get; set; }

        /// <summary>
        /// Datum obracuna
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Uposlenik za kog se vrši obračun
        /// </summary>
        public Uposlenik Uposlenik { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Obracun()
        {

        }

        /// <summary>
        /// Konstruktor klase Obracun sa id
        /// </summary>
        /// <param name="id">Id klase Obracun</param>
        /// <param name="fm">Fin. menadzer koji je izvrsio obracun</param>
        /// <param name="datum">Datum obracuna</param>
        /// <param name="uposlenik">Uposlenik za kog se vrsi obracun</param>
        public Obracun(int id, FinansijskiMenadzer fm, DateTime datum, Uposlenik uposlenik)
        {
            this.Id = id;
            this.Obracunao = fm;
            this.Datum = datum;
            this.Uposlenik = uposlenik;
        }

        /// <summary>
        /// Konstruktor klase Obracun bez id
        /// </summary>
        /// <param name="fm">Fin. menadzer koji je izvrsio obracun</param>
        /// <param name="datum">Datum obracuna</param>
        /// <param name="uposlenik">Uposlenik za kog se vrsi obracun</param>
        public Obracun(FinansijskiMenadzer fm, DateTime datum, Uposlenik uposlenik)
        {
            this.Obracunao = fm;
            this.Datum = datum;
            this.Uposlenik = uposlenik;
        }

        /// <summary>
        /// Konstruktor koji prima instancu klase Obracun
        /// </summary>
        /// <param name="no">Instanca klase obracun</param>
        public Obracun(Obracun no)
        {
            this.Id = no.Id;
            this.Obracunao = no.Obracunao;
            this.Datum = no.Datum;
            this.Uposlenik = no.Uposlenik;
        }
        #endregion

        #region Methods
        public int obracunaj()
        {
            return 0;
        }
        #endregion
    }
}
