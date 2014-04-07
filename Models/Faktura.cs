using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Faktura
    {
        #region Properties
        /// <summary>
        /// ID fakture
        /// </summary>
        public int Sifra { get; set; }
        /// <summary>
        /// Vrijeme fakturisanja
        /// </summary>
        public DateTime Vrijeme { get; set; }
        /// <summary>
        /// Menadzer koji je odobrio fakturu
        /// </summary>
        public Menadzer Menadzer { get; set; }
        #endregion
    }
}
