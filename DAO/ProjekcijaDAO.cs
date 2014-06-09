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
    public class ProjekcijaDAO : IRepository<Projekcija>
    {
        private DatabaseManager manager;

        public ProjekcijaDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Projekcija projekcija)

        {
            
         

            string exec = "INSERT INTO projekcija VALUES(" + projekcija.Pocetak + ", " + projekcija.Kraj + "," + projekcija.Cijena+ " ,"+ projekcija.Sala+","+projekcija.Film + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);
        }

        public Projekcija read(Projekcija p)
        {
            return getById(p.ID);
        }

        public Projekcija update(Projekcija projekcija)
        {
          
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Projekcija AS p, Film AS f, Sala AS s  ");
            QueryBuilder.Append("SET p.Pocetak = " + projekcija.Pocetak + ", ");
            QueryBuilder.Append("p.Kraj = " + projekcija.Kraj + ", ");
            QueryBuilder.Append("p.Cijena = " + projekcija.Cijena + ", ");
            QueryBuilder.Append("p.FilmID =" + projekcija.Film.ID + ", ") ;
            QueryBuilder.Append("p.SalaID="+ projekcija.Sala.ID+ ", ") ;
            QueryBuilder.Append("WHERE p.ProjekcijaID ="+projekcija.ID) ;


            return projekcija;
        }

        public void delete(Projekcija projekcija)
        {
            int id = projekcija.ID;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM menadzer WHERE ProjekcijaID = " + id);
        }

        public Projekcija getById(int id)
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Projekcija AS p, Film AS f, Sala AS s WHERE p.ProjekcijaID = " + id);
            QueryBuilder.Append(" AND p.FilmID = f.FilmID AND p.SalaID = s.SalaID");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            // pročitamo rezultate
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {   
                Projekcija projekcija = new Projekcija(
                    Convert.ToInt32(dataRow["ProjekcijaID"]),
                    Convert.ToDateTime(dataRow["Pocetak"]),
                    Convert.ToDateTime(dataRow["Kraj"]),
                    Convert.ToDouble(dataRow["Cijena"]),
                    new Film(
                        Convert.ToInt32(dataRow["FilmID"]),
                        Convert.ToString(dataRow["Naziv"]),
                        Convert.ToInt32(dataRow["Sifra"])
                        ),
                    new Sala(
                        Convert.ToInt32(dataRow["SalaID"]),
                        0,
                        Convert.ToInt32(dataRow["Kapacitet"]),
                        new List<int>()
                        )
                );

                return projekcija;
            }

            return null;
        }

        public List<Projekcija> getAll()
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Film as f INNER JOIN Projekcija p ON p.FilmId = f.FilmId");
            QueryBuilder.Append(" INNER JOIN Sala AS s ON p.SalaID = s.SalaID");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            //čitamo rezultate
            List<Projekcija> projekcije = new List<Projekcija>();

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Projekcija projekcija = new Projekcija(
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
                        0,
                        Convert.ToInt32(dataRow["Kapacitet"]),
                        new List<int>()
                        )
                );

                projekcije.Add(projekcija);
            }

            return projekcije;
        }

        public void delete(Rezervacija rezervacija)
        {
            int id = rezervacija.ID;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM rezervacija WHERE RezervacijaId = " + id);
        }

    }
}
