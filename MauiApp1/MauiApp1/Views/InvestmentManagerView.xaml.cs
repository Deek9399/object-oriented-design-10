using MauiApp1.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiApp1.Views
{
    public partial class InvestmentManagerView : ContentPage
    {
        public InvestmentManagerView()
        {
            InitializeComponent();
            BindingContext = new InvestmentManagerViewModel();
        }
    }
}