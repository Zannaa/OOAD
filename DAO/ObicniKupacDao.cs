﻿using System;
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
            string exec = "INSERT INTO ObicniKupac VALUES(" + ObicniKupac.Id + ", " + ObicniKupac.Sifra + ", " + ", '" + ObicniKupac.Ime + "', '" + ObicniKupac.Prezime + "', " + ")";

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

            string exec = "UPDATE clan SET id = " + id + ", sifra = " + sifra + ", ime = '" + ime + "', prezime = '" + prezime + "'";
            exec += " WHERE id = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return Obicnikupac;
        }

        public void delete(ObicniKupac Obicnikupac)
        {
            int id = Obicnikupac.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Obicnikupac WHERE id = " + id);

        }

        public ObicniKupac getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Obicnikupac where id = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                ObicniKupac Obicnikupac = new ObicniKupac(
                    Convert.ToInt32(dataRow["id"]),
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
                     Convert.ToInt32(dataRow["id"]),
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
