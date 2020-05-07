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
    }
}
