﻿using System;
using System.Text;
using MySql.Data.MySqlClient;

namespace ePsychologist.Models
{
    public class Connection
    {
        private int userID;
        // 'D' lekarz, 'P' pacjent
        private char userType;

        private MySqlConnection cnn;
        private static Connection dbConnection;
        public Connection()
        {
            String connetionString = $"host={ePsychologist.Properties.Resources.DB_HOST};port={ePsychologist.Properties.Resources.DB_PORT};user id={ePsychologist.Properties.Resources.DB_USER};password={ePsychologist.Properties.Resources.DB_PASS};database={ePsychologist.Properties.Resources.DB};";
            cnn = new MySqlConnection(@connetionString);
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
            var hashedPassword = Hash.GenerateSaltedHash(password, username);

            string query = $"SELECT id_u, users.type FROM users WHERE username = '{username}' AND password = '{hashedPassword}';";
            using (MySqlCommand command = new MySqlCommand(
                query, cnn))
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

        public void Register(string name, string surname, char sex, string dateOfBirth, string username, string password, char accoundType)
        {
            var hashedPassword = Hash.GenerateSaltedHash(password, username);

            MySqlCommand command1 = new MySqlCommand($"Insert into users(username, password, type) values('{username}', '{hashedPassword}' ,'{accoundType}'); ", cnn);
            try
            {
                command1.ExecuteNonQuery();
                using (MySqlCommand command2 = new MySqlCommand(
                $"SELECT id_u, users.type FROM users WHERE username = '{username}' AND password = '{hashedPassword}';", cnn))
                {
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                            userID = Convert.ToInt32(reader[0].ToString());
                    }

                }
                MySqlCommand command3 = new MySqlCommand($"Insert into personals(id_u, name, surname, sex, date_of_birth) values('{userID}','{name}', '{surname}',  '{sex}', '{dateOfBirth}'); ", cnn);
                command3.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Invaild data");
            }
        }

    }
}
