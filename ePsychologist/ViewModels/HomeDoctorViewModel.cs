using ePsychologist.Models;
using ePsychologist.ViewModels.MainView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ePsychologist.ViewModels
{
    class HomeDoctorViewModel : BasicViewModel
    {
        private modelDoctor MODEL;
        public HomeDoctorViewModel()
        {
            MODEL = new modelDoctor();
            Refresh();
        }

        private void Refresh()
        {
            PatientList = MODEL.GetPatients("");
        }

        private string[] _patientList;
        public string[] PatientList
        {
            get
            {
                return _patientList;
            }
            set
            {
                _patientList = value;
                OnPropertyChange(nameof(PatientList));
            }
        }

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
                return _patientSurname;
            }
            set
            {
                _patientSurname = value;
                OnPropertyChange(nameof(PatientSurname));
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

        private int _index = -1;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChange(nameof(Index));
            }
        }

        private ICommand _getPatientInfo;
        public ICommand GetPatientInfo
        {
            get
            {
                if (_getPatientInfo == null)
                {
                    _getPatientInfo = new RelayCommand(
                        x =>
                        {
                            if (Index != -1)
                            {
                                trueIndex = Index;
                                string[] temp = MODEL.GetPatientInfo(Index);
                                PatientName = temp[0];
                                PatientSurname = temp[1];
                                PatientBirth = temp[2];
                                PatientId = temp[3];
                                PatientSex = temp[4];
                                PatientIll = temp[5];

                            }
                        },
                        x =>
                        {
                            return true;
                        }
                        );

                }
                return _getPatientInfo;
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
                            PatientList = MODEL.GetPatients(NameSearch);
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

        private ICommand _resetSearch = null;
        public ICommand ResetSearch
        {
            get
            {
                if (_resetSearch == null)
                {
                    _resetSearch = new RelayCommand(
                        x =>
                        {
                            PatientList = MODEL.GetPatients("");
                            NameSearch = "";
                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _resetSearch;
            }
        }

        private int trueIndex = 0;
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
                            MODEL.AnalizePatient(trueIndex);
                            string[] temp = MODEL.GetPatientInfo(Index);
                            PatientName = temp[0];
                            PatientSurname = temp[1];
                            PatientBirth = temp[2];
                            PatientId = temp[3];
                            PatientSex = temp[4];
                            PatientIll = temp[5];
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

        private ICommand _logOut = null;
        public ICommand LogOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(
                        x =>
                        {
                            MainViewModel.Navigator.UpdateCurrentVMCommand.Execute(ViewType.Login);
                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _logOut;
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
                            Test = "Zmieniłem się :)";
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
