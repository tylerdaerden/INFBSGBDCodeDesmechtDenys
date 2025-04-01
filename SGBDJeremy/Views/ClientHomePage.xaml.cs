using SGBDJeremy.DAL.Interfaces;
using SGBDJeremy.ViewModels;
using Microsoft.Extensions.DependencyInjection;


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
            var repo = App.ServiceProvider.GetService<IMeetingRepository>();
            BindingContext = new ClientHomeViewModel(ClientId, repo);
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("D�connexion", "Vous �tes d�connect�.", "OK");
            await Shell.Current.GoToAsync("//LoginPage"); 
        }

    }
}
