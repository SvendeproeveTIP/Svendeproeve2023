using Microsoft.Maui.Dispatching;
using System.Diagnostics;

namespace GeolocationTest.Views;

[QueryProperty(nameof(QrCodeResult), "qrCodeResult")]
public partial class Transport : ContentPage
{
    Stopwatch stopwatch;
    public Transport()
	{
		InitializeComponent();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "transparent.png",
            IsEnabled = false
        });

        stopwatch = new Stopwatch();

        stopwatch.Start();
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (pointer.Value == 18000)
            {
                stopwatch.Stop();
                pointer.Value = 18000;
            }
            else
            {
                pointer.Value++;
                TimeSpan ts = stopwatch.Elapsed;

                string elapsedTime = ts.ToString(@"hh\:mm\:ss");

                timerLabel.Text = elapsedTime;
            }
            return true;
        });
    }
    private void betalBTN(object sender, EventArgs e)
    {
        stopwatch.Stop();
        Shell.Current.GoToAsync(nameof(MobilePay));
    }
    public string QrCodeResult
    {
        set
        {
            barcodeResult.Text = $"Transport Information\n{value}";
        }
    }


    protected override bool OnBackButtonPressed()
    {
        //return base.OnBackButtonPressed();
        return true;
    }
}