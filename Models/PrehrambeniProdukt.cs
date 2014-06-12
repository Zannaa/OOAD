﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PrehrambeniProdukt
    {
        #region Properties

        public int Id { get; set; }
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
        /// Konstruktor klase PrehrambeniProdukt sa id
        /// </summary>
        /// <param name="tip">Tip produkta</param>
        /// <param name="cijena">Cijena produkta</param>
        public PrehrambeniProdukt(int id, string tip, double cijena)
        {
            this.Id = id;
            this.Tip = tip;
            this.Cijena = cijena;
        }

        /// <summary>
        /// Konstruktor klase PrehrambeniProdukt bez id
        /// </summary>
        /// <param name="tip">Tip produkta</param>
        /// <param name="cijena">Cijena produkta</param>
        public PrehrambeniProdukt(string tip, double cijena)
        {
            this.Tip = tip;
            this.Cijena = cijena;
        }
        /// <summary>
        /// Konstruktor koji prima instancu klase PrehrambeniProdukt
        /// </summary>
        /// <param name="p">Instanca klase</param>
        public PrehrambeniProdukt(PrehrambeniProdukt p)
        {
            this.Id = p.Id;
            this.Tip = p.Tip;
            this.Cijena = p.Cijena;
        }

        public override string ToString()
        {
            return this.Tip;
        }
        #endregion

    }
}
