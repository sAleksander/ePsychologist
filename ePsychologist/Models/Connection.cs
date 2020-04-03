using System;
using MySql.Data.MySqlClient;

namespace ePsychologist.Models
{
    public class Connection
    {
        private int userID;
        // 'l' lekarz, 'p' pacjent
        private char userType;

        private MySqlConnection cnn;
        private static Connection dbConnection;
        public Connection()
        {
            String connetionString = @"host=83.230.14.31;port=12345;user id=user;password=heheszki;database=schizofrenia;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
        }
        public static Connection DbConnection
        {
            get
            {
                if (dbConnection == null)
                    dbConnection = new Connection();
                return dbConnection;
            }
        }

        public char Login(string username, string password)
        {
            string query = $"SELECT id_u, users.type FROM users WHERE username = '{username}' AND password = '{password}';";
            using (MySqlCommand command = new MySqlCommand(
                query,cnn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.HasRows)
                    {
                        userID = Convert.ToInt32(reader[0].ToString());
                        userType = reader[1].ToString()[0];
                    }
                    else
                        throw new Exception("Wrong username or password");
                }
            }
            return userType;

        }

    }
}
