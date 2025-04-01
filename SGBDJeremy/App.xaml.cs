namespace SGBDJeremy
{
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }


        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            // Appel de la méthode pour créer la DB et les tables dès lancement du programme
            SGBDJeremy.Utilities.Data.DatabaseInitializer.InitializeDatabase(
                "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Integrated Security=True;TrustServerCertificate=True;",
                "SGBDINFB");

            ServiceProvider = serviceProvider;

            MainPage = new AppShell();
        }
    }
}
