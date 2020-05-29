using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.Models
{
    class Patient
    {
        #region fields
        private string name;
        private string surname;
        private string dateofbirth;
        private string id;
        private string sex;
        private string diagnose;
        private Bitmap brainScan;
        #endregion
        public Patient(string id, string name, string surname,string dateofbirth, string sex)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateofbirth = dateofbirth;
            this.sex = sex;
            brainScan = null;
            this.diagnose = "brak";
        }

        public Patient(string id, string name, string surname, string dateofbirth, string sex, string diagnose, Bitmap brainScan)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateofbirth = dateofbirth;
            this.sex = sex;
            this.diagnose = diagnose;
            this.brainScan = brainScan;
        }

        public string Diagnose
        {
            set
            {
                diagnose = value;
            }
        }


        public string[] GetDisplayData()
        {
            string[] conversion = new string[6];
            conversion[0] = name;
            conversion[1] = surname;
            conversion[2] = dateofbirth;
            conversion[3] = id;
            conversion[4] = sex;
            conversion[5] = diagnose;

            return conversion;
        }

        public int GetAge()
        {
            DateTime conversion = DateTime.Parse(dateofbirth);
            int currentYear = DateTime.Now.Year;
            int age = currentYear - conversion.Year;
            return age;
        }

        public string GetSex()
        {
            if (sex == "M")
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        public Bitmap GetBrainScan()
        {
            return brainScan;
        }

        public int GetId()
        {
            return int.Parse(id);
        }

        public override string ToString()
        {
            return $"{id}, {name}, {surname}";
        }
    }
}
