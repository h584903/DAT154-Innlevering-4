using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using Maui.Views;

namespace Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public ICommand SelectRoleCommand { get; }

        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            SelectRoleCommand = new Command<string>(OnSelectRole);
        }

        private async void OnSelectRole(string role)
        {
            Page page = role switch
            {
                "Cleaner" => _serviceProvider.GetRequiredService<CleanerPage>(),
                "ServicePerson" => _serviceProvider.GetRequiredService<ServicePersonPage>(),
                "Maintainer" => _serviceProvider.GetRequiredService<MaintainerPage>(),
                _ => null
            };

            if (page != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }
    }
}
