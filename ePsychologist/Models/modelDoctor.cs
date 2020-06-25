using Microsoft.Win32;
using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            Bitmap[] brainConversion = DATABASE.getPatientsBrainScans(parameter);
            if (patientConversion[0][0] == "Err404")
            {
                return;
            }
            int height = patientConversion.Length;
            Debug.WriteLine("mozgi zrefreshowane");
            int width = patientConversion[0].Length; patients = new List<Patient>();
            for (int i = 0; i < height; i++)
            {
                Patient newPatient = new Patient(patientConversion[i][0], patientConversion[i][1], patientConversion[i][2], patientConversion[i][3], patientConversion[i][4], patientConversion[i][5], brainConversion[i]);
                patients.Add(newPatient);
            }
        }

        public void AnalizePatient(int index)
        {
            if (patients.ElementAt(index) != null)
            {
                if (patients.ElementAt(index).GetBrainScan() == null)
                {
                    Debug.WriteLine("zdjecie jest nullem!");
                    return;
                }
                int result = AI.Calculate(
                    patients.ElementAt(index).GetAge(),
                    patients.ElementAt(index).GetSex(),
                    patients.ElementAt(index).GetBrainScan()
                    );
                DATABASE.setDiagnoze(
                    patients.ElementAt(index).GetId(),
                    result
                    );
                refreshPatients("");
            }

            Debug.WriteLine("wykonane");
        }

        public void SetBrainScan(int index)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == true)
            {
                string fullFileName = OFD.FileName;
                Debug.WriteLine(fullFileName);
                if (fullFileName.Contains(".png"))
                {
                    byte[] rawData = File.ReadAllBytes(fullFileName);
                    if (rawData == null)
                    {
                        Debug.WriteLine("nie tak mialo byc");
                    }
                    Debug.WriteLine(patients.ElementAt(index).GetId());
                    DATABASE.setBrainScan(patients.ElementAt(index).GetId(), rawData);
                }
                else
                {
                    Debug.WriteLine("nie poprawny plik!");
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
            return result;
        }

        public string[] GetPatientInfo(int index)
        {
            return patients[index].GetDisplayData();
        }
    }
}
