using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ePsychologist.ViewModel.LoginView
{
    public class ClearCommand : ICommand
    {
        LoginViewModel ViewModel { set; get; }

        public ClearCommand(LoginViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {//if true enable button
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.Clear();
        }
    }
}
