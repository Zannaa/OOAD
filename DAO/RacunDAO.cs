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

        public long create(Racun racun)
        {

            string exec = "INSERT INTO racun VALUES(" + racun.Prodavac + ", " + racun.Menadzer + "," + racun.Sifra + " ," + racun.Vrijeme + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);
        }

        public Racun getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Racun r, ProdavacHrane ph WHERE r.RacunId = " + id + " and r.ProdavacID = ph.PrehrambeniProduktID ");

            DataSet data2 = manager.ExecuteSqlCommandToDataSet("SELECT * FROM PrehrambeniProdukt ph, RacunProdukt rp, Racun r WHERE rp.RacunId = " + id + " AND rp.ProduktID = ph.Id ");

            List<PrehrambeniProdukt> lista = new List<PrehrambeniProdukt>();
            foreach (DataRow dataRow in data2.Tables[0].Rows)
            {
                PrehrambeniProdukt ph = new PrehrambeniProdukt(
                    Convert.ToInt32(dataRow["PrehrambeniProduktID"]),
                    Convert.ToString(dataRow["Tip"]),
                    Convert.ToDouble(dataRow["Cijena"])
                );

                lista.Add(ph);
            }

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {


                Racun racun = new Racun(
                    Convert.ToInt32(dataRow["RacunId"]),
                     Convert.ToInt32(dataRow["Sifra"]),
                     Convert.ToDateTime(dataRow["Vrijeme"]),
                  new Menadzer(

                  Convert.ToString(dataRow["Telefon"]),
                   Convert.ToString(dataRow["Ime"]),
                     Convert.ToString(dataRow["Prezime"]),
                       Convert.ToString(dataRow["Jmbg"]),
                         Convert.ToInt32(dataRow["UposlenikId"]),
                           Convert.ToDouble(dataRow["Koeficijent"])
                                                               ),
                  new ProdavacHrane(Convert.ToString(dataRow["Pult"]),
                   Convert.ToString(dataRow["Ime"]),
                     Convert.ToString(dataRow["Prezime"]),
                       Convert.ToString(dataRow["Jmbg"]),
                         Convert.ToInt32(dataRow["UposlenikId"]),
                           Convert.ToDouble(dataRow["Koeficijent"])), lista

                );

                return racun;
            }

            return null;
        }

        public List<Racun> getAll()
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM Racun r, Uposlenik u WHERE r.Fakturisao =   u.ID  AND r.Odobrio = u.ID ");


            //čitamo rezultate
            List<Racun> racuni = new List<Racun>();

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {


                Racun racun = new Racun(
                      Convert.ToInt32(dataRow["RacunId"]),
                       Convert.ToInt32(dataRow["Sifra"]),
                       Convert.ToDateTime(dataRow["Vrijeme"]),
                    new Menadzer(

                    Convert.ToString(dataRow["Telefon"]),
                     Convert.ToString(dataRow["Ime"]),
                       Convert.ToString(dataRow["Prezime"]),
                         Convert.ToString(dataRow["Jmbg"]),
                           Convert.ToInt32(dataRow["UposlenikId"]),
                             Convert.ToDouble(dataRow["Koeficijent"])
                                                                 ),
                    new ProdavacHrane(Convert.ToString(dataRow["Pult"]),
                     Convert.ToString(dataRow["Ime"]),
                       Convert.ToString(dataRow["Prezime"]),
                         Convert.ToString(dataRow["Jmbg"]),
                           Convert.ToInt32(dataRow["UposlenikId"]),
                             Convert.ToDouble(dataRow["Koeficijent"])),
                    new List<PrehrambeniProdukt>()
                    );
            }

            return racuni;
        }

    }
}