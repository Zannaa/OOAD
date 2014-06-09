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
    public class VratarDAO : IRepository<Vratar>
    {

        private DatabaseManager manager;

        public VratarDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(Vratar vratar)
        {
            string exec = "INSERT INTO Uposlenik VALUES(" + vratar.Obuka + "', " + vratar.Ime + ", '" + vratar.Prezime + "', " + vratar.Jmbg + ", '" + vratar.Id_uposlenika + "', " + vratar.Koeficijent + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public Vratar read(Vratar vratar)
        {

            return getById(vratar.Id_uposlenika);
        }

        public Vratar update(Vratar vratar)
        {
            string obuka = vratar.Obuka;
            string ime = vratar.Ime;
            string prezime = vratar.Prezime;
            string jmbg = vratar.Jmbg;
            int id = vratar.Id_uposlenika;
            double koeficijent = vratar.Koeficijent;

            string exec = "UPDATE Uposlenik SET obuka = '" + obuka + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id + "', koeficijent = " + koeficijent;
            exec += " WHERE UposlenikId = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return vratar;
        }

        public void delete(Vratar vratar)
        {
            int id = vratar.Id_uposlenika;

            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Uposlenik WHERE UposlenikId = " + id);

        }

        public Vratar getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Uposlenik where UposlenikId = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Vratar vratar = new Vratar(
                    Convert.ToString(dataRow["obuka"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikId"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                return vratar;
            }


            return null;
        }
        public List<Vratar> getAll()
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Uposlenik");

            List<Vratar> vratari = new List<Vratar>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Vratar vratar = new Vratar(
                    Convert.ToString(dataRow["obuka"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikId"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                vratari.Add(vratar);
            }

            return vratari;
        }

    }
}
