using System.Security;
using System.Windows.Input;
using ePsychologist.Models;
using ePsychologist.ViewModels.LoginView;

namespace ePsychologist.ViewModels
{
    public class LoginViewModel : BasicViewModel
    {
        public LoginViewModel() { }
        private User user=new User();
        public string Username
        {
            get { return user.Username; }
            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
                    OnPropertyChange(nameof(Username));
                    
                }
            }
        }

        public SecureString Password
        {
            get { return user.Password; }
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    OnPropertyChange("Password");
                }
            }
        }
        

        private ICommand clearCommand;
        public ICommand Clear
        {
            get
            {
                if (clearCommand == null) clearCommand = new ClearCommand();
                return clearCommand;
            }
        }
    }
}
