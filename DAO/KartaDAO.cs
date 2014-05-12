using DAL;
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
    public class KartaDAO 
    {
        private DatabaseManager manager;

        public KartaDAO()
        {
            this.manager = DatabaseManager.Instance;
        }

        public long create(Karta karta)
        {
            throw new NotImplementedException();
        }

       /*public Karta read(Karta k)
        {
            return getById(k.ID);
        }*/
        
        public Karta update(Karta karta)
        {
         
            // buildamo query
            //StringBuilder QueryBuilder = new StringBuilder();
            //QueryBuilder.Append("UPDATE Karta AS k, ProdavacKarata AS pK, Kupac AS kup, Projekcija AS termin ");
           
            throw new NotImplementedException();
        }

        public void delete(Karta karta)
        {
            int id = karta.Id;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM menadzer WHERE id = " + id);
        }

        public Projekcija getById(int id)
        {
            // buildamo query
            StringBuilder QueryBuilder = new StringBuilder();
           // QueryBuilder.Append("SELECT * FROM Karta AS k, ProdavacKarata AS pK, Kupac AS kup, Projekcija AS termin WHERE k.Id = " + id);
         

            string query = QueryBuilder.ToString();

            // izvršimo query
            DataSet data = manager.ExecuteSqlCommandToDataSet(query);

            // pročitamo rezultate
            /* foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Karta karta = new Karta(
                    Convert.ToInt32(dataRow["Id"]),
                    Convert.ToInt32(dataRow["Sifra"]),
                    Convert.ToDateTime(dataRow["Vrijeme"]),
                    new Menadzer(),
                    new ProdavacKarata(
                        Convert.ToString(dataRow["Telefon"]),
                        ),
                        new Projekcija()
                
                );

                return karta;
            }
            */
            return null;
        }

        public List<Karta> getAll()
        {
            /* // buildamo query
             StringBuilder QueryBuilder = new StringBuilder();
             QueryBuilder.Append("SELECT * FROM Karta AS k, ProdavacKarata AS pK, Kupac AS kup, Projekcija AS termin WHERE k.Id = " + id);

             string query = QueryBuilder.ToString();

             // izvršimo query
             DataSet data = manager.ExecuteSqlCommandToDataSet(query);

             //čitamo rezultate
             List<Karta> karte = new List<Karta>();

             foreach (DataRow dataRow in data.Tables[0].Rows)
             {
                Karta karta = new Karta(
                     Convert.ToInt32(dataRow["Id"]),
                     Convert.ToInt32(dataRow["Sifra"]),
                     Convert.ToDateTime(dataRow["Vrijeme"]),
                     new Menadzer(),
                     new ProdavacKarata(
                         Convert.ToString(dataRow["Telefon"]),
                         ),
                         new Projekcija()
                
                 );

                 karte.Add(karta);
             }

             return karte;
         }*/
            return null;
        }
    }
}
