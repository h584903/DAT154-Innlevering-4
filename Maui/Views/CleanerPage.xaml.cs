using Maui.ViewModels;
using HotelLibrary.Repositories;
namespace Maui.Views;


public partial class CleanerPage : ContentPage
{
    public CleanerPage(CleanerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}