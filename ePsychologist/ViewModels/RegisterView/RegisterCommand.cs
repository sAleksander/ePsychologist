using System;
using System.Windows.Input;
using ePsychologist.Models;

namespace ePsychologist.ViewModels.RegisterView
{
    public class RegisterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            RegisterViewModel vm = (RegisterViewModel)parameter;
            if (vm.ErrorLb == null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            RegisterViewModel vm = (RegisterViewModel)parameter;
            if (vm != null)
            {
                Connection con = new Connection();
                char sex, acType;
                if (vm.Sex == "Woman")
                    sex = 'w';
                else
                    sex = 'm';
                if (vm.AccoundType == "Patient")
                    acType = 'P';
                else
                    acType = 'D';
                try
                {
                    if (vm.Name != "" || vm.Surname != "" || vm.Username != "" || vm.Password != "")
                        con.Register(vm.Name, vm.Surname, sex, vm.DateOfBirth.ToString("yyyy-MM-dd"), vm.Username, vm.Password, acType);
                    else
                        throw new Exception("Invaild data");
                    vm.SuccessLb = "Success!";
                }
                catch(Exception e)
                {
                    if (e.Message == "Invaild data")
                        vm.ErrorLb = "Invaild data";
                    else
                        vm.ErrorLb = "Connection failed";
                }
            }
        }
    }
}
