using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.ViewModels
{
    using ePsychologist.ViewModels.MainView;
    using Models;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;

    class HomePatientViewModel : BasicViewModel
    {
        private ModelPatient model;
        public HomePatientViewModel()
        {
            model = new ModelPatient();
            refresh();
        }

        private void refresh()
        {
            PatientName = model.getName();
            PatientSurname = model.getSurname();
            PatientGender = model.getSex();
            PatientBirthday = Convert.ToDateTime(model.getDateOfBirth());
            SicknessInfo = model.getDiagnosis();
        }

        private string _patientName;
        public string PatientName
        {
            get { return _patientName; }
            set
            {
                _patientName = value;
                OnPropertyChange(nameof(_patientName));
            }
        }

        private string _patientSurname;
        public string PatientSurname
        {
            get { return _patientSurname; }
            set
            {
                _patientSurname = value;
                OnPropertyChange(nameof(_patientSurname));
            }
        }

        private DateTime _patientBirthday;
        public DateTime PatientBirthday
        {
            get { return _patientBirthday; }
            set
            {
                _patientBirthday = value;
                OnPropertyChange(nameof(_patientBirthday));
            }
        }

        private string _patientGender;
        public string PatientGender
        {
            get { return _patientGender; }
            set
            {
                _patientGender = value;
                OnPropertyChange(nameof(_patientGender));
            }
        }

        private string _sicknessInfo;
        public string SicknessInfo
        {
            get { return _sicknessInfo; }
            set
            {
                _sicknessInfo = value;
                OnPropertyChange(nameof(_sicknessInfo));
            }
        }



        private ICommand _confirmChanges = null;
        public ICommand ConfirmChanges
        {
            get
            {
                if (_confirmChanges == null)
                {
                    _confirmChanges = new RelayCommand(
                        x =>
                        {
                            model.updatePatientInfo(PatientName,PatientSurname,PatientBirthday.ToString("yyyy-MM-dd"),PatientGender);
                        },
                        x =>
                        {
                            return true;
                        }
                        );
                }
                return _confirmChanges;
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

    }
}

