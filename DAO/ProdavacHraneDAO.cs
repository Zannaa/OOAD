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
    public class ProdavacHraneDAO : IRepository<ProdavacHrane>
    {

        private DatabaseManager manager;

        public ProdavacHraneDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(ProdavacHrane prodavacHrane)
        {
            string exec = "INSERT INTO prodavacHrane VALUES(" + prodavacHrane.Pult + "', " + prodavacHrane.Ime + ", '" + prodavacHrane.Prezime + "', " + prodavacHrane.Jmbg + ", '" + prodavacHrane.Id_uposlenika + "', " + prodavacHrane.Koeficijent + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public ProdavacHrane read(ProdavacHrane prodavacHrane)
        {

            return getById(prodavacHrane.Id_uposlenika);
        }

        public ProdavacHrane update(ProdavacHrane prodavacHrane)
        {
            string pult = prodavacHrane.Pult;
            string ime = prodavacHrane.Ime;
            string prezime = prodavacHrane.Prezime;
            string jmbg = prodavacHrane.Jmbg;
            int id = prodavacHrane.Id_uposlenika;
            double koeficijent = prodavacHrane.Koeficijent;

            string exec = "UPDATE Uposlenik SET pult = '" + pult + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id + "', koeficijent = " + koeficijent;
            exec += " WHERE UposlenikID = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return prodavacHrane;
        }

        public void delete(ProdavacHrane prodavacHrane)
        {
            int id = prodavacHrane.Id_uposlenika;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Uposlenik WHERE UposlenikID = " + id);

        }

        public ProdavacHrane getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Uposlenik where UposlenikID = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ProdavacHrane prodavacHrane = new ProdavacHrane(
                    Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                return prodavacHrane;
            }


            return null;
        }
        public List<ProdavacHrane> getAll()
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Uposlenik WHERE Pult IS NOT NULL");

            List<ProdavacHrane> prodavaciHrane = new List<ProdavacHrane>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ProdavacHrane prodavacHrane = new ProdavacHrane(
                    Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                prodavaciHrane.Add(prodavacHrane);
            }

            return prodavaciHrane;
        }

    }
}
