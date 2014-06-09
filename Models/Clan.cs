using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clan : Kupac
    {
        #region Properties
        /// <summary>
        /// Id clana 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Jedinstvena sifra kupca
        /// </summary>
        public string Sifra { get; set; }

        /// <summary>
        /// Datum prijave clana
        /// </summary>
        public DateTime Clanstvo { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public Clan()
        {

        }

        /// <summary>
        /// Konstruktor klase Clan sa id
        /// </summary>
        /// <param name="id">Id klase clan</param>
        /// <param name="sifra">Jedinstvena sifra kupca</param>
        /// <param name="clanstvo">Datum prijave clana</param>
        /// <param name="ime">Ime kupca</param>
        /// <param name="prezime">Prezime kupca</param>
        public Clan(int id, string sifra, DateTime clanstvo, string ime, string prezime)
        {
            this.Id = id;
            this.Sifra = sifra;
            this.Clanstvo = clanstvo;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        /// <summary>
        /// Konstruktor klase Clan bez id
        /// </summary>
        /// <param name="sifra">Jedinstvena sifra kupca</param>
        /// <param name="clanstvo">Datum prijave clana</param>
        /// <param name="ime">Ime kupca</param>
        /// <param name="prezime">Prezime kupca</param>
        public Clan(string sifra, DateTime clanstvo, string ime, string prezime)
        {
            this.Sifra = sifra;
            this.Clanstvo = clanstvo;
            this.Ime = ime;
            this.Prezime = prezime;
        }

        /// <summary>
        /// Konstruktor klase Clan koji prima instancu klase Clan
        /// </summary>
        /// <param name="noviClan">Instanca klase Clan</param>
        public Clan(Clan noviClan)
        {
            this.Id = noviClan.Id;
            this.Sifra = noviClan.Sifra;
            this.Clanstvo = noviClan.Clanstvo;
            this.Ime = noviClan.Ime;
            this.Prezime = noviClan.Prezime;
        }
        #endregion
    }
}
