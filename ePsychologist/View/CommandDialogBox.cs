using ePsychologist.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Ubiety.Dns.Core.Common;

namespace ePsychologist.View
{
    class CommandDialogBox : FrameworkElement, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected Action<object> execute = null;
        protected ICommand show;

        protected static readonly DependencyProperty captionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(CommandDialogBox));

        protected static readonly DependencyProperty commandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandDialogBox));

        protected static readonly DependencyProperty commandBeforeProperty = DependencyProperty.Register("CommandBefore", typeof(ICommand), typeof(CommandDialogBox));

        protected static readonly DependencyProperty commandAfterProperty = DependencyProperty.Register("CommandAfter", typeof(ICommand), typeof(CommandDialogBox));

        public string Caprion
        {
            get { return (string)GetValue(captionProperty); }
            set { SetValue(captionProperty, value); }
        }
        public object CommandParameter
        {
            get { return GetValue(commandParameterProperty); }
            set { SetValue(commandParameterProperty, value); }
        }

        public ICommand CommandBefore
        {
            get { return (ICommand)GetValue(commandBeforeProperty); }
            set { SetValue(commandBeforeProperty, value); }
        }

        public ICommand commandAfter
        {
            get { return (ICommand)GetValue(commandAfterProperty); }
            set { SetValue(commandAfterProperty, value); }
        }

        public ICommand Show
        {
            get
            {
                if (show == null)
                    show = new RelayCommand(
                        o => { executeCommand(CommandBefore, CommandParameter); 
                            execute(o); 
                            executeCommand(commandAfter, CommandParameter); },
                        o=> { return true; }
                        );
  
                return show;
            }
        }
        protected static void executeCommand(ICommand command, object commandParameter)
        {
            if (command != null)
                if (command.CanExecute(commandParameter))
                    command.Execute(commandParameter);
        }

    }



}
