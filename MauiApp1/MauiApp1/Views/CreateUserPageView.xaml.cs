using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class CreateUserPageView : ContentPage
    {
        public CreateUserPageView()
        {
            InitializeComponent();
            BindingContext = new CreateUserPageViewModel(); // Bind the ViewModel
        }
    }
}