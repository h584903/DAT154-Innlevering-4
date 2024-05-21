using Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace Maui.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
