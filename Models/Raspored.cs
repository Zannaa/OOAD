using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Raspored
    {
        List<Projekcija> projekcije = new List<Projekcija>();
        /// <summary>
        /// Raspored 
        /// </summary>
        /// <param name="nprojekcije"></param>

        public Raspored(List<Projekcija> nprojekcije)
        {
            projekcije = nprojekcije;

        }

        /// <summary>
        /// Lista projekcija
        /// </summary>
        public List<Projekcija> Projekcije
        {
            get { return projekcije; }
            set { projekcije = value; }
        }
    }
}
