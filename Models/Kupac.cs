using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Kupac
    {
        #region Properties
        /// <summary>
        /// Ime kupca
        /// </summary>
        public string Ime { get; set; }


        /// <summary>
        /// Prezime kupca
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Id klase ObicniKupac
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Sifra evidencije kupca
        /// </summary>
        public int Sifra { get; set; }

        #endregion
        public Kupac() { }
    }
}
