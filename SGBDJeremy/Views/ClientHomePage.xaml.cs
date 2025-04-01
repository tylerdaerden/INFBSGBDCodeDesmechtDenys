using SGBDJeremy.ViewModels;

namespace SGBDJeremy.Views
{
    [QueryProperty(nameof(ClientId), "ClientId")]
    public partial class ClientHomePage : ContentPage
    {
        public int ClientId { get; set; }

        public ClientHomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Le BindingContext est d�fini une fois que ClientId est re�u
            BindingContext = new ClientHomeViewModel(ClientId);
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("D�connexion", "Vous �tes d�connect�.", "OK");
            await Shell.Current.GoToAsync("//LoginPage"); // Double slash = reset de navigation stack
        }

    }
}
