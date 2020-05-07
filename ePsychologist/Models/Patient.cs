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
        private int id;
        private char sex;
        #endregion
        public Patient(int id, string name, string surname,string dateofbirth, char sex)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.dateofbirth = dateofbirth;
            this.sex = sex;
        }

        public string[] GetDisplayData()
        {
            string[] conversion = new string[5];
            conversion[0] = name;
            conversion[1] = surname;
            conversion[2] = dateofbirth;
            conversion[3] = id.ToString();
            conversion[4] = sex.ToString();

            return conversion;
        }

        public override string ToString()
        {
            return $"{id}, {name}, {surname}";
        }
    }
}
