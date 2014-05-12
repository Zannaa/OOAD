using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RadnoVrijeme
    {
        #region Properties
        /// <summary>
        /// Id of class RadnoVrijeme
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Početak radnog vremena
        /// </summary>
        public DateTime Pocetak { get; set; }

        /// <summary>
        /// Kraj radnog vremena
        /// </summary>
        public DateTime Kraj { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Prazni konstruktor
        /// </summary>
        public RadnoVrijeme()
        {

        }

        /// <summary>
        /// Konstruktor klase RadnoVrijeme sa id
        /// </summary>
        /// <param name="id">Id klase RadnoVrijeme</param>
        /// <param name="pocetak">Pocetak radnog vremena</param>
        /// <param name="kraj">Kraj radnog vremena</param>
        public RadnoVrijeme(int id, DateTime pocetak, DateTime kraj)
        {
            this.Id = id;
            this.Pocetak = pocetak;
            this.Kraj = kraj;
        }

        /// <summary>
        /// Konstruktor klase RadnoVrijeme bez id
        /// </summary>
        /// <param name="pocetak">Pocetak radnog vremena</param>
        /// <param name="kraj">Kraj radnog vremena</param>
        public RadnoVrijeme(DateTime pocetak, DateTime kraj)
        {
            this.Pocetak = pocetak;
            this.Kraj = kraj;
        }

        /// <summary>
        /// Konstruktor koji prima instancu klase RadnoVrijeme
        /// </summary>
        /// <param name="rv">Instanca klase RadnoVrijeme</param>
        public RadnoVrijeme(RadnoVrijeme rv)
        {
            this.Id = rv.Id;
            this.Pocetak = rv.Pocetak;
            this.Kraj = rv.Kraj;
        }
        #endregion
    }
}
