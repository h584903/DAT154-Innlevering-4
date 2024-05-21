using System.Diagnostics;
using Microsoft.Maui;
using Maui.Views;   

namespace Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
    }


}

