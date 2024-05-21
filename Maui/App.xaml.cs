using System.Diagnostics;

namespace Maui
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            // Add global exception handling
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                HandleException(e.ExceptionObject as Exception);
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                HandleException(e.Exception);
            };

            MainPage = new AppShell();
        }

        private void HandleException(Exception ex)
        {
            if (ex != null)
            {
                // Log exception here or display an alert
                Debug.WriteLine($"Unhandled Exception: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);

                // Optionally break into the debugger
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }
        }


    }
}
