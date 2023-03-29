using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTest.ViewModels
{
    public class Geolocation
    {
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation= true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null) { }
            }
        }
    }
}
