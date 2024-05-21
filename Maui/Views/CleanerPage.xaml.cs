using Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace Maui.Views
{
    public partial class CleanerPage : ContentPage
    {
        public CleanerPage(CleanerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
