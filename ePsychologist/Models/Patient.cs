using System;
using System.Collections.Generic;
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
        #endregion
        public Patient(string id, string name, string surname,string dateofbirth, string sex)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateofbirth = dateofbirth;
            this.sex = sex;
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
            string[] conversion = new string[5];
            conversion[0] = name;
            conversion[1] = surname;
            conversion[2] = dateofbirth;
            conversion[3] = id;
            conversion[4] = sex;

            return conversion;
        }

        public override string ToString()
        {
            return $"{id}, {name}, {surname}";
        }
    }
}
