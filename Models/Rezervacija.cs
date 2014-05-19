using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rezervacija
    {
        #region Atributi
        private Kupac rezervisao;
        private int id;
        private Projekcija projekcija;
        private int sjediste;
        #endregion


        #region Properties

        /// <summary>
        /// ID Projekcije
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        ///Projekcija
        /// </summary>
        public Projekcija Projekcija
        {
            get { return projekcija; }
            set { projekcija = value; }
        }



          public Kupac Rezervisao
        {
            get { return rezervisao; }
            set { rezervisao = value; }
        } 
        


        /// <summary>
        /// Sjediste
        /// </summary>
        public int Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Konstruktor klase Rezervacija bez id-a
        /// </summary>
        /// <param name="projekcija">Projekcija</param>
        /// <param name="sjediste">Broj sjedišta</param>
        public Rezervacija(Projekcija projekcija,Kupac k, int sjediste)
        {
             this.rezervisao = k;
            this.projekcija = projekcija;
            this.sjediste = sjediste;

        }

        /// <summary>
        /// Konstruktor klase Rezervacija bez parametara
        /// </summary>
        public Rezervacija() { }

        /// <summary>
        /// Konstruktor klase Rezervacija za id-om
        /// </summary>
        /// <param name="id">Id rezervacije</param>
        /// <param name="projekcija">Projekcija</param>
        /// <param name="sjediste">Broj sjedista</param>
        public Rezervacija(int id, Projekcija projekcija, Kupac kupac, int sjediste)
        { 
            
            this.id = id;
            this.projekcija = projekcija;
            this.rezervisao= kupac;
            this.sjediste = sjediste;

        }
        /// <summary>
        /// Konstruktor klase Rezervacija koji prima instancu klase Rezervacija
        /// </summary>
        /// <param name="r">Instanca klase Rezervacija</param>
        public Rezervacija(Rezervacija r)
        {   

            this.id = r.id;
            this.rezervisao=r.rezervisao; 
            this.projekcija = r.projekcija;
            this.sjediste = r.sjediste;


        }
        #endregion

    }


}