using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Declare PropertyChanged as nullable to match INotifyPropertyChanged interface
        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}