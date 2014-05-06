using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrehrambeniProdukt
    {
        #region Properties

        public int ID { get; set; }
        /// <summary>
        /// Tip produkta
        /// </summary>
        public string Tip { get; set; }

        /// <summary>
        /// Cijena produkta
        /// </summary>
        public double Cijena { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public PrehrambeniProdukt()
        {

        }
        /// <summary>
        /// Konstruktor klase PrehrambeniProdukt
        /// </summary>
        /// <param name="tip">Tip produkta</param>
        /// <param name="cijena">Cijena produkta</param>
        public PrehrambeniProdukt(int id, string tip, double cijena)
        {
            this.ID = id; 
            this.Tip = tip;
            this.Cijena = cijena;
        }
        #endregion
    }
}
