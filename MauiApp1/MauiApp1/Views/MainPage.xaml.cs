using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();  // Set the binding context to the MainPageViewModel
        }
    }
}