using Maui.ViewModels;
using Microsoft.Maui.Controls;
using Maui.Views;
namespace Maui.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    public MainPage(MainViewModel viewModel) : this()
    {
        BindingContext = viewModel;
    }

}