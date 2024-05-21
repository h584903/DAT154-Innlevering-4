using HotelLibrary.Repositories;
using Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace Maui.Views;

public partial class ServicePersonPage : ContentPage
{
	
    public ServicePersonPage(ServicePersonViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}