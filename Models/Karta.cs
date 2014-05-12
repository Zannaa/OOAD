﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Karta : Faktura
    {
        #region Properties
        /// <summary>
        /// Prodavac karte
        /// </summary>
        public ProdavacKarata Prodavac { get; set; }
        /// <summary>
        /// Kupac karte
        /// </summary>
        public Kupac Kupac { get; set; }
        /// <summary>
        /// Termin filma
        /// </summary>
        public Projekcija Termin { get; set; }
        /// <summary>
        /// ID Karte
        /// </summary>
        public int ID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Karta()
        {

        }
        /// <summary>
        /// Konstruktor Karta bez id-a
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Projekcija termin )
        {
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Termin = termin;

        }
        /// <summary>
        /// Konstruktor Karta sa id-om
        /// </summary>
        /// <param name="sifra">ID fakture</param>
        /// <param name="vrijeme">Vrijeme izdavanja</param>
        /// <param name="menadzer">Menadzer koji je odobrio fakturu</param>
        /// <param name="prodavac">Klasa prodavaca karte</param>
        /// <param name="kupac">Kupac karte</param>
        /// <param name="termin">Termin filma</param>
        public Karta(int id, int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Projekcija termin)
        {
            this.ID = id;
            this.Sifra = sifra;
            this.Vrijeme = vrijeme;
            this.Menadzer = menadzer;
            this.Prodavac = prodavac;
            this.Termin = termin;

        }
        /// <summary>
        /// Konstruktor klase Karta koji prima instancu klase Karta
        /// </summary>
        /// <param name="p">Instanca klase Karta</param>
        public Karta(Karta k)
        {
            this.ID = k.ID;
            this.Sifra = k.Sifra;
            this.Vrijeme = k.Vrijeme;
            this.Menadzer = k.Menadzer;
            this.Prodavac = k.Prodavac;
            this.Termin = k.Termin;

        }
        #endregion

    }
}
