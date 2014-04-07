using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Raspored
    {
        #region Atributi
        private int id;
        private List<Projekcija> projekcije = new List<Projekcija>();
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
        /// Lista projekcija
        /// </summary>
        public List<Projekcija> Projekcije
        {
            get { return projekcije; }
            set { projekcije = value; }
        }

        #endregion 
       
        #region Constructors
        /// <summary>
        /// Konstruktor klase Raspored 
        /// </summary>
        /// <param name="nprojekcije">Lista projekcija</param>

        public Raspored(List<Projekcija> projekcije)
        {
           this. projekcije = projekcije;

        }
        /// <summary>
        /// Konstruktor klase Raspored bez parametara sa id-om
        /// </summary>
        public Raspored() { }
       
        /// <summary>
        /// Konstruktor klase Raspored sa id-om
        /// </summary>
        /// <param name="id">Id rasporeda</param>
        /// <param name="projekcije">Lista projekcija</param>
        /// 

        public Raspored(int id, List<Projekcija> projekcije) {
            this.id = id;
            this.projekcije = projekcije;
        }

        public Raspored(Raspored r) {
            this.id = r.id;
            this.projekcije = r.projekcije;
        }


        #endregion
    }
}
