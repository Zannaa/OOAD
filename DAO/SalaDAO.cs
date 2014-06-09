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
   public  class SalaDAO: IRepository<Sala>
    {

       private DatabaseManager manager;

        public SalaDAO()
        {
            this.manager = DatabaseManager.Instance;
        }


        public long create(Sala sala) {

            string exec = "INSERT INTO sala VALUES(" + sala.Kapacitet + ", " + sala.Sjediste + ", " + sala.Sjedista + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        
        }

        public Sala read(Sala s)
        {
            return getById(s.ID);
        }



        public Sala getById(int id) {
            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM sala where SalaId = " + id);

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Sala sala = new Sala(

                    Convert.ToInt32(dataRow["SalaId"]),
                    Convert.ToInt32(dataRow["sjediste"]),
                    Convert.ToInt32(dataRow["kapacitet"]),
                    null
                   
                );

                return sala;
            }

         
            return null;
        
        }

        public List<Sala> getAll()
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM sala");

            List<Sala> sale = new List<Sala>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Sala sala = new Sala(
                    Convert.ToInt32(dataRow["SalaId"]),
                    Convert.ToInt32(dataRow["sjediste"]),
                    Convert.ToInt32(dataRow["kapacitet"]),
                    null
                );

                sale.Add(sala);
            }

            return sale;
        }
        public Sala update(Sala sala)
        {
            int id = sala.ID;
            int sjediste = sala.Sjediste;
            int kapacitet = sala.Kapacitet;
            List<int> lista = null;

            string exec = "UPDATE film SET SalaId = '" + id + "', sjedite = " + sjediste + "kapacitet =" + kapacitet + "sjedista= " + lista;
            exec += " WHERE SalaId = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return sala;
        }

        public void delete(Sala sala)
        {
            int id = sala.ID;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM sala WHERE SalaId = " + id);

        }

      


       


    }
}
