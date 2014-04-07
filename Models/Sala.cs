using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Sala
    {
        #region Atributi 
        private int sjediste;
        private int kapacitet;
        private int id;
        private List<int> sjedista = new List<int>();

        #endregion 

        
        #region Properties
        public List<int> Sjedista
        {
            get { return sjedista; }
            set { sjedista = value; }
        }


        public int Kapacitet
        {
            get { return kapacitet; }
            set { kapacitet = value; }
        }


        public int Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; }
        }
        /// <summary>
        /// ID Sale
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion 



        #region Constructors
        
        
        /// <summary>
        /// Konstruktor klase Sala bez id-a
        /// </summary>
        /// <param name="sjediste">Broj sjedišta</param>
        /// <param name="kapacitet">Kapacitet sale</param>
        /// <param name="sjedista">Lista sjedišta u sali</param>
        public Sala(int sjediste, int kapacitet, List<int> sjedista)
        {
            this.sjediste = sjediste;
            this.kapacitet = kapacitet;
            this.sjedista = sjedista;

        }

        /// <summary>
        /// Prazan konstruktor klase Sala
        /// </summary>
        public Sala() { }

        /// <summary>
        /// Konstruktor klase Sala sa id-om
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sjediste"></param>
        /// <param name="kapacitet"></param>
        /// <param name="sjedista"></param>
      
        public Sala(int id, int sjediste, int kapacitet, List<int> sjedista) {
            this.id = id;
            this.sjediste = sjediste;
            this.kapacitet = kapacitet;
            this.sjedista = sjedista;
        
        
        }

        /// <summary>
        /// Konstruktor klase Sala koji prima instancu klase Sala
        /// </summary>
        /// <param name="s"></param>

        public Sala(Sala s) {
            this.id = s.id;
            this.sjediste = s.sjediste;
            this.sjedista = s.sjedista;
        
        
        }
        #endregion 

    }
}
