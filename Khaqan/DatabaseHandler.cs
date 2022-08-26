using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Khaqan
{
    public class DatabaseHandler
    {
        private static readonly string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\salman.ahmad\Documents\db.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection _connection = new SqlConnection(CONNECTION_STRING);

        private static SqlCommand sqlCommand;

        public DatabaseHandler()
        {
            _connection.Open();
        }

        public int RegisterUser(string username, string password, out int registrationStatus)
        {
            string queryString;
            int queryResult;
            SqlDataReader reader;

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            queryString = string.Format("SELECT Id FROM Users WHERE Username='{0}'", username);
            reader = new SqlCommand(queryString, _connection).ExecuteReader();

            if (reader.HasRows)
            {
                return registrationStatus = -1;
            }

            else
            {
                reader.Close();

                queryString = "INSERT INTO Users (Username, Password) VALUES(@username, @password);";

                sqlCommand = new SqlCommand(queryString, _connection);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);

                queryResult = sqlCommand.ExecuteNonQuery();

                _connection.Close();

                return registrationStatus = queryResult == -1 ? 0 : 1;
            }
        }
    }
}