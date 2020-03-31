using System.ComponentModel;
using System.Windows.Input;


namespace ePsychologist.ViewModels.MainView
{
    class Navigator : INavigator, INotifyPropertyChanged
    {
        private BasicViewModel currentVM;
        public BasicViewModel CurrentVM {
            get
            {
                return currentVM;
            }
            set
            {
                currentVM = value;
                OnPropertyChange(nameof(CurrentVM));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(params string[] propertsName)
        {
            if (PropertyChanged != null)
            {
                foreach (var propertyName in propertsName)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand UpdateCurrentVMCommand => new UpdateCurrentVMCommand(this);
    }
}
