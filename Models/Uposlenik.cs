using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Uposlenik
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
    }
}
