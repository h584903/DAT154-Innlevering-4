using Maui.ViewModels;
using Microsoft.Maui.Controls;
using Maui.Views;
namespace Maui.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}