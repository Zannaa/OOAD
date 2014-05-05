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
    public class FinansijskiMenadzerDAO : IRepository<FinansijskiMenadzer>
    {

        private DatabaseManager manager;

        public FinansijskiMenadzerDAO()
        {
            this.manager = DatabaseManager.Instance;
        }
       
 
        public long create(FinansijskiMenadzer finansijskiMenadzer)
        {
            string exec = "INSERT INTO finansijskiMenadzer VALUES(" + finansijskiMenadzer.Budzet + ", '" + finansijskiMenadzer.Telefon + "', " + finansijskiMenadzer.Ime + ", '" + finansijskiMenadzer.Prezime + "', "+finansijskiMenadzer.Jmbg +", '" + finansijskiMenadzer.Id_uposlenika + "', " + finansijskiMenadzer.Koeficijent+  ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public FinansijskiMenadzer read(FinansijskiMenadzer finansijskiMenadzer)
        {
         
            return getById(finansijskiMenadzer.Id_uposlenika);
        }

        public FinansijskiMenadzer update(FinansijskiMenadzer finansijskiMenadzer)
        {
            double budzet = finansijskiMenadzer.Budzet;
            string telefon = finansijskiMenadzer.Telefon;
            string ime = finansijskiMenadzer.Ime;
            string prezime = finansijskiMenadzer.Prezime;
            string jmbg = finansijskiMenadzer.Jmbg;
            int id = finansijskiMenadzer.Id_uposlenika;
            double koeficijent = finansijskiMenadzer.Koeficijent;

            string exec = "UPDATE finansijskiMenadzer SET budzet = " + budzet + "budzet, telefon = '" + telefon + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id +"', koeficijent = " + koeficijent;
            exec += " WHERE id = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return finansijskiMenadzer;
        }

        public void delete(FinansijskiMenadzer finansijskiMenadzer)
        {
            int id = finansijskiMenadzer.Id_uposlenika;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM finansijskiMenadzer WHERE id = " + id);

        }

        public FinansijskiMenadzer getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM finansijskiMenadzer where id = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                FinansijskiMenadzer finansijskiMenadzer = new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["budzet"]),
                    Convert.ToString(dataRow["telefon"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["id"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                return finansijskiMenadzer;
            }

          
            return null;
        }
        public List<FinansijskiMenadzer> getAll()
        {
            return null;
        }

    }
}
