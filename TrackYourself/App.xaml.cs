using TrackYourself.Models.ViewModels;
using TrackYourself.Services;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace TrackYourself
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage(new MainPageViewModel(new LocationService()));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}