using DAL;
using DAO.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KartaDAO 
    {
        private DatabaseManager manager;

        public KartaDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Karta karta)
        {

            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("INSERT INTO karta (KartaID, ProjekcijaID, Fakturisao, Odobrio, Sifra, Vrijeme, ClanID, ObicniKupacID)");
            QueryBuilder.Append("VALUES ( " + karta.Id + ", "+karta.Termin+ ","+ karta.Prodavac+ ","+ karta.Menadzer+",");
            QueryBuilder.Append(+ karta.Sifra + "," + karta.Vrijeme+", ");
            if (karta.Kupac.GetType()==typeof(Clan))
                 QueryBuilder.Append(+ karta.Kupac.ID + "," + null);
            else QueryBuilder.Append(null + "," + karta.Kupac.ID);

            return manager.ExecuteSqlCommandToIntForCreate(QueryBuilder.ToString());
            
        } 

       public Karta read(Karta k)
        {
            return getById(k.Id);
        }
        
        public Karta update(Karta karta)
        {
         
           
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Karta AS k ");
      
            QueryBuilder.Append("SET k.ProjekcijaID = " + karta.Termin + ", ");
            QueryBuilder.Append(" k.Fakturisao = " + karta.Prodavac.Id_uposlenika + ", ");
            QueryBuilder.Append(" k.Odobrio = " + karta.Menadzer.Id_uposlenika + ", ");
            QueryBuilder.Append(" k.Sifra = " + karta.Sifra + ", ");
            QueryBuilder.Append(" k.Vrijeme = " + karta.Vrijeme + ", ");

           if(karta.Kupac.GetType()==typeof(Clan) )
               QueryBuilder.Append(" k.ClanID = " + karta.Kupac.ID +" , k.ObicniKupacID= "+ null);
           else QueryBuilder.Append(" k.ClanID = " + null + " , k.ObicniKupacID= " + karta.Kupac.ID);
           QueryBuilder.Append(" WHERE k.KartaId= "+ karta.Id);

           return karta;
            
        }

        public void delete(Karta karta)
        {
            int id = karta.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM karta WHERE kartaID = " + id);
        }

        public Karta getById(int id)
        {
            
            StringBuilder QueryBuilder = new StringBuilder();
           QueryBuilder.Append("SELECT * FROM Karta AS k, Uposlenik u, Kupac AS kup, Projekcija AS termin WHERE k.KartaId = " + id);
           QueryBuilder.Append("AND k.ProjekcijaID=termin.ProjekcijaID AND k.Fakturisao=u.UposlenikId AND k.Odobrio=u.UposlenikId") ;

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            // pročitamo rezultate  int id, int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Kupac kupac, Projekcija termin)
             foreach (DataRow dataRow in data.Tables[0].Rows)
            {
              Kupac k;

                if (dataRow["r.ClanID"] == null)
                {
		   k =  new ObicniKupac
			    (
                                Convert.ToInt32(dataRow["ObicniKupacID"]),
                                Convert.ToInt32(dataRow["Kod"]),
                                Convert.ToString(dataRow["Ime"]),
                                Convert.ToString(dataRow["Prezime"])
			    );
		}
		else
		{
		    k = new Clan
			    (
                                   Convert.ToInt32(dataRow["ClanID"]),
                                      Convert.ToString(dataRow["Sifra"]),
                                      Convert.ToDateTime(dataRow["Clanstvo "]), 
                                   Convert.ToString(dataRow["Ime"]),
                                    Convert.ToString(dataRow["Prezime"])
			    );
		}
             
              
                Karta karta = new Karta(
                    Convert.ToInt32(dataRow["KartaID"]),
                    Convert.ToInt32(dataRow["Sifra"]),
                    Convert.ToDateTime(dataRow["Vrijeme"]),
                    new Menadzer(
                 
                  Convert.ToString(dataRow["Telefon"])   , 
                   Convert.ToString(dataRow["Ime"])   , 
                     Convert.ToString(dataRow["Prezime"])   , 
                       Convert.ToString(dataRow["Jmbg"])   , 
                         Convert.ToInt32(dataRow["Uposlenik"])   , 
                           Convert.ToDouble(dataRow["Koeficijent"])   
                                                               ),
                    //string pult, string ime, string prezime, string jmbg, int id, double koeficijent
                    new ProdavacKarata( Convert.ToString(dataRow["Telefon"])   , 
                   Convert.ToString(dataRow["Ime"])   , 
                     Convert.ToString(dataRow["Prezime"])   , 
                       Convert.ToString(dataRow["Jmbg"])   , 
                         Convert.ToInt32(dataRow["Uposlenik"])   , 
                           Convert.ToDouble(dataRow["Koeficijent"])   ),
                      k,
                      
                        new Projekcija( Convert.ToInt32(dataRow["Projekcija"]), Convert.ToDateTime("Pocetak"), Convert.ToDateTime("Kraj"),
                                 Convert.ToDouble("Cijena"), new Film(), new Sala())
                
                );

                return karta;
            }
            
            return null;
        }

        public List<Karta> getAll()
        {

            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Karta AS k, Uposlenik u, Kupac AS kup, Projekcija AS termin");
            QueryBuilder.Append(" WHERE k.ProjekcijaID=termin.ProjekcijaID AND k.Fakturisao=u.UposlenikId AND k.Odobrio=u.UposlenikId");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            //čitamo rezultate
            List<Karta> karte = new List<Karta>();

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Kupac k;

                if (dataRow["r.ClanID"] == null)
                {
                    k = new ObicniKupac
                         (
                                         Convert.ToInt32(dataRow["ObicniKupacID"]),
                                         Convert.ToInt32(dataRow["Kod"]),
                                         Convert.ToString(dataRow["Ime"]),
                                         Convert.ToString(dataRow["Prezime"])
                         );
                }
                else
                {
                    k = new Clan
                        (
                                           Convert.ToInt32(dataRow["ClanID"]),
                                              Convert.ToString(dataRow["Sifra"]),
                                              Convert.ToDateTime(dataRow["Clanstvo "]),
                                           Convert.ToString(dataRow["Ime"]),
                                            Convert.ToString(dataRow["Prezime"])
                        );

                    Karta karta = new Karta(
                       Convert.ToInt32(dataRow["KartaID"]),
                       Convert.ToInt32(dataRow["Sifra"]),
                       Convert.ToDateTime(dataRow["Vrijeme"]),
                       new Menadzer(

                     Convert.ToString(dataRow["Telefon"]),
                      Convert.ToString(dataRow["Ime"]),
                        Convert.ToString(dataRow["Prezime"]),
                          Convert.ToString(dataRow["Jmbg"]),
                            Convert.ToInt32(dataRow["Uposlenik"]),
                              Convert.ToDouble(dataRow["Koeficijent"])
                                                                  ),
                       new ProdavacKarata(Convert.ToString(dataRow["Telefon"]),
                      Convert.ToString(dataRow["Ime"]),
                        Convert.ToString(dataRow["Prezime"]),
                          Convert.ToString(dataRow["Jmbg"]),
                            Convert.ToInt32(dataRow["UposlenikID"]),
                              Convert.ToDouble(dataRow["Koeficijent"])),
                         k,

                           new Projekcija(Convert.ToInt32(dataRow["Projekcija"]), Convert.ToDateTime("Pocetak"), Convert.ToDateTime("Kraj"),
                                    Convert.ToDouble("Cijena"), new Film(), new Sala())

                   );

                    karte.Add(karta);
                }

                return karte;
              
            }
            return null;
        }
    }
}
