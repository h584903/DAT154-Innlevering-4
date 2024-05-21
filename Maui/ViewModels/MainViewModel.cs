using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Maui.Views;

namespace Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly IServiceProvider _serviceProvider;

        public ICommand SelectRoleCommand { get; }

        public MainViewModel(INavigation navigation, IServiceProvider serviceProvider)
        {
            _navigation = navigation;
            _serviceProvider = serviceProvider;
            SelectRoleCommand = new Command<string>(OnSelectRole);
        }

        private async void OnSelectRole(string role)
        {
            Page page = role switch
            {
                "Cleaner" => new CleanerPage(_serviceProvider.GetRequiredService<CleanerViewModel>()),
                "ServicePerson" => new ServicePersonPage(_serviceProvider.GetRequiredService<ServicePersonViewModel>()),
                "Maintainer" => new MaintainerPage(_serviceProvider.GetRequiredService<MaintainerViewModel>()),
                _ => null
            };

            if (page != null)
            {
                await _navigation.PushAsync(page);
            }
        }
    }

}
