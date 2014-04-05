using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Kupac
    {
        /// <summary>
        /// Ime kupca
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime kupca
        /// </summary>
        public string Prezime { get; set; }
    }
}
