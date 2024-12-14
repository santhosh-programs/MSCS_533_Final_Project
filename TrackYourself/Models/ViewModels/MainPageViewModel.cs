using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TrackYourself.Services;

namespace TrackYourself.Models.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly LocationService _locationService;
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private double latitude;

        [ObservableProperty]
        private double longitude;

        [ObservableProperty]
        private bool isListening;

        [ObservableProperty]
        private string listeningButtonText;

        public MainPageViewModel(LocationService locationService, DatabaseService databaseService)
        {
            _locationService = locationService;
            _databaseService = databaseService;

            WeakReferenceMessenger.Default.Register<DeviceLocation>(this,async (sender, deviceLocation) =>
            {
                Latitude = deviceLocation.Latitude;
                Longitude = deviceLocation.Longitude;

                // Save to SQLite database on every update
                await SaveLocationToDatabaseAsync(deviceLocation);
            });

            listeningButtonText = "Start";
            //ChangeListeningMode();
            _ = _locationService.StartListening();


        }

        private async Task SaveLocationToDatabaseAsync(DeviceLocation deviceLocation)
        {
            Debug.WriteLine("Location: Saving to DB");
            var locationRecord = new LocationRecord
            {
                Latitude = deviceLocation.Latitude,
                Longitude = deviceLocation.Longitude,
            };

            await _databaseService.SaveLocationAsync(locationRecord);
        }

        [RelayCommand]
        private void ChangeListeningMode()
        {
            if (!isListening) 
            {
                _ = _locationService.StartListening();
                IsListening = true;
                ListeningButtonText = "Stop";
            }
            else
            {
                _locationService.StopListening();
                IsListening = false;
                ListeningButtonText = "Start";
            }
        }
    }
}
