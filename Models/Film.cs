using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Film
    { 
        string naziv;
        string sifra;

     /// <summary>
     /// Sifra filma
     /// </summary>

      public string  Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }
        /// <summary>
        /// Naziv filma
        /// </summary>
      public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
       /// <summary>
       /// Film
       /// </summary>
       /// <param name="nnaziv"></param>
       /// <param name="nsifra"></param>
 
     public Film(string nnaziv, string nsifra)
        {
            naziv = nnaziv;
            sifra = nsifra;
        }


}
