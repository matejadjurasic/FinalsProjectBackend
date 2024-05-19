namespace FitnessPal.Maui
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF1cXmhMYVJ+WmFZfVpgdVdMY19bQHdPIiBoS35RckVmWH5fcndWQmFUUkB3");
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}