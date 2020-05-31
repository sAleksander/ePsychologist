using System;
using System.Windows.Input;
using NeuralNetwork;

namespace ePsychologist.ViewModels.LoginView
{
    public class ClearCommand : ICommand
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
                viewModel.Password = "";
                viewModel.Username = "";
            }
        }
    }
}
