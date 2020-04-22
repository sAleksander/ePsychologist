using System;
using System.Windows.Input;
using ePsychologist.ViewModels.MainView;

namespace ePsychologist.ViewModels.RegisterView
{
    public class GotoLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Navigator.UpdateCurrentVMCommand.Execute(ViewType.Login);
        }
    }
}
