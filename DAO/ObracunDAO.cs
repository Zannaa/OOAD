﻿using DAL;
using DAO.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ObracunDAO : IRepository<Obracun>
    {
        private DatabaseManager manager;

        public ObracunDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Obracun obracun)
        {
            throw new NotImplementedException();
        }

        public Obracun read(Obracun o)
        {
            return getById(o.Id);
        }

        public Obracun update(Obracun obracun)
        {
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("UPDATE Obracun AS o");
            QueryBuilder.Append("SET o.ObracunId = " + obracun.Id + ", ");
            QueryBuilder.Append("o.Datum = " + obracun.Datum + ", ");
            QueryBuilder.Append("o.Obracunao = " + obracun.Obracunao.Id_uposlenika + ", ");
            QueryBuilder.Append("o.UposlenikID =" + obracun.Uposlenik.Id_uposlenika);

            throw new NotImplementedException();

        }

        public void delete(Obracun obracun)
        {
            int id = obracun.Id;

            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM Obracun WHERE ObracunId = " + id);
        }

        public Obracun getById(int id)
        {
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Obracun AS o, Uposlenik AS u WHERE o.ObracunId = " + id);
            QueryBuilder.Append(" AND u.UposlenikID = o.UposlenikID");


            string query = QueryBuilder.ToString();

            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Uposlenik uposlenik;
                if (dataRow["u.Budzet"] != null)
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

                else if (dataRow["u.Telefon"] != null)
                {
                    uposlenik = new ProdavacKarata(
                     Convert.ToString(dataRow["telefon"]),
                     Convert.ToString(dataRow["ime"]),
                     Convert.ToString(dataRow["prezime"]),
                     Convert.ToString(dataRow["jmbg"]),
                     Convert.ToInt32(dataRow["UposlenikID"]),
                     Convert.ToDouble(dataRow["koeficijent"])
                     );
                }
                else
                {
                    uposlenik = new ProdavacHrane(Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                        );
                }

                Obracun obracun = new Obracun(
                    Convert.ToInt32(dataRow["ObracunId"]),
                    new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                        ),
                    Convert.ToDateTime(dataRow["Datum"]),
                    uposlenik
                );

                return obracun;
            }

            return null;
        }

        public List<Obracun> getAll()
        {
            StringBuilder QueryBuilder = new StringBuilder();
            QueryBuilder.Append("SELECT * FROM Obracun AS o, Uposlenik AS u");
            QueryBuilder.Append("  u.UposlenikId = o.UposlenikID");

            string query = QueryBuilder.ToString();

            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            List<Obracun> obracuni = new List<Obracun>();

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Uposlenik uposlenik;
                if (dataRow["u.Budzet"] != null)
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

                else if (dataRow["u.Telefon"] != null)
                {
                    uposlenik = new ProdavacKarata(
                     Convert.ToString(dataRow["telefon"]),
                     Convert.ToString(dataRow["ime"]),
                     Convert.ToString(dataRow["prezime"]),
                     Convert.ToString(dataRow["jmbg"]),
                     Convert.ToInt32(dataRow["UposlenikID"]),
                     Convert.ToDouble(dataRow["koeficijent"])
                     );
                }
                else
                {
                    uposlenik = new ProdavacHrane(Convert.ToString(dataRow["pult"]),
                    Convert.ToString(dataRow["ime"]),
                    Convert.ToString(dataRow["prezime"]),
                    Convert.ToString(dataRow["jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["koeficijent"])
                        );
                }

                Obracun obracun = new Obracun(
                    Convert.ToInt32(dataRow["ObracunId"]),
                    new FinansijskiMenadzer(
                    Convert.ToDouble(dataRow["Budzet"]),
                    Convert.ToString(dataRow["Telefon"]),
                    Convert.ToString(dataRow["Ime"]),
                    Convert.ToString(dataRow["Prezime"]),
                    Convert.ToString(dataRow["Jmbg"]),
                    Convert.ToInt32(dataRow["UposlenikID"]),
                    Convert.ToDouble(dataRow["Koeficijent"])
                        ),
                    Convert.ToDateTime(dataRow["Datum"]),
                    uposlenik
                );

                obracuni.Add(obracun);
            }
            return obracuni;
        }
    }
}

