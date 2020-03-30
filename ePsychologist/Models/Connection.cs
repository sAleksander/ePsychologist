using System;
using MySql.Data.MySqlClient;

namespace ePsychologist.Models
{
    public class Connection
    {
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

        private int userID;

    }
}
