using MauiApp1.Services;

namespace MauiApp1.Views
{
    public partial class UserDashboardPage : ContentPage
    {
        public UserDashboardPage()
        {
            InitializeComponent();

            var user = SessionService.CurrentUser;
            welcomeLabel.Text = $"Welcome, {user?.Username ?? "User"}!";
        }
    }
}