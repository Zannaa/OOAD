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
    public class ClanDAO : IRepository<Clan>
    {

        private DatabaseManager manager;

        public ClanDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(Clan clan)
        {
            // insert into Clan VALUES ('string', 'string')
            //  "INSERT INTO film VALUES('" + film.Naziv + "', " + film.Sifra + ")";
            string exec = "INSERT INTO Clan VALUES('" + clan.Ime + "', '" + clan.Prezime + "', '" + clan.Sifra + "', '" + clan.Clanstvo + "')";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public Clan read(Clan clan)
        {

            return getById(clan.Id);
        }

        public Clan update(Clan clan)
        {
            int id = clan.Id;
            string sifra = clan.Sifra;
            DateTime clanstvo = clan.Clanstvo;
            string ime = clan.Ime;
            string prezime = clan.Prezime;

            string exec = "UPDATE Clan SET   sifra = '" + sifra + "', clanstvo = '" + clanstvo + "', ime = '" + ime + "', prezime = '" + prezime + "'";
            exec += " WHERE ClanId = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return clan;
        }

        public void delete(Clan clan)
        {
            int id = clan.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM clan WHERE ClanId = " + id);

        }

        public Clan getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM clan where ClanId = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Clan clan = new Clan(
                    Convert.ToInt32(dataRow["ClanId"]),
                    Convert.ToString(dataRow["sifra"]),
                    Convert.ToDateTime(dataRow["clanstvo"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"])
                );

                return clan;
            }


            return null;
        }
        public List<Clan> getAll()
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM clan");

            List<Clan> clanovi = new List<Clan>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Clan clan = new Clan(
                    Convert.ToInt32(dataRow["ClanId"]),
                    Convert.ToString(dataRow["sifra"]),
                    Convert.ToDateTime(dataRow["clanstvo"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"])
                );

                clanovi.Add(clan);
            }

            return clanovi;
        }

    }
}