using System;
using System.Collections.Generic;
using System.Windows.Input;
using ePsychologist.ViewModels.RegisterView;

namespace ePsychologist.ViewModels
{

    public class RegisterViewModel : BasicViewModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChange(nameof(Name));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChange(nameof(Surname));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    if (value == Properties.Literals.Men)
                        sex = "M";
                    else
                        sex = "W";
                    OnPropertyChange(nameof(Sex));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }
        private DateTime dateOfBirth = DateTime.Today;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value < DateTime.Today)
                {
                    if (dateOfBirth != value)
                    {
                        dateOfBirth = value.Date;
                        OnPropertyChange(nameof(DateOfBirth));
                        ErrorLb = null;
                        SuccessLb = null;
                    }
                }
                else
                {
                    ErrorLb = Properties.Literals.InvalidData;
                }
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChange(nameof(Username));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChange(nameof(Password));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }

        private string accoundType;
        public string AccoundType
        {
            get { return accoundType; }
            set
            {
                if (accoundType != value)
                {
                    if (value == Properties.Literals.Patient)
                        accoundType = "P";
                    else
                        accoundType = "D";
                    OnPropertyChange(nameof(AccoundType));
                    ErrorLb = null;
                    SuccessLb = null;
                }
            }
        }
        private string errorLb;
        public string ErrorLb
        {
            get { return errorLb; }
            set
            {
                if (errorLb != value)
                {
                    errorLb = value;
                    OnPropertyChange(nameof(ErrorLb));
                }
            }
        }
        private string successLb;
        public string SuccessLb
        {
            get { return successLb; }
            set
            {
                if (successLb != value)
                {
                    successLb = value;
                    OnPropertyChange(nameof(SuccessLb));
                }
            }
        }

        private ICommand gotoLoginCommand;
        public ICommand Gotologin
        {
            get
            {
                if (gotoLoginCommand == null) gotoLoginCommand = new GotoLoginCommand();
                return gotoLoginCommand;
            }
        }
        private ICommand registerCommand;
        public ICommand Register
        {
            get
            {
                if (registerCommand == null) registerCommand = new RegisterCommand();
                return registerCommand;
            }
        }
    }
}
