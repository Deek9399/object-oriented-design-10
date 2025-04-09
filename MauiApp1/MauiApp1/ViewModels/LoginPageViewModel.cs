using System.Windows.Input;
using System.Diagnostics; // Added this to use Debug.WriteLine
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using Microsoft.Maui.Controls;

namespace MauiApp1.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

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

        public ICommand LoginCommand { get; }
        public LoginPageViewModel()
        {
            // Initialize non-nullable fields
            _email = string.Empty;
            _password = string.Empty;

            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            // Log email and attempt to retrieve the user
            Debug.WriteLine($"Attempting to log in with email: {Email}");

            await DatabaseService.PrintAllUsersAsync(); // Log all users
            var user = await DatabaseService.GetUserByEmailAsync(Email);

            // Log if the user was found or not
            if (user != null)
            {
                Debug.WriteLine($"User found: {user.Username} with email: {user.Email}");
            }
            else
            {
                Debug.WriteLine("No user found with that email.");
            }

            if (user != null && user.PasswordHash == Password) // You should hash passwords later!
            {
                SessionService.CurrentUser = user;

                await Shell.Current.DisplayAlert("Success", "Login successful", "OK");

                await Shell.Current.GoToAsync("//UserDashboardPage"); // Absolute path to the UserDashboardPage
            }
            else
            {
                await Shell.Current.DisplayAlert("Login Failed", "Invalid email or password", "OK");
            }
        }

        public void OnAppearing()
        {
            // Reset the fields when the page appears
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}