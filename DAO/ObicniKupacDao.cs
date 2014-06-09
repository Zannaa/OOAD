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
    public class ObicniKupacDao : IRepository<ObicniKupac>
    {

        private DatabaseManager manager;

        public ObicniKupacDao()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(ObicniKupac ObicniKupac)
        {
            string exec = "INSERT INTO ObicniKupac VALUES('" + ObicniKupac.Ime + "', '" + ObicniKupac.Prezime + "', '" + ObicniKupac.Sifra+"' )";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public ObicniKupac read(ObicniKupac Obicnikupac)
        {

            return getById(Obicnikupac.Id);
        }

        public ObicniKupac update(ObicniKupac Obicnikupac)
        {
            int id = Obicnikupac.Id;
            int sifra = Obicnikupac.Sifra;

            string ime = Obicnikupac.Ime;
            string prezime = Obicnikupac.Prezime;

            string exec = "UPDATE ObicniKupac SET sifra = " + sifra + ", ime = '" + ime + "', prezime = '" + prezime + "'";
            exec += " WHERE ObicniKupacID = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return Obicnikupac;
        }

        public void delete(ObicniKupac Obicnikupac)
        {
            int id = Obicnikupac.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Obicnikupac WHERE ObicniKupacID = " + id);

        }

        public ObicniKupac getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Obicnikupac where ObicniKupacID = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ObicniKupac Obicnikupac = new ObicniKupac(
                    Convert.ToInt32(dataRow["ObicniKupacID"]),
                    Convert.ToInt32(dataRow["sifra"]),

                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"])
                );

                return Obicnikupac;
            }


            return null;
        }
        public List<ObicniKupac> getAll()
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM obicnikupac");

            List<ObicniKupac> kupci = new List<ObicniKupac>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ObicniKupac Obicnikupac = new ObicniKupac(
                     Convert.ToInt32(dataRow["ObicniKupacID"]),
                     Convert.ToInt32(dataRow["sifra"]),

                     Convert.ToString(dataRow["ime"]),
                     Convert.ToString(dataRow["prezime"])
                 );

                kupci.Add(Obicnikupac);
            }

            return kupci;
        }

    }
}
