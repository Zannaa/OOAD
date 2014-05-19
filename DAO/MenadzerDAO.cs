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
    public class MenadzerDAO : IRepository<Menadzer>
    {

        private DatabaseManager manager;

        public MenadzerDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Menadzer menadzer)
        {
            string exec = "INSERT INTO uposlenik VALUES(" + menadzer.Id_uposlenika + "', " +menadzer.Ime + ", '" + menadzer.Prezime + "', " + menadzer.Jmbg + ", " + menadzer.Koeficijent + "," + null+" , " +null+" , " + menadzer.Telefon+" , "+ null + ")";
            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public Menadzer read(Menadzer menadzer)
        {
            // wat?
            return getById(menadzer.Id_uposlenika);
        }

        public Menadzer update(Menadzer menadzer)
        {
            string telefon = menadzer.Telefon;
            string ime = menadzer.Ime;
            string prezime = menadzer.Prezime;
            string jmbg = menadzer.Jmbg;
            int id = menadzer.Id_uposlenika;
            double koeficijent = menadzer.Koeficijent;

            string exec = "UPDATE menadzer SET telefon = '" + telefon + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id + "', koeficijent = " + koeficijent;
            exec += " WHERE id = " + id;
            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return menadzer;
        }

        public void delete(Menadzer menadzer)
        {
            int id = menadzer.Id_uposlenika;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM menadzer WHERE id = " + id);

        }

        public Menadzer getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM menadzer where id = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Menadzer menadzer = new Menadzer(
                    Convert.ToString(dataRow["telefon"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["id"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                );

                return menadzer;
            }

            // heh
            return null;
        }

        public List<Menadzer> getAll()
        {
            return null;
        }


    }
}
