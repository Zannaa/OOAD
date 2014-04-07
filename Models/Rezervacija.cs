using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Rezervacija
    {
        // private Kupac rezervisao;

        /*  public Kupac Rezervisao
          {
              get { return rezervisao; }
              set { rezervisao = value; }
          }
          */
        private Projekcija projekcija;
        private int sjediste;

        /// <summary>
        /// Projekcija
        /// </summary>
        public Projekcija Projekcija
        {
            get { return projekcija; }
            set { projekcija = value; }
        }

     
        /// <summary>
        /// Sjediste
        /// </summary>
        public int Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; }
        }

        /// <summary>
        /// Rezervacija
        /// </summary>
        /// <param name="nprojekcija"></param>
        /// <param name="Sjediste"></param>
        public Rezervacija(Projekcija nprojekcija, int Sjediste)
        {
            // kupac = k;
            projekcija = nprojekcija;
            sjediste = Sjediste;

        }



    }


}
