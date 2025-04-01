using SGBDJeremy.ViewModels;

namespace SGBDJeremy.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}

	//petite "entorse" au MVVM , mais qui n'en est pas vraiment une , ce ce n'est pas ici de la logique métier mais un simple
	//renvoi vers la page
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegisterClientPage));
    }

}