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
    public class FinansijskiMenadzerDAO : IRepository<FinansijskiMenadzer>
    {

        private DatabaseManager manager;

        public FinansijskiMenadzerDAO()
        {
            this.manager = DatabaseManager.Instance;
        }
       
 
        public long create(FinansijskiMenadzer finansijskiMenadzer)
        {
            string exec = "INSERT INTO uposlenik VALUES(" + finansijskiMenadzer.Id_uposlenika  + "', " + finansijskiMenadzer.Ime + ", '" + finansijskiMenadzer.Prezime + "', "+finansijskiMenadzer.Jmbg +", "  + finansijskiMenadzer.Koeficijent+ ","+null+null+null+finansijskiMenadzer.Budzet+ ")";

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

            string exec = "UPDATE finansijskiMenadzer SET budzet = " + budzet + ", telefon = '" + telefon + "', ime = '" + ime + "', prezime = '" + prezime + "', jmbg = '" + jmbg + ", id = " + id +"', koeficijent = " + koeficijent;
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
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["Id"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
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
