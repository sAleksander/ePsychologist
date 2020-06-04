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
            if (vm.ErrorLb != Properties.Literals.InvalidData)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            RegisterViewModel vm = (RegisterViewModel)parameter;
            if (vm != null)
            {
                Connection con = Connection.DbConnection;
                try
                {
                    if (!(string.IsNullOrEmpty(vm.Name) || string.IsNullOrEmpty(vm.Surname) || string.IsNullOrEmpty(vm.Username) || string.IsNullOrEmpty(vm.Password)))
                        con.Register(vm.Name, vm.Surname, vm.Sex.ToCharArray()[0], vm.DateOfBirth.ToString("yyyy-MM-dd"), vm.Username, vm.Password, vm.AccoundType.ToCharArray()[0]);
                    else
                        throw new Exception(Properties.Literals.InvalidData);
                    vm.SuccessLb = Properties.Literals.Success;
                }
                catch (Exception e)
                {
                    vm.ErrorLb = e.Message;
                }
            }
        }
    }
}
