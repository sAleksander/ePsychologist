using System;
using System.Windows.Input;
using ePsychologist.Models;

namespace ePsychologist.ViewModels.LoginView
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {//if true enable button
            return true;
        }

        public void Execute(object parameter)
        {
            LoginViewModel viewModel = parameter as LoginViewModel;
            if (viewModel != null)
            {
                string login = viewModel.Username;
                string password = viewModel.Password;
                try
                {
                    Connection connection = new Connection();
                }
                catch
                {
                    viewModel.Error = "Connection failed";
                }
                
            }
        }
    }
}
