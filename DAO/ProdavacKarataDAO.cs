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
    public class ProdavacKarataDAO : IRepository<ProdavacKarata>
    {

        private DatabaseManager manager;

        public ProdavacKarataDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(ProdavacKarata prodavacKarata)
        {
            string exec = "INSERT INTO Uposlenik VALUES(" + prodavacKarata.Telefon + "', " + prodavacKarata.Ime + ", '" + prodavacKarata.Prezime + "', " + prodavacKarata.Jmbg + ", '" + prodavacKarata.Id_uposlenika + "', " + prodavacKarata.Koeficijent + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public ProdavacKarata read(ProdavacKarata prodavacKarata)
        {

            return getById(prodavacKarata.Id_uposlenika);
        }

        public ProdavacKarata update(ProdavacKarata prodavacKarata)
        {
            string telefon = prodavacKarata.Telefon;
            string ime = prodavacKarata.Ime;
            string prezime = prodavacKarata.Prezime;
            string jmbg = prodavacKarata.Jmbg;
            int id = prodavacKarata.Id_uposlenika;
            double koeficijent = prodavacKarata.Koeficijent;

            string exec = "UPDATE Uposlenik SET telefon = '" + telefon + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id + "', koeficijent = " + koeficijent;
            exec += " WHERE UposlenikID = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return prodavacKarata;
        }

        public void delete(ProdavacKarata prodavacKarata)
        {
            int id = prodavacKarata.Id_uposlenika;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Uposlenik WHERE UposlenikID = " + id);

        }

        public ProdavacKarata getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Uposlenik where UposlenikID = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ProdavacKarata prodavacKarata = new ProdavacKarata(
                    Convert.ToString(dataRow["telefon"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                return prodavacKarata;
            }


            return null;
        }
        public List<ProdavacKarata> getAll()
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM prodavacKarata");

            List<ProdavacKarata> prodavaciKarata = new List<ProdavacKarata>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ProdavacKarata prodavacKarata = new ProdavacKarata(
                    Convert.ToString(dataRow["telefon"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                prodavaciKarata.Add(prodavacKarata);
            }

            return prodavaciKarata;
        }

    }
}
