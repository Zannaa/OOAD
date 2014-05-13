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
    public class ObracunDAO : IRepository<Obracun>
    {
        private DatabaseManager manager;

        public ObracunDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Obracun obracun)
        {
            throw new NotImplementedException();
        }

        public Obracun read(Obracun o)
        {
            return getById(o.Id);
        }

        public Obracun update(Obracun obracun)
        {
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Obracun AS o");
            QueryBuilder.Append("SET o.Id = " + obracun.Id + ", ");
            QueryBuilder.Append("o.Datum = " + obracun.Datum + ", ");
            QueryBuilder.Append("o.Obracunao = " + obracun.Obracunao.Id_uposlenika + ", ");
            QueryBuilder.Append("o.UposlenikID =" + obracun.Uposlenik.Id_uposlenika);

            throw new NotImplementedException();

        }

        public void delete(Obracun obracun)
        {
            int id = obracun.Id;

            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Obracun WHERE Id = " + id);
        }

        public Obracun getById(int id)
        {
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Obracun AS o, Uposlenik AS u WHERE o.Id = " + id);
            QueryBuilder.Append(" AND u.Id = o.UposlenikID");
            

            string query = QueryBuilder.ToString();

            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Obracun obracun = new Obracun(
                    Convert.ToInt32(dataRow["Id"]),
                    new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["Id"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                        ),
                    Convert.ToDateTime(dataRow["Datum"]),
                    new Uposlenik(
                        Convert.ToString(dataRow["Ime"]),
                        Convert.ToString(dataRow["Prezime"]),
                        Convert.ToString(dataRow["Jmbg"]),
                        Convert.ToInt32(dataRow["Id"]),
                        Convert.ToDouble(dataRow["Koeficijent"])
                        )
                );

                return obracun;
            }

            return null;
        }

        public List<Obracun> getAll()
          {
              StringBuilder QueryBuilder = new StringBuilder();
              QueryBuilder.Append("SELECT * FROM Obracun AS o, Uposlenik AS u");
              QueryBuilder.Append("  u.Id = o.UposlenikID");

              string query = QueryBuilder.ToString();

              DataSet data = manager.ExecuteSqlCommandToDataSet(query);

              List<Obracun> obracuni = new List<Obracun>();

              foreach (DataRow dataRow in data.Tables[0].Rows)
              {
                Obracun obracun = new Obracun(
                    Convert.ToInt32(dataRow["Id"]),
                    new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["Id"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                        ),
                    Convert.ToDateTime(dataRow["Datum"]),
                    new Uposlenik(
                        Convert.ToString(dataRow["Ime"]),
                        Convert.ToString(dataRow["Prezime"]),
                        Convert.ToString(dataRow["Jmbg"]),
                        Convert.ToInt32(dataRow["Id"]),
                        Convert.ToDouble(dataRow["Koeficijent"])
                        )
                );

                obracuni.Add(obracun);
          }
              return obracuni;
        }
    }
}

