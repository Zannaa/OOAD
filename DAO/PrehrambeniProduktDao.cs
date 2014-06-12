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
    public class PrehrambeniProduktDao : IRepository<PrehrambeniProdukt>
    {



        private DatabaseManager manager;

        public PrehrambeniProduktDao()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(PrehrambeniProdukt produkt)
        {
            string exec = "INSERT INTO PrehrambeniProdukt VALUES( '" + produkt.Tip + "', " + produkt.Cijena + ")";

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


            string exec = "UPDATE PrehrambeniProdukt SET tip = '" + tip + "', cijena = " + cijena;
            exec += " WHERE PrehrambeniProduktID = " + produkt.Id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return produkt;
        }

        public void delete(PrehrambeniProdukt produkt)
        {
            int id = produkt.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM PrehrambeniProdukt WHERE PrehrambeniProduktID = " + id);

        }

        public PrehrambeniProdukt getById(int id)
        {


            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM PrehrambeniProdukt where PrehrambeniProduktID = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                PrehrambeniProdukt produkt = new PrehrambeniProdukt(
                    Convert.ToInt32(dataRow["PrehrambeniProduktID"]),
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

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM PrehrambeniProdukt");

            List<PrehrambeniProdukt> produkti = new List<PrehrambeniProdukt>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                PrehrambeniProdukt produkt = new PrehrambeniProdukt(
                    Convert.ToInt32(dataRow["PrehrambeniProduktID"]),
                    Convert.ToString(dataRow["tip"]),
                    Convert.ToDouble(dataRow["cijena"])
                );

                produkti.Add(produkt);
            }

            return produkti;
        }








    }
}
