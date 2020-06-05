using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ePsychologist.View
{
    class MessageBoxPatient : CommandDialogBox
    {
        public MessageBoxPatient()
        {
            IsMessageBoxPatientShow = true;
            execute = o => showMessageBox(o);
        }


        protected static readonly DependencyProperty commandOKProperty = DependencyProperty.Register("CommandOK", typeof(ICommand), typeof(MessageBoxPatient));
        protected static readonly DependencyProperty commandYesProperty = DependencyProperty.Register("CommandYes", typeof(ICommand), typeof(MessageBoxPatient));
        protected static readonly DependencyProperty commandNoProperty = DependencyProperty.Register("CommandNo", typeof(ICommand), typeof(MessageBoxPatient));


        public static DependencyProperty IsMessageBoxPatientShowProperty = DependencyProperty.Register("IsMessageBoxPatientShowProperty", typeof(bool), typeof(MessageBoxPatient));

        public MessageBoxResult? LastResult { get; set; }

        public MessageBoxButton Buttons { get; set; } = MessageBoxButton.OK;
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;
        

        public bool IsMessageBoxPatientShow
        {
            get { return (bool)GetValue(IsMessageBoxPatientShowProperty); }
            set { SetValue(IsMessageBoxPatientShowProperty, value); }
        }

        public MessageBoxResult DialogBypassButton { get; set; } = MessageBoxResult.None;


        public bool ResultYes
        {
            get
            {
                if (!LastResult.HasValue)
                    return false;
                return LastResult.Value == MessageBoxResult.Yes;
            }
        }

        public bool ResultNo
        {
            get
            {
                if (!LastResult.HasValue)
                    return false;
                return LastResult.Value == MessageBoxResult.No;
            }
        }

        public bool ResultOk
        {
            get
            {
                if (!LastResult.HasValue)
                    return false;
                return LastResult.Value == MessageBoxResult.OK;
            }
        }

        public ICommand CommandYes
        {
            get { return (ICommand)GetValue(commandYesProperty); }
            set { SetValue(commandYesProperty,value); }
        }

        public ICommand CommanNo
        {
            get { return (ICommand)GetValue(commandNoProperty); }
            set { SetValue(commandNoProperty, value); }
        }

        public ICommand CommandOk
        {
            get { return (ICommand)GetValue(commandOKProperty); }
            set { SetValue(commandOKProperty, value); }
        }

        public void showMessageBox(object contentText)
        {
            MessageBoxResult result;

            if (IsMessageBoxPatientShow)
            {
                LastResult = MessageBox.Show((string)contentText, Caption, Buttons);
                onPropertyChanged("LastResult");
                result = LastResult.Value;
            }
            else
                result = DialogBypassButton;


            switch(result)
            {
                case MessageBoxResult.Yes:
                    if (IsMessageBoxPatientShow)
                        onPropertyChanged("ResultYes");
                    executeCommand(CommandYes, CommandParameter);
                    break;
                case MessageBoxResult.No:
                    if (IsMessageBoxPatientShow)
                        onPropertyChanged("ResultNo");
                    executeCommand(CommanNo, CommandParameter);
                    break;
                case MessageBoxResult.OK:
                    if (IsMessageBoxPatientShow)
                        onPropertyChanged("ResultOk");
                    executeCommand(CommandOk, CommandParameter);
                    break;
            }
        }
    }
}
