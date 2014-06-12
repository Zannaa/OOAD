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
    public class RadnaEvidencijaDAO
    {
        private DatabaseManager manager;

        public RadnaEvidencijaDAO()
        {
            manager = DatabaseManager.Instance;
        }

        public long create(RadnaEvidencija evidencija)
        {

            string exec = "INSERT INTO racun VALUES(" + evidencija.Uposlenik + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);
        }

        public RadnaEvidencija getByEmpId(int id)
        {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM RadnaEvidencija e, Uposlenik u WHERE e.UposlenikId = " + id + " AND e.UposlenikId = u.UposlenikId");

            DataSet data2 = manager.ExecuteSqlCommandToDataSet("SELECT * FROM RadnoVrijeme rv, RadnaEvidencija re, Uposlenik up WHERE up.UposlenikId = " + id + " AND rv.RadnaEvidencijaID = re.RadnaEvidencijaID AND re.UposlenikId = up.UposlenikId ");

            List<RadnoVrijeme> lista = new List<RadnoVrijeme>();
            foreach (DataRow dataRow in data2.Tables[0].Rows)
            {
                RadnoVrijeme rv = new RadnoVrijeme(
                    Convert.ToInt32(dataRow["RadnoVrijemeId"]),
                    Convert.ToDateTime(dataRow["Pocetak"]),
                    Convert.ToDateTime(dataRow["Kraj"])
                );

                lista.Add(rv);
            }

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Uposlenik uposlenik;
                if (dataRow["Telefon"] != null)
                {
                    uposlenik = new ProdavacKarata(
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikId"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }
                else if (dataRow["Budzet"] != null)
                {
                    uposlenik = new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }

                else
                {
                    uposlenik = new ProdavacHrane(
                    Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                    );
                }

                RadnaEvidencija evidencija = new RadnaEvidencija(
                    Convert.ToInt32(dataRow["RadnaEvidencijaID"]),
                    lista,
                    uposlenik
                );

                return evidencija;
            }

            return null;

        }

        public RadnaEvidencija getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM RadnaEvidencija e, Uposlenik u WHERE e.RadnaEvidencijaId = " + id + " AND e.UposlenikId = u.UposlenikId");

            DataSet data2 = manager.ExecuteSqlCommandToDataSet("SELECT * FROM RadnoVrijeme r, RadnaEvidencija re WHERE re.RadnaEvidencijaId = " + id + " AND r.RadnaEvidencijaID = re.RadnaEvidencijaID ");

            List<RadnoVrijeme> lista = new List<RadnoVrijeme>();
            foreach (DataRow dataRow in data2.Tables[0].Rows)
            {
                RadnoVrijeme rv = new RadnoVrijeme(
                    Convert.ToInt32(dataRow["RadnoVrijemeId"]),
                    Convert.ToDateTime(dataRow["Pocetak"]),
                    Convert.ToDateTime(dataRow["Kraj"])
                );

                lista.Add(rv);
            }

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Uposlenik uposlenik;
                if (dataRow["Telefon"] != null)
                {
                    uposlenik = new ProdavacKarata(
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikId"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }
                else if (dataRow["Budzet"] != null)
                {
                    uposlenik = new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }

                else
                {
                    uposlenik = new ProdavacHrane(
                    Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                    );
                }

                RadnaEvidencija evidencija = new RadnaEvidencija(
                    Convert.ToInt32(dataRow["RadnaEvidencijaID"]),
                    lista,
                    uposlenik
                );

                return evidencija;
            }

            return null;
        }

        public List<RadnaEvidencija> getAll()
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM RadnaEvidencija e, Uposlenik u WHERE e.UposlenikID = u.UposlenikID");


            //čitamo rezultate
            List<RadnaEvidencija> evidencije = new List<RadnaEvidencija>();


            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Uposlenik uposlenik;
                if (dataRow["Telefon"] != null)
                {
                    uposlenik = new ProdavacKarata(
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikId"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }
                else if (dataRow["Budzet"] != null)
                {
                    uposlenik = new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                    );
                }

                else
                {
                    uposlenik = new ProdavacHrane(
                    Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                    );
                }

                RadnaEvidencija evidencija = new RadnaEvidencija(
                    Convert.ToInt32(dataRow["RadnaEvidencijaID"]),
                    new List<RadnoVrijeme>(),
                    uposlenik
                );

                evidencije.Add(evidencija);
            }

            return evidencije;

        }

    }
}