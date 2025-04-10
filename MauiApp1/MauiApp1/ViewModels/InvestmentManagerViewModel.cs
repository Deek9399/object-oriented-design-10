using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1.ViewModels
{
    public class InvestmentManagerViewModel : BindableObject
    {
        private ObservableCollection<Investment> _investments;
        private Investment _selectedInvestment;

        public ObservableCollection<Investment> Investments
        {
            get => _investments;
            set
            {
                _investments = value;
                OnPropertyChanged();
            }
        }

        public Investment SelectedInvestment
        {
            get => _selectedInvestment;
            set
            {
                _selectedInvestment = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddInvestmentCommand { get; }
        public ICommand EditInvestmentCommand { get; }

        public InvestmentManagerViewModel()
        {
            AddInvestmentCommand = new Command(OnAddInvestment);
            EditInvestmentCommand = new Command(OnEditInvestment);

            LoadInvestments();
        }

        private async void LoadInvestments()
        {
            var investments = await DatabaseService.GetInvestmentsForUserAsync(1); // assuming UserId 1 for now
            Investments = new ObservableCollection<Investment>(investments);
        }

        private async void OnAddInvestment()
        {
            // Logic to add investment
            // Show a form or navigate to an Add page
        }

        private async void OnEditInvestment()
        {
            // Logic to edit selected investment
            // Show a form or navigate to an Edit page with selectedInvestment's details
        }
    }
}