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
            patientConversion = DATABASE.getPatients();
            int height = patientConversion.Length;
            int width = patientConversion[0].Length; // potencjalny problem jesli nie ma zadnego pacjenta w bazie

            for (int i = 0; i < height; i++)
            {
                Patient newPatient = new Patient(patientConversion[i][0], patientConversion[i][1], patientConversion[i][2], patientConversion[i][3], patientConversion[i][4]);
                patients.Add(newPatient);
            }
        }

        public string[] GetPatients()
        {
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
