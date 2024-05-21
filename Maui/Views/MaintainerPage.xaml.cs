using HotelLibrary.Repositories;
using Maui.ViewModels;

namespace Maui.Views;

public partial class MaintainerPage : ContentPage
{
    public MaintainerPage(MaintainerViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}