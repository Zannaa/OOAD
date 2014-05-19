using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseManager
    {
        // SQL konekcija
        private SqlConnection connection;
        
        // instanca DatabaseManager klase koja je statička
        private static DatabaseManager instance;
        
        // connection string
        private string ConnectionString;

        // Konstruktor DatabaseManager, privatni, jer ne treba biti omogućeno
        // instanciranje ove klase, nego će se dobavljati preko accessora instance property
        private DatabaseManager()
        {
            ConnectionString = "Data Source=(LocalDB)\\v11.0; Initial Catalog=Baza; Integrated Security=True;Pooling=False";
            connection = new SqlConnection(ConnectionString);
        }

        // get property, readonly, singleton pattern
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }
        
        // Konekcija
        private bool OpenConnection()
        {
            bool returnValue = false;
            try
            {
                connection.Open();
                returnValue = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return returnValue;
        }

        // Diskonekcija
        private bool CloseConnection()
        {
            bool returnValue = false;
            try
            {
                connection.Close();
                returnValue = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return returnValue;
        }

        // za UPDATE i DELETE
        public int ExecuteSqlCommandToInt(string command)
        {
            int numberOfRowsAffected = 0;
            try
            {
                OpenConnection();
                using (SqlCommand exec = new SqlCommand(command, connection))
                {
                    exec.CommandType = CommandType.Text;
                   
                    numberOfRowsAffected = exec.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

            return numberOfRowsAffected;
        }

        // za CREATE
        public int ExecuteSqlCommandToIntForCreate(string command)
        {
            int insertedId = 0;
            int numberOfRowsAffected = 0;

            try
            {
                OpenConnection();

                using (SqlCommand exec = new SqlCommand(command, connection))
                {
                    exec.CommandType = CommandType.Text;
                    
                    numberOfRowsAffected = exec.ExecuteNonQuery();



                    // nisu stored procedure, pa nećemo ovo dirati, za sad
                    // insertedId = Convert.ToInt32(exec.Parameters["@InsertedId"].Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        
        public DataSet ExecuteSqlCommandToDataSet(string query)
        {
            DataSet resultSet = new DataSet();
            try
            {
                OpenConnection();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    
                    IDataAdapter dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(resultSet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return resultSet;
        }
        
    }
}
