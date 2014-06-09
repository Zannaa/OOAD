using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;
using Models;
using DAL;
using System.Data;

namespace DAO
{
    class RezervacijaDAO
    {

         private DatabaseManager manager;

        public RezervacijaDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(Rezervacija rezervacija)
        {
            if (rezervacija.Rezervisao.GetType() == typeof(Clan))
            {
                string exec = "INSERT INTO rezervacija VALUES(" + rezervacija.ID + ", " + rezervacija.Projekcija.ID + ", " + rezervacija.Rezervisao.ID + "," + null + " , " + rezervacija.Sjediste + ")";

                return manager.ExecuteSqlCommandToIntForCreate(exec);
            }

            else {
                string exec = "INSERT INTO rezervacija VALUES(" + rezervacija.ID + ", " + rezervacija.Projekcija.ID + ", " + null + "," + rezervacija.Rezervisao.ID + " , " + rezervacija.Sjediste + ")";

                return manager.ExecuteSqlCommandToIntForCreate(exec);
            
            
            } 






        }

       public Rezervacija getById(int id)
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Rezervacija AS r, Projekcija AS p, Film AS f, Sala AS s, ObicniKupac as o,Clan AS c WHERE r.RezervacijaId = " + id);
            QueryBuilder.Append(" AND r.ProjekcijaID = p.ProjekcijaID  AND p.FilmID = f.FilmID AND p.SalaID = s.SalaID AND r.ClanID=c.ClanID AND r.ObicniKupacID=o.ObicniKupacID");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            // pročitamo rezultate
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

		    
                    Rezervacija r = new Rezervacija(
                        Convert.ToInt32(dataRow["RezervacijaId"]),

                         new Projekcija(
                        Convert.ToInt32(dataRow["ProjekcijaId"]),
                        Convert.ToDateTime(dataRow["Pocetak"]),
                        Convert.ToDateTime(dataRow["Kraj"]),
                        Convert.ToDouble(dataRow["Cijena"]),
                        new Film(
                            Convert.ToInt32(dataRow["FilmId"]),
                            Convert.ToString(dataRow["Naziv"]),
                            Convert.ToInt32(dataRow["Sifra"])
                            ),
                        new Sala(
                            Convert.ToInt32(dataRow["SalaId"]),
                            Convert.ToInt32(dataRow["Kapacitet"]),
                            new List<int>()
                            )),

                            k,

                     Convert.ToInt32(dataRow["Sjediste"])
                    );
                    return r;
                }

                
             

                
            

            return null;
        }

        public Rezervacija update(Rezervacija rezervacija)
        {

            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Rezervacija AS r ");
            QueryBuilder.Append("SET r.RezervacijaId = " + rezervacija.ID + ", ");
            QueryBuilder.Append("r.Sjediste = " + rezervacija.Sjediste + ", ");
            QueryBuilder.Append("r.ClanID = " + rezervacija.Rezervisao.ID + ", ");
            QueryBuilder.Append("r.ObicniKupacID = " + rezervacija.Rezervisao.ID + ", ");
            QueryBuilder.Append("r.ProjekcijaID = " + rezervacija.Projekcija.ID + ", ");
           QueryBuilder.Append(" WHERE r.RezervacijaID =" + rezervacija.ID);

           if (rezervacija.Rezervisao.GetType() == typeof(Clan))
           {
               QueryBuilder.Append("UPDATE Rezervacija AS r ");
               QueryBuilder.Append(" SET r.ClanID = " + rezervacija.Rezervisao.ID + ", ");
               QueryBuilder.Append(" WHERE r.RezervacijaID =" + rezervacija.ID);

           }
           else
           {
               QueryBuilder.Append("UPDATE Rezervacija AS r ");
               QueryBuilder.Append("r.ObicniKupacID = " + rezervacija.Rezervisao.ID + ", ");
               QueryBuilder.Append(" WHERE r.RezervacijaID =" + rezervacija.ID);

           }
           return rezervacija; 
        }

        public List<Rezervacija> getAll()
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Rezervacija AS r, Projekcija AS p, Film AS f, Sala AS s, ObicniKupac as o,Clan AS c");
            QueryBuilder.Append(" WHERE r.ProjekcijaID = p.ProjekcijaID  AND p.FilmID = f.FilmID AND p.SalaID = s.SalaID AND r.ClanID=c.ClanID AND r.ObicniKupacID=o.ObicniKupacID");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            //čitamo rezultate
            List<Rezervacija> rezervacije = new List<Rezervacija>();

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
                                           Convert.ToInt32(dataRow["ClanId"]),
                                              Convert.ToString(dataRow["Sifra"]),
                                              Convert.ToDateTime(dataRow["Clanstvo "]),
                                           Convert.ToString(dataRow["Ime"]),
                                            Convert.ToString(dataRow["Prezime"])
                        );
                }


                Rezervacija r = new Rezervacija(
                    Convert.ToInt32(dataRow["RezervacijaId"]),

                     new Projekcija(
                    Convert.ToInt32(dataRow["ProjekcijaId"]),
                    Convert.ToDateTime(dataRow["Pocetak"]),
                    Convert.ToDateTime(dataRow["Kraj"]),
                    Convert.ToDouble(dataRow["Cijena"]),
                    new Film(
                        Convert.ToInt32(dataRow["FilmId"]),
                        Convert.ToString(dataRow["Naziv"]),
                        Convert.ToInt32(dataRow["Sifra"])
                        ),
                    new Sala(
                        Convert.ToInt32(dataRow["SalaId"]),
                        Convert.ToInt32(dataRow["Kapacitet"]),
                        new List<int>()
                        )),

                        k,

                 Convert.ToInt32(dataRow["Sjediste"])
                );
                rezervacije.Add(r);
            }

            return rezervacije;
        }



    }
}
