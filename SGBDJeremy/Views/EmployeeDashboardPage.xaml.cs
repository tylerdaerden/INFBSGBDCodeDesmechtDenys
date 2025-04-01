using SGBDJeremy.ViewModels;
using Microsoft.Maui.Controls;

namespace SGBDJeremy.Views
{
    [QueryProperty(nameof(EmployeeId), "EmployeeId")]
    public partial class EmployeeDashboardPage : ContentPage
    {
        public int EmployeeId { get; set; }

        public EmployeeDashboardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // On d�finit le ViewModel ici, une fois que l'ID est transmis
            BindingContext = new EmployeeDashboardViewModel(EmployeeId);
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.DisplayAlert("D�connexion", "Vous �tes d�connect�.", "OK");
            await Shell.Current.GoToAsync("//LoginPage"); // Double slash = reset de navigation stack
        }

    }
}
