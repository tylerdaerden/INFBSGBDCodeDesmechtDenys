using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SGBDJeremy.Utilities.Data;
using SGBDJeremy.Tools.CheckTools;

namespace SGBDJeremy.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        // Champs liés aux Entry
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        // Liste des rôles à afficher dans le Picker
        public ObservableCollection<string> Roles { get; } =
            new ObservableCollection<string> { "Client", "Employé" };

        [ObservableProperty]
        private string selectedRole = "Client"; // Par défaut

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLogin);
        }

        private async void OnLogin()
        {
            // Vérification des entrées
            if (!User_Check_Entries.CheckEmail(Email))
            {
                await Shell.Current.DisplayAlert("Erreur", "Adresse e-mail invalide.", "OK");
                return;
            }

            if (!User_Check_Entries.CheckPassword(Password))
            {
                await Shell.Current.DisplayAlert("Erreur", "Mot de passe invalide.", "OK");
                return;
            }

            // Authentification selon le rôle
            bool isAuthenticated = false;

            if (SelectedRole == "Client")
            {
                isAuthenticated = UserAuthService.AuthenticateClient(Email, Password);
            }
            else if (SelectedRole == "Employé")
            {
                isAuthenticated = UserAuthService.AuthenticateEmployee(Email, Password);
            }

            // Si authentification réussie
            if (isAuthenticated)
            {
                await Shell.Current.DisplayAlert("Succès", "Connexion réussie en tant que " + SelectedRole, "OK");

                if (SelectedRole == "Client")
                {
                    var client = DBAuthHelper.GetClientByEmail(Email);
                    if (client != null)
                    {
                        // 🚀 Redirection vers la page du/de la client.e
                        await Shell.Current.GoToAsync($"{nameof(Views.ClientHomePage)}?ClientId={client.Id}");
                    }
                }
                else if (SelectedRole == "Employé")
                {
                    var employee = DBAuthHelper.GetEmployeeByEmail(Email);
                    if (employee != null)
                    {
                        //await Shell.Current.DisplayAlert("Succès", "Connexion réussie en tant qu'employé", "OK");

                        // 🚀 Redirection vers le Dashboard Employé
                        await Shell.Current.GoToAsync($"{nameof(Views.EmployeeDashboardPage)}?EmployeeId={employee.Id}");
                        return;
                    }
                }

                return; // Fin du traitement
            }

            // Sinon, message d’échec
            await Shell.Current.DisplayAlert("Erreur", "Identifiants incorrects.", "OK");
        }



    }
}
