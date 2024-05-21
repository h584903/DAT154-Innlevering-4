using Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace Maui.Views
{
    public partial class MaintainerPage : ContentPage
    {
        public MaintainerPage(MaintainerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
