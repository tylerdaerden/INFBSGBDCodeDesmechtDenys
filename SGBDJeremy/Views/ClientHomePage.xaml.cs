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

            // Le BindingContext est défini une fois que ClientId est reçu
            BindingContext = new ClientHomeViewModel(ClientId);
        }
    }
}
