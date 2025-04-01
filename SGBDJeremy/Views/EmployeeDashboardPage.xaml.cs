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

            // On définit le ViewModel ici, une fois que l'ID est transmis
            BindingContext = new EmployeeDashboardViewModel(EmployeeId);
        }
    }
}
