using SGBDJeremy.Views;

namespace SGBDJeremy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //J'ajoute ici mes route et non dans le shell Xmal pour qu'elle ne soient pas accessible sans login réussi ↓↓↓
            Routing.RegisterRoute(nameof(ClientHomePage), typeof(ClientHomePage));
            Routing.RegisterRoute(nameof(EmployeeDashboardPage), typeof(EmployeeDashboardPage));
            Routing.RegisterRoute(nameof(RegisterClientPage), typeof(RegisterClientPage));

        }
    }

}
