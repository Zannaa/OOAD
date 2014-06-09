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
    public class RadnoVrijemeDAO : IRepository<RadnoVrijeme>
    {
        private DatabaseManager manager;

        public RadnoVrijemeDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(RadnoVrijeme radnoVrijeme)
        {
            string exec = "INSERT INTO radnoVrijeme VALUES(" + radnoVrijeme.Pocetak + ", " + radnoVrijeme.Kraj + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public RadnoVrijeme read(RadnoVrijeme radnoVrijeme)
        {

            return getById(radnoVrijeme.Id);
        }

        public RadnoVrijeme update(RadnoVrijeme radnoVrijeme)
        {
            int id = radnoVrijeme.Id;
            DateTime pocetak = radnoVrijeme.Pocetak;
            DateTime kraj = radnoVrijeme.Kraj;

            string exec = "UPDATE radnoVrijeme SET pocetak radnog vremena = " + pocetak + ", kraj radnog vremena=";
            exec += " WHERE RadnoVrijemeId = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return radnoVrijeme;
        }

        public void delete(RadnoVrijeme radnoVrijeme)
        {
            int id = radnoVrijeme.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM radnoVrijeme WHERE RadnoVrijemeId = " + id);

        }

        public RadnoVrijeme getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM finansijskiMenadzer where RadnoVrijemeId = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                RadnoVrijeme radnoVrijeme = new RadnoVrijeme(
                    Convert.ToDateTime(dataRow["pocetak"]),
                    Convert.ToDateTime(dataRow["kraj"])
                );

                return radnoVrijeme;
            }

          
            return null;
        }
        public List<RadnoVrijeme> getAll()
        {
            return null;
        }
    }
}
