using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ePsychologist.ViewModels
{
    class HomeDoctorViewModel : BasicViewModel
    {

        private string _patientName = "Name not found!";
        public string PatientName
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientName = value;
                OnPropertyChange(nameof(PatientName));
            }
        }
        private string _patientSurname = "Surname not found!";
        public string PatientSurname
        {
            get
            {
                return _patientName;
            }
            set
            {
                _patientSurname = value;
                OnPropertyChange(nameof(PatientName));
            }
        }
        private string _patientSex = "Sex not recognized!";
        public string PatientSex
        {
            get
            {
                return _patientSex;
            }
            set
            {
                _patientSex = value;
                OnPropertyChange(nameof(PatientSex));
            }
        }
        private string _patientBirth = "Birth date not found!";
        public string PatientBirth
        {
            get
            {
                return _patientBirth;
            }
            set
            {
                _patientBirth = value;
                OnPropertyChange(nameof(PatientBirth));
            }
        }
        private string _patientIll = "Diagnose not found!";
        public string PatientIll
        {
            get
            {
                return _patientIll;
            }
            set
            {
                _patientIll = value;
                OnPropertyChange(nameof(PatientIll));
            }
        }

        private string _patientId = "Id not found!";
        public string PatientId
        {
            get
            {
                return _patientId;
            }
            set
            {
                _patientId = value;
                OnPropertyChange(nameof(PatientId));
            }
        }

        private string _nameSearch = "";
        public string NameSearch
        {
            get
            {
                return _nameSearch;
            }
            set
            {
                _nameSearch = value;
                OnPropertyChange(nameof(NameSearch));
            }
        }

        private string _suraneSearch = "";
        public string SurnameSearch
        {
            get
            {
                return _suraneSearch;
            }
            set
            {
                _suraneSearch = value;
                OnPropertyChange(nameof(SurnameSearch));
            }
        }


        private ICommand _search = null;
        public ICommand Search
        {
            get
            {
                if (_search == null)
                {
                    _search = new RelayCommand(
                        x =>
                        {

                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _search;
            }
        }

        private ICommand _reAnalize = null;
        public ICommand ReAnalize
        {
            get
            {
                if (_reAnalize == null)
                {
                    _reAnalize = new RelayCommand(
                        x =>
                        {

                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _reAnalize;
            }
        }

        private string _test = "lets change it!";
        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                OnPropertyChange(nameof(Test));
            }
        }
        private ICommand _testClick = null;
        public ICommand TestClick
        {
            get
            {
                if (_testClick == null)
                {
                    _testClick = new RelayCommand(
                        x =>
                        {
                            Test = "A wlasnie se zmienilem o :)";
                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _testClick;
            }
        }
    }
}
