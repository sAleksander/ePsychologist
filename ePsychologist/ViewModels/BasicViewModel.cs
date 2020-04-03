using System.ComponentModel;

namespace ePsychologist.ViewModels
{
    public class BasicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(params string[] propertsName)
        {
            if (PropertyChanged != null)
            {
                foreach(var propertyName in propertsName)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
