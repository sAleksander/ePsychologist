using System.Windows.Input;

namespace ePsychologist.ViewModels.MainView
{
    public enum ViewType 
    {
        Login,
        Register,
        HomeDoctor,
        HomePatient
    }
    public interface INavigator
    {
        BasicViewModel CurrentVM { get; set;}
        ICommand UpdateCurrentVMCommand { get; }
    }
}
