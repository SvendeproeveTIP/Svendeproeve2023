namespace GeolocationTest.Views;

[QueryProperty(nameof(QrCodeResult), "qrCodeResult")]
public partial class Transport : ContentPage
{
    bool isCircularTimerOn = true;
    public Transport()
	{
		InitializeComponent();

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "transparent.png",
            IsEnabled = false
        });

        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (!isCircularTimerOn)
            {
                pause.IsVisible = false;
                return false;
            }

            Dispatcher.DispatchAsync(() =>
            {
                pointer.Value++;
                if (pointer.Value > 7200)
                {
                    isCircularTimerOn = false;
                    pointer.Value = 0;
                    timer.Text = "00:00";
                }
                else
                {
                    timer.Text = pointer.Value.ToString("00:00");
                }
            });

            return true;
        });
    }
    private void play_pause_Clicked(object sender, EventArgs e)
    {
        isCircularTimerOn = !isCircularTimerOn;
        if (isCircularTimerOn)
        {
            pause.IsVisible = true;
        }
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