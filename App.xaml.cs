using AdvancedHRMS.Views;
using System.Windows;

namespace AdvancedHRMS
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

           
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            
            var loginWindow = new LoginWindow();
            loginWindow.Show();

        }
    }
}