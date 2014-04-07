using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Projekcija
    {
        DateTime pocetak, kraj;
        Double cijena;
        Film film;
        Sala sala;

        /// <summary>
        /// Projekcija
        /// </summary>
        /// <param name="npocetak"></param>
        /// <param name="nkraj"></param>
        /// <param name="ncijena"></param>
        /// <param name="nfilm"></param>
        /// <param name="nsala"></param>
        public Projekcija(DateTime npocetak, DateTime nkraj, double ncijena, Film nfilm, Sala nsala)
        {
            pocetak = npocetak;
            kraj = nkraj;
            cijena = ncijena;

            sala = nsala;

        }

        /// <summary>
        /// Pocetak projekcije
        /// </summary>
        public DateTime Pocetak
        {
            get { return pocetak; }
            set { pocetak = value; }
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

    }
}
