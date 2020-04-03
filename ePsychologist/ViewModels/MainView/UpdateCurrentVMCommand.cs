using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ePsychologist.ViewModels.MainView
{
    class UpdateCurrentVMCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;
        public UpdateCurrentVMCommand(INavigator navigator)
        {
            _navigator = navigator;
        } 

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Login:
                        _navigator.CurrentVM =new LoginViewModel();
                        break;
                    case ViewType.Register:
                        _navigator.CurrentVM = new LoginViewModel();
                        break;
                    case ViewType.HomePatient:
                        _navigator.CurrentVM = new HomePatientViewModel();
                        break;
                    case ViewType.HomeDoctor:
                        _navigator.CurrentVM = new HomeDoctorViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
