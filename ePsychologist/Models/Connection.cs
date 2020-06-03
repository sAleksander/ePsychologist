using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace ePsychologist.Models
{
    public class Connection
    {
        private int userID = 404;
        // 'D' lekarz, 'P' pacjent
        private char userType;

        private MySqlConnection cnn;
        private static Connection dbConnection;
        private Connection()
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

        public int GetUserID()
        {
            return userID;
        }
        public string[] getOnePatient(int userId)
        {
            string query = $"SELECT Name, Surname, Date_of_birth, Sex, Diagnosis FROM personals WHERE id_u = {userId};";
            using (MySqlCommand command = new MySqlCommand(query, cnn))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    string[] patientData = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        patientData[i] = reader[i].ToString();
                    }

                    if (patientData[4].Equals(""))
                        patientData[4] = "Oczekuje na diagnozę";
                    else if (patientData[4].Equals("Pacjent jest zdrowy"))
                        patientData[4] = "Jesteś zdrowy";
                    else
                        patientData[4] = "Jesteś chory na schizofrenie";


                    return patientData;

                }
            }
        }

        public void UpdatePatientInfo(int userId, string name, string surname, string sex, string dateOfBirth)
        {
            string query = $"UPDATE personals SET name = '{name}', surname ='{surname}', sex = '{sex}', date_of_birth='{dateOfBirth}' WHERE id_u={userId}";
            using (MySqlCommand command = new MySqlCommand(query, cnn))
            {
                command.ExecuteNonQuery();
            }
        }

        public void setDiagnoze(int userId, string results)
        {
            string query = $"UPDATE personals SET diagnosis = '{results}' WHERE id_u ={userId};";
            using (MySqlCommand command = new MySqlCommand(query, cnn))
            {
                command.ExecuteNonQuery();
            }
        }

        public void setBrainScan(int chosenUserId, byte[] brainScan)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = cnn;
                command.CommandText = $"UPDATE personals SET images = ?brainScan WHERE id_p = {chosenUserId};";
                Debug.WriteLine(command.CommandText);
                MySqlParameter fileContentParameter = new MySqlParameter("?brainScan", MySqlDbType.LongBlob, brainScan.Length);
                fileContentParameter.Value = brainScan;
                command.Parameters.Add(fileContentParameter);
                command.ExecuteNonQuery();
            }
        }

        public Bitmap[] getPatientsBrainScans(string searchParameter)
        {
            string query = $"SELECT images FROM personals;";
            if (searchParameter != "")
            {
                query = $"SELECT images FROM personals WHERE Name Like '%{searchParameter}%';";
            }
            using (MySqlCommand command = new MySqlCommand(
                query, cnn))
            {
                int amount = 0;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            amount++;
                        }
                    }
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int j = 0;
                    Bitmap[] patienBase = new Bitmap[amount];
                    while (reader.Read())
                    {
                        byte[] converter = reader[0] as byte[];
                        if (converter == null)
                        {
                            patienBase[j] = null;
                        }
                        else
                        {
                            using (var ms = new MemoryStream(converter))
                            {
                                patienBase[j] = new Bitmap(ms);
                            }
                        }
                        j++;
                    }
                    return patienBase;
                }
            }
        }


        public string[][] getPatients(string searchParameter)
        {
            string query = $"SELECT id_u, Name, Surname, Date_of_birth, Sex, diagnosis FROM personals;";
            if (searchParameter != "")
            {
                query = $"SELECT id_u, Name, Surname, Date_of_birth, Sex, diagnosis FROM personals WHERE Name Like '%{searchParameter}%';";
            }
            using (MySqlCommand command = new MySqlCommand(
                query, cnn))
            {
                int amount = 0;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            amount++;
                        }
                    }
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int j = 0;
                    if (reader.HasRows)
                    {
                        string[][] patienBase = new string[amount][];
                        while (reader.Read())
                        {
                            string[] newRow = new string[6];
                            for (int i = 0; i < 5; i++)
                            {
                                newRow[i] = reader[i].ToString();
                            }
                            if (reader[5].ToString() == "" || reader[5].ToString() == null)
                            {
                                newRow[5] = "Nie zdiagnozowany";
                            }
                            else
                            {
                                newRow[5] = reader[5].ToString();
                            }
                            for (int i = 0; i < 5; i++)
                            {
                            }
                            patienBase[j] = newRow;
                            j++;
                        }
                        return patienBase;
                    }
                    else
                    {
                        string[][] patienBase = new string[1][];
                        patienBase[0] = new string[1];
                        patienBase[0][0] = "Err404";
                        return patienBase;
                    }
                }
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
