using Microsoft.Maui.Controls;
using Maui.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Maui
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = new NavigationPage(serviceProvider.GetRequiredService<MainPage>());
        }
    }
}
