using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RacunDAO
    {
        private DatabaseManager manager;

        public RacunDAO()
        {
            manager = DatabaseManager.Instance;
        }

        public Racun getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Racun r, ProdavacHrane ph WHERE r.id = " + id + " and r.ProdavacID = ph.ID ");

            DataSet data2 = manager.ExecuteSqlCommandToDataSet("SELECT * FROM PrehrambeniProdukt ph, RacunProdukt rp, Racun r WHERE rp.RacunId = " + id + " AND rp.ProduktID = ph.Id ");
				
			List<PrehrambeniProdukt> lista = new List<PrehrambeniProdukt>();
			foreach (DataRow dataRow in data2.Tables[0].Rows)
			{
				PrehrambeniProdukt ph = new PrehrambeniProdukt(
					Convert.ToInt32(dataRow["Id"]),
                    Convert.ToString(dataRow["Tip"]),
                    Convert.ToDouble(dataRow["Cijena"])
				);
				
				lista.Add(ph);
			}
			
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Racun racun = new Racun(
                    //Convert.ToInt32(dataRow["id"]...
                    // itd. isto k'o i na projekciji
                    // ispravite modele, hvala, prijatno
                );

                return racun;
            }

            return null;
        }

    }
}
