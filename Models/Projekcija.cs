using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Projekcija
    {
        #region Atributi
        private int id;
        DateTime pocetak, kraj;
        Double cijena;
        Film film;
        Sala sala;
        #endregion

        #region Properties
        /// <summary>
        /// Pocetak projekcije
        /// </summary>
        public DateTime Pocetak
        {
            get { return pocetak; }
            set { pocetak = value; }
        }

        /// <summary>
        /// ID Filma
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Kraj projekcije
        /// </summary>
        public DateTime Kraj
        {
            get { return kraj; }
            set { kraj = value; }
        }


        /// <summary>
        /// Film koji se prikazuje
        /// </summary>
        public Film Film
        {
            get { return film; }
            set { film = value; }
        }

        /// <summary>
        /// Sala za projekciju
        /// </summary>
        public Sala Sala
        {
            get { return sala; }
            set { sala = value; }


        }

        public double Cijena { 
        get { return cijena; }
            set { cijena = value; }
        
        
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Konstruktor klase Projekcija bez id-a
        /// </summary>
        /// <param name="pocetak">Pocetak projekcije</param>
        /// <param name="kraj">Kraj projekcije</param>
        /// <param name="cijena">Cijena projekcije</param>
        /// <param name="film">Naziv filma</param>
        /// <param name="sala">Sala projekcije</param>
        public Projekcija(DateTime pocetak, DateTime kraj, double cijena, Film film, Sala sala)
        {
            this.pocetak = pocetak;
            this.kraj = kraj;
            this.cijena = cijena;

            this.sala = sala;

        }
        /// <summary>
        /// Konstruktor klase Projekcija bez parametara
        /// </summary>
        public Projekcija() { }


        /// <summary>
        /// Konstruktor klase Projekcija sa id-om
        /// </summary>
        /// <param name="id">Id projekcije</param>
        /// <param name="pocetak">Pocetak projekcije</param>
        /// <param name="kraj">Kraj projekcije</param>
        /// <param name="cijena">Cijena projekcije</param>
        /// <param name="film">Film</param>
        /// <param name="sala">Sala projekcije</param>
        public Projekcija(int id, DateTime pocetak, DateTime kraj, double cijena, Film film, Sala sala)
        {
            this.id = id;
            this.pocetak = pocetak;
            this.kraj = kraj;
            this.cijena = cijena;

            this.sala = sala;
        }

        /// <summary>
        /// Konstruktor klase Projekcija koji prima instancu klase Projekcija
        /// </summary>
        /// <param name="p">Instanca klase Projekcija</param>
        public Projekcija(Projekcija p)
        {
            this.id = p.id;
            this.pocetak = p.pocetak;
            this.kraj = p.kraj;
            this.cijena = p.cijena;

            this.sala = p.sala;

        }

        #endregion


    }
}