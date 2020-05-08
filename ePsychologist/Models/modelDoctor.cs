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
        Connection DATABASE;
        public modelDoctor()
        {
            DATABASE = Connection.DbConnection;
            DATABASE.getPatients();
        }
        #endregion
    }
}
