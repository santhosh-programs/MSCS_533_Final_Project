using System.Diagnostics;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using TrackYourself.Models.ViewModels;

namespace TrackYourself
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Subscribe to location updates
            viewModel.PropertyChanged += (sender, args) =>
            {
                Debug.WriteLine("Location update, map update");
                if (args.PropertyName == nameof(viewModel.Latitude) || args.PropertyName == nameof(viewModel.Longitude))
                {
                    UpdateMap(viewModel.Latitude, viewModel.Longitude);
                }
            };
        }

        private void UpdateMap(double latitude, double longitude)
        {

            var pin = new Pin
            {
                Label = "Current Location",
                Address = $"Lat: {latitude}, Long: {longitude}",
                Type = PinType.Place,
                Location = new Location(latitude, longitude)
            };

            // Optionally center the map on the new location
            //MyMap.Pins.Add(pin);
            MyMap.MapElements.Add(new Circle
            {
                Center = new Location(latitude, longitude),
                Radius = Distance.FromMeters(1), // Small radius to make it look like a dot
                StrokeColor = Colors.Transparent,
                FillColor = Colors.Red
            });
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(latitude, longitude), Distance.FromMiles(0.5)));

        }
    }
}
