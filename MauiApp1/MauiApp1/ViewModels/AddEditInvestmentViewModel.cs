using MauiApp1.Models;
using MauiApp1.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1.ViewModels
{
    public class AddEditInvestmentViewModel : BindableObject
    {
        private Investment _investment;

        public Investment Investment
        {
            get => _investment;
            set
            {
                _investment = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditInvestmentViewModel(Investment investment = null)
        {
            _investment = investment ?? new Investment();
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnSave()
        {
            if (_investment.Id == 0)
                await DatabaseService.AddInvestmentAsync(_investment);
            else
                await DatabaseService.UpdateInvestmentAsync(_investment);

            // Navigate back or update the UI as necessary
        }

        private void OnCancel()
        {
            // Navigate back
        }
    }
}