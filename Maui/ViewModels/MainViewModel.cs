using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Maui.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand SelectRoleCommand { get; }

        public MainViewModel()
        {
            SelectRoleCommand = new Command<string>(OnSelectRole);
        }

        private void OnSelectRole(string role)
        {
          
        }
    }
}
