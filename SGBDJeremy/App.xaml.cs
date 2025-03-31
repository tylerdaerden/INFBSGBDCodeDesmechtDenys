namespace SGBDJeremy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Appel de la méthode pour créer la BDD et les tables
            SGBDJeremy.Utilities.Data.DatabaseInitializer.InitializeDatabase(
                "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Integrated Security=True;TrustServerCertificate=True;",
                "SGBDINFB");

            MainPage = new AppShell();
        }
    }
}
