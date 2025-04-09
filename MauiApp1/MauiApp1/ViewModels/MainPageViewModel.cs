using System.Windows.Input;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateToLoginCommand { get; }
        public ICommand NavigateToCreateAccountCommand { get; }

        public MainPageViewModel()
        {
            NavigateToLoginCommand = new Command(OnNavigateToLogin);
            NavigateToCreateAccountCommand = new Command(OnNavigateToCreateAccount);
        }

        private async void OnNavigateToLogin()
        {
            // Ensure that Shell.Current is not null before accessing it
            if (Shell.Current != null)
            {
                await Shell.Current.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                // Handle the case where Shell.Current is null (optional)
            }
        }

        private async void OnNavigateToCreateAccount()
        {
            // Handle navigation to the account creation page here
            if (Shell.Current != null)
            {
                await Shell.Current.Navigation.PushAsync(new CreateUserPageView());
            }
        }
    }
}