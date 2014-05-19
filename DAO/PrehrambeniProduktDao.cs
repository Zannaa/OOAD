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
    public class PrehrambeniProduktDao : IRepository<PrehrambeniProdukt>
    {



        private DatabaseManager manager;

        public PrehrambeniProduktDao()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(PrehrambeniProdukt produkt)
        {
            string exec = "INSERT INTO produkt VALUES( "+produkt.Id+", '"+ produkt.Tip + "', " + produkt.Cijena + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public PrehrambeniProdukt read(PrehrambeniProdukt produkt)
        {


            PrehrambeniProdukt p = getById(produkt.Id);

            return p;
        }

        public PrehrambeniProdukt update(PrehrambeniProdukt produkt)
        {
            string tip = produkt.Tip;
            double cijena = produkt.Cijena;


            string exec = "UPDATE produkt SET tip = '" + tip + "', cijena = " + cijena;
            exec += " WHERE id = " + produkt.Id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return produkt;
        }

        public void delete(PrehrambeniProdukt produkt)
        {
            int id = produkt.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM film WHERE id = " + id);

        }

        public PrehrambeniProdukt getById(int id)
        {


            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM film where id = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                PrehrambeniProdukt produkt = new PrehrambeniProdukt(
                    Convert.ToInt32(dataRow["id"]),
                    Convert.ToString(dataRow["tip"]),
                    Convert.ToDouble(dataRow["cijena"])
                );

                return produkt;
            }

            // heh */
            return null;
        }

        public List<PrehrambeniProdukt> getAll()
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM produkt");

            List<PrehrambeniProdukt> produkti = new List<PrehrambeniProdukt>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                PrehrambeniProdukt produkt = new PrehrambeniProdukt(
                    Convert.ToInt32(dataRow["id"]),
                    Convert.ToString(dataRow["tip"]),
                    Convert.ToDouble(dataRow["cijena"])
                );

                produkti.Add(produkt);
            }

            return produkti;
        }








    }
}
