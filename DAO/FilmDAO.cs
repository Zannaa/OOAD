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
    public class FilmDAO : IRepository<Film>
    {

        private DatabaseManager manager;

        public FilmDAO ()
	    {
            this.manager = DatabaseManager.Instance;
	    }

        public long create(Film film)
        {
            string exec = "INSERT INTO film VALUES(" + film.ID + ", '" + film.Naziv + "', " + film.Sifra + ")";

            return manager.ExecuteSqlCommandToIntForCreate(exec);

        }

        public Film read(Film film)
        {
            // wat?
            return getById(film.ID);
        }

        public Film update(Film film)
        {
            int id = film.ID;
            string naziv = film.Naziv;
            int sifra = film.Sifra;

            string exec = "UPDATE film SET naziv = '" + naziv + "'naziv, sifra = " + sifra;
            exec += " WHERE id = " + id;

            int affectedRows = manager.ExecuteSqlCommandToInt(exec);
            return film;
        }

        public void delete(Film film)
        {
            int id = film.ID;


            int affectedRows = manager.ExecuteSqlCommandToInt("DELETE FROM film WHERE id = " + id);

        }

        public Film getById(int id)
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM dbo.Film where id = " + id);

            foreach(DataRow dataRow in data.Tables[0].Rows)
            {
                Film film = new Film(
                    Convert.ToInt32(dataRow["id"]), 
                    Convert.ToString(dataRow["naziv"]), 
                    Convert.ToInt32(dataRow["sifra"])
                );

                return film;
            }  
            
            // heh
            return null;
        }

        public List<Film> getAll()
        {

            DataSet data = manager.ExecuteSqlCommandToDataSet("SELECT * FROM film");

            List<Film> filmovi = new List<Film>();
            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                Film film = new Film(
                    Convert.ToInt32(dataRow["id"]),
                    Convert.ToString(dataRow["naziv"]),
                    Convert.ToInt32(dataRow["sifra"])
                );

                filmovi.Add(film);
            }  

            return filmovi;
        }


            
    }
}
