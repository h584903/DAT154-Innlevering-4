using Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Maui.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;

        public MainPage(MainViewModel viewModel, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _serviceProvider = serviceProvider;
        }

        private async void OnRoleSelected(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var role = button.CommandParameter as string;

            Page page = role switch
            {
                "Cleaner" => _serviceProvider.GetRequiredService<CleanerPage>(),
                "ServicePerson" => _serviceProvider.GetRequiredService<ServicePersonPage>(),
                "Maintainer" => _serviceProvider.GetRequiredService<MaintainerPage>(),
                _ => null
            };

            if (page != null)
            {
                await Navigation.PushAsync(page);
            }
        }
    }
}
