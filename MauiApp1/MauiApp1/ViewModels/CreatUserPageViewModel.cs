using System.Windows.Input;
using MauiApp1.Services;
using Microsoft.Maui.Controls;
using MauiApp1.Models;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public class CreateUserPageViewModel : BaseViewModel
    {
        private string _username;
        private string _email;
        private string _password;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand CreateAccountCommand { get; }

        public CreateUserPageViewModel()
        {
            // Initialize fields to empty strings
            _username = string.Empty;
            _email = string.Empty;
            _password = string.Empty;

            CreateAccountCommand = new Command(OnCreateAccount);
        }

        private async void OnCreateAccount()
        {
            var existingUser = await DatabaseService.GetUserByEmailAsync(Email);

            if (existingUser != null)
            {
                // Show error message if the email already exists
                await Shell.Current.DisplayAlert("Error", "Email already in use", "OK");
                return;
            }

            var newUser = new User(Username, Email, Password); // Ideally, you'd hash the password here
            await DatabaseService.AddUserAsync(newUser);

            // Navigate back to login page after successful account creation
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}