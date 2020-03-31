using System.Windows.Input;
using ePsychologist.ViewModels.RegisterView;

namespace ePsychologist.ViewModels
{
    public class RegisterViewModel : BasicViewModel
    {

        private ICommand gotoLoginCommand;
        public ICommand Gotologin
        {
            get
            {
                if (gotoLoginCommand == null) gotoLoginCommand = new GotoLoginCommand();
                return gotoLoginCommand;
            }
        }
    }
}
