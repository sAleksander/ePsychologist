using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.Models
{
    class modelDoctor
    {
        #region fields
        private List<Patient> patients = new List<Patient>();
        private Connection DATABASE;
        private string[][] patientConversion;
        #endregion

        public modelDoctor()
        {
            DATABASE = Connection.DbConnection;
        }

        private void refreshPatients(string parameter)
        {

            patientConversion = DATABASE.getPatients(parameter);
            if (patientConversion[0][0] == "Err404")
            {
                return;
            }
            int height = patientConversion.Length;
            int width = patientConversion[0].Length; // potencjalny problem jesli nie ma zadnego pacjenta w bazie
            patients = new List<Patient>();
            for (int i = 0; i < height; i++)
            {
                Patient newPatient = new Patient(patientConversion[i][0], patientConversion[i][1], patientConversion[i][2], patientConversion[i][3], patientConversion[i][4], patientConversion[i][5]);
                patients.Add(newPatient);
            }
        }

        public void AnalizePatient(int index)
        {
            if (patients.ElementAt(index) != null)
            {
                int healthy = 20;
                int ill = 80;
                int result = AI.Calculate(
                    patients.ElementAt(index).GetAge(),
                    patients.ElementAt(index).GetSex(),
                    patients.ElementAt(index).GetBrainScan()
                    );
                if (result < healthy)
                {
                    DATABASE.setDiagnoze(
                        patients.ElementAt(index).GetId(),
                        "Pacjent jest zdrowy"
                        );
                }
                else if (result > ill)
                {
                    DATABASE.setDiagnoze(
                        patients.ElementAt(index).GetId(),
                        "Duże prawdopodobieństwo Shizofremi"
                        );
                }
                else
                {
                    DATABASE.setDiagnoze(
                        patients.ElementAt(index).GetId(),
                        "Pomiar nie pewny brak diagnozy"
                        );
                }
                refreshPatients("");
            }
        }

        public string[] GetPatients(string parameter)
        {
            refreshPatients(parameter);
            string[] result = new string[patients.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = patients[i].ToString();
            }
            return result; // potencjalny problem jesli brak pacjentow w bazie
        }

        public string[] GetPatientInfo(int index)
        {
            return patients[index].GetDisplayData();
        }
    }
}
