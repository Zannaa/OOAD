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

            string exec = "INSERT INTO rezervacija VALUES(" + rezervacija.ID + ", " + rezervacija.Projekcija.ID + ", " + rezervacija.Sjediste + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);


        }

        public Rezervacija getById(int id)
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Rezervacija AS r, Projekcija AS p WHERE r.Id = " + id);
            QueryBuilder.Append(" AND r.ProjekcijaID = p.ID ");

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            // pročitamo rezultate
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Rezervacija r= new Rezervacija(
                    Convert.ToInt32(dataRow["Id"]),
              
                     new Projekcija(
                    Convert.ToInt32(dataRow["Id"]),
                    Convert.ToDateTime(dataRow["Pocetak"]),
                    Convert.ToDateTime(dataRow["Kraj"]),
                    Convert.ToDouble(dataRow["Cijena"]),
                    new Film(
                        Convert.ToInt32(dataRow["Id"]),
                        Convert.ToString(dataRow["Naziv"]),
                        Convert.ToInt32(dataRow["Sifra"])
                        ),
                    new Sala(
                        Convert.ToInt32(dataRow["Id"]),
                        Convert.ToInt32(dataRow["Kapacitet"]),
                        new List<int>()
                        ) ),

                 Convert.ToInt32(dataRow["Sjediste"])
                );

                return r;
            }

            return null;
        }

        public Rezervacija update(Rezervacija rezervacija)
        {

            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Rezervacija AS r, Projekcija AS p  ");
            QueryBuilder.Append("SET r.ProjekcijaID = " + rezervacija.Projekcija.ID + ", ");
            QueryBuilder.Append("r.Sjediste = " + rezervacija.Sjediste + ", ");
            QueryBuilder.Append(" WHERE r.ID =" + rezervacija.ID);


            throw new NotImplementedException();
        }
    }
}
