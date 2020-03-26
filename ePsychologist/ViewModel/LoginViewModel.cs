using ePsychologist.ViewModel.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.ViewModel
{
    public class LoginViewModel
    {

        public  ClearCommand ClearCommand { get; set; }
        public LoginViewModel()
        {
            this.ClearCommand = new ClearCommand(this);
        }

        
        public void Clear()
        {

        }
    }
}
