using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RadnaEvidencija
    {
        #region Properties
        /// <summary>
        /// Id klase RadnaEvidencija
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Lista radnih vremena
        /// </summary>
        public List<RadnoVrijeme> Rad { get; set; }

        /// <summary>
        /// Uposlenik čije se radno vrijeme evidentira
        /// </summary>
        public Uposlenik Uposlenik { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public RadnaEvidencija()
        {
            this.Rad = new List<RadnoVrijeme>();
        }

        /// <summary>
        /// Konstruktor klase RadnaEvidencija sa id
        /// </summary>
        /// <param name="id">Id klase RadnaEvidencija</param>
        /// <param name="rad">Lista radnih vremena</param>
        /// <param name="uposlenik">Uposlenik čije se radno vrijeme evidentira</param>
        public RadnaEvidencija(int id, List<RadnoVrijeme> rad, Uposlenik uposlenik)
        {
            this.Id = id;
            this.Uposlenik = uposlenik;
            this.Rad = rad;
        }

        /// <summary>
        /// Konstruktor klase RadnaEvidencija bez id
        /// </summary>
        /// <param name="rad">Lista radnih vremena</param>
        /// <param name="uposlenik">Uposlenik čije se radno vrijeme evidentira</param>
        public RadnaEvidencija(List<RadnoVrijeme> rad, Uposlenik uposlenik)
        {
            this.Uposlenik = uposlenik;
            this.Rad = rad;
        }

        /// <summary>
        /// Konstruktor koji prima instancu klase RadnaEvidencija
        /// </summary>
        /// <param name="re">Instanca klase RadnaEvidencija</param>
        public RadnaEvidencija(RadnaEvidencija re)
        {
            this.Id = re.Id;
            this.Rad = re.Rad;
            this.Uposlenik = re.Uposlenik;
        }
        #endregion
    }
}
