using GeolocationTest.ViewModels;
using MauiPopup;

namespace GeolocationTest.Views;

public partial class MobilePay : ContentPage
{
	private BetalingViewModel _viewModel;
	public MobilePay(BetalingViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

	private void BetalInvoked(object sender, EventArgs e)
	{
       PopupAction.DisplayPopup(new PopupPage());
    }
}