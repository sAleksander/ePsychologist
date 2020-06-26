using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.Models
{
    class ModelPatient
    {

        private Connection con;
        private string[] patient;
        public ModelPatient()
        {
            con = Connection.DbConnection;
            patient = con.getOnePatient(con.GetUserID());
        }


        public string getName()
        {
            return patient[0];
        }
        public string getSurname()
        {
            return patient[1];
        }
        public string getDateOfBirth()
        {
            return patient[2];
        }
        public string getSex()
        {
            return patient[3];
        }

        public string getDiagnosis()
        {
            return patient[4];
        }

        public void updatePatientInfo(string name, string surname, string dateOfBirth, string sex)
        {
            con.UpdatePatientInfo(con.GetUserID(), name, surname, sex, dateOfBirth);
        }

    }
}
