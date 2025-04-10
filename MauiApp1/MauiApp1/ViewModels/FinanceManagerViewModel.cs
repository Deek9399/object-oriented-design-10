using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp1.ViewModels
{
    public class FinanceManagerViewModel : BindableObject
    {
        private ObservableCollection<Budget> _budgetsExpenses;
        private Budget _selectedBudgetExpense;

        public ObservableCollection<Budget> BudgetsExpenses
        {
            get => _budgetsExpenses;
            set
            {
                _budgetsExpenses = value;
                OnPropertyChanged();
            }
        }

        public Budget SelectedBudgetExpense
        {
            get => _selectedBudgetExpense;
            set
            {
                _selectedBudgetExpense = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddBudgetExpenseCommand { get; }
        public ICommand EditBudgetExpenseCommand { get; }

        public FinanceManagerViewModel()
        {
            AddBudgetExpenseCommand = new Command(OnAddBudgetExpense);
            EditBudgetExpenseCommand = new Command(OnEditBudgetExpense);

            LoadBudgetsExpenses();
        }

        private async void LoadBudgetsExpenses()
        {
            var budgetsExpenses = await DatabaseService.GetBudgetsForUserAsync(1); // assuming UserId 1 for now
            BudgetsExpenses = new ObservableCollection<Budget>(budgetsExpenses);
        }

        private async void OnAddBudgetExpense()
        {
            // Logic to add budget/expense
        }

        private async void OnEditBudgetExpense()
        {
            // Logic to edit selected budget/expense
        }
    }
}