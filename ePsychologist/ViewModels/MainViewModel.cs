using ePsychologist.ViewModels.MainView;

namespace ePsychologist.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        public MainViewModel() { Navigator.UpdateCurrentVMCommand.Execute(ViewType.Login); }
        public static INavigator Navigator { get; set; } = new Navigator();
    }
}
