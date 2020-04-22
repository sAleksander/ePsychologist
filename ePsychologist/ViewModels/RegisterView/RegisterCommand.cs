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
            if (vm.ErrorLb != "Invaild data")
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
                try
                {
                    if (!(string.IsNullOrEmpty(vm.Name) || string.IsNullOrEmpty(vm.Surname) || string.IsNullOrEmpty(vm.Username) || string.IsNullOrEmpty(vm.Password)))
                        con.Register(vm.Name, vm.Surname, vm.Sex, vm.DateOfBirth.ToString("yyyy-MM-dd"), vm.Username, vm.Password, vm.AccoundType);
                    else
                        throw new Exception("Invaild data");
                    vm.SuccessLb = "Success!";
                }
                catch(Exception e)
                {
                    if (e.Message == "Invaild data")
                        vm.ErrorLb = $"Invaild data {e}";
                    else
                        vm.ErrorLb = "Connection failed";
                }
            }
        }
    }
}
