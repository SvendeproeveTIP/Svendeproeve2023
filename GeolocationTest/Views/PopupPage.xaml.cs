using MauiPopup;
using MauiPopup.Views;

namespace GeolocationTest.Views;

public partial class PopupPage : BasePopupPage
{
	public PopupPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await PopupAction.ClosePopup(); 
	}
}