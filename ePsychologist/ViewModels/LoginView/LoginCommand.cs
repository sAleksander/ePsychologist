using System;
using System.Windows.Input;
using ePsychologist.Models;
using ePsychologist.ViewModels.MainView;

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
                    Connection connection = Connection.DbConnection;
                    viewModel.Error = "";
                    char userType = connection.Login(viewModel.Username,viewModel.Password);
                    if(userType == 'D')
                        MainViewModel.Navigator.UpdateCurrentVMCommand.Execute(ViewType.HomeDoctor);
                    else
                        MainViewModel.Navigator.UpdateCurrentVMCommand.Execute(ViewType.HomePatient);
                }
                catch(Exception e)
                {
                    if(e.Message == Properties.Literals.WrongUsernameOrPassword)
                        viewModel.Error = Properties.Literals.WrongUsernameOrPassword;
                    else
                        viewModel.Error = Properties.Literals.DBError;
                }
                
            }
        }
    }
}
