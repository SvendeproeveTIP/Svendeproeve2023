using Microsoft.Maui.Controls.Maps;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maui.Maps;

namespace GeolocationTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		InitMap1();
      
    }

	void InitMap1()
	{
		var customPinFromImage = new CustomPin()
		{
			Label = "EL-Løbehjul 1",
			Location = new Location(55.3782028776744, 10.396612222748393),
			Address = "59% Batteri tilbage",
			ImageSource = ImageSource.FromResource("GeolocationTest.Resources.Images.elscooter.png")
		};

		MyMap.Pins.Add(customPinFromImage);
    }
}

