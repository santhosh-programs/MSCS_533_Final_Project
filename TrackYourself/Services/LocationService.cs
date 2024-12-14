using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using TrackYourself.Models;

namespace TrackYourself.Services
{
    public class LocationService
    {
        public async Task StartListening()
        {
            Geolocation.LocationChanged += Geolocation_LocationChanged;
            var request = new GeolocationListeningRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
            if (request is not null)
            {
               _ = await Geolocation.StartListeningForegroundAsync(request);
            }
        }

        public void StopListening()
        {
            Debug.WriteLine("Stop listening for location updates");

            Geolocation.LocationChanged -= Geolocation_LocationChanged;
            Geolocation.StopListeningForeground();
        }

        private void Geolocation_LocationChanged(object? sender, GeolocationLocationChangedEventArgs e)
        {
            Debug.WriteLine("Start listening for location updates");
            var deviceLocation = new DeviceLocation(e.Location.Latitude, e.Location.Longitude);
            WeakReferenceMessenger.Default.Send(deviceLocation);
        }
    }
}
