using Microsoft.Extensions.Configuration;

namespace FitnessPal.Maui
{
    public partial class App : Application
    {
        public App()
        {
            var config = LoadConfiguration();
            var licenseKey = config.GetValue<string>("SyncfusionLicence");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            InitializeComponent();

            MainPage = new AppShell();
        }

        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(FileSystem.AppDataDirectory)
                .AddUserSecrets<App>();

            return builder.Build();
        }
    }
}