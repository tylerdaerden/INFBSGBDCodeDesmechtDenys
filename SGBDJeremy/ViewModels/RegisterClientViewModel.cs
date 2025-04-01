using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SGBDJeremy.Models;
using SGBDJeremy.Tools.CheckTools;
using SGBDJeremy.Utilities.Data;


namespace SGBDJeremy.ViewModels
{
    public partial class RegisterClientViewModel : ObservableObject
    {
        // Champs liés aux Entry (avec notification automatique)
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        public ICommand RegisterCommand { get; }

        public RegisterClientViewModel()
        {
            RegisterCommand = new RelayCommand(OnRegister);
        }

        private async void OnRegister()
        {
            // Validation des champs
            if (!User_Check_Entries.CheckName(FirstName))
            {
                await ShowError("Prénom invalide.");
                return;
            }

            if (!User_Check_Entries.CheckName(LastName))
            {
                await ShowError("Nom invalide.");
                return;
            }

            if (!User_Check_Entries.CheckEmail(Email))
            {
                await ShowError("Adresse e-mail invalide.");
                return;
            }

            if (!User_Check_Entries.CheckPhoneNumber(PhoneNumber))
            {
                await ShowError("Numéro de téléphone invalide.");
                return;
            }

            if (!User_Check_Entries.CheckPassword(Password))
            {
                await ShowError("Mot de passe invalide (8+ caractères, majuscule, minuscule, chiffre).");
                return;
            }

            // Création du client
            var newClient = new Client
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Password = Password
            };

            bool success = DBServiceHelper.AddClient(newClient);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Client enregistré avec succès !", "OK");
                await Shell.Current.GoToAsync("//LoginPage"); // Retour à la page de connexion
            }
            else
            {
                await ShowError("Une erreur est survenue lors de l'enregistrement.");
            }
        }

        private async Task ShowError(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Erreur", message, "OK");
        }
    }
}
