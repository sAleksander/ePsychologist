﻿using System.Security;
using System.Windows.Input;
using ePsychologist.ViewModels.LoginView;
using ePsychologist.ViewModels.MainView;

namespace ePsychologist.ViewModels
{
    public class LoginViewModel : BasicViewModel
    {
        public LoginViewModel() { }

        public INavigator Navigator { get; set; } = new Navigator();

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
                    OnPropertyChange("Password");
                }
            }
        }

        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                if (error != value)
                {
                    error = value;
                    OnPropertyChange(nameof(Error));

                }
            }
        }

        private ICommand clearCommand;
        public ICommand Clear
        {
            get
            {
                if (clearCommand == null) clearCommand = new ClearCommand();
                return clearCommand;
            }
        }

        private ICommand loginCommand;
        public ICommand Login
        {
            get
            {
                if (loginCommand == null) loginCommand = new LoginCommand();
                return loginCommand;
            }
        }
    }
}
