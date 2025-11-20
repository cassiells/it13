using IT13.Models;
using IT13.ViewModels;

namespace RentalManagementSystem.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    private string username = "admin";

    [ObservableProperty]
    private string password = "1234";

    [ObservableProperty]
    private string selectedRole = "Admin";

    private string Username = "admin";
    private string Password = "1234";
    public List<string> Roles { get; } = new() { "Admin", "Agent", "Accountant", "Landlord" };
    public string SelectedRole { get; private set; }

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }

        // Simple validation (demo)
        if (Password != "1234")
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", "Wrong password", "OK");
            return;
        }

        var user = new User { Username = Username, Role = SelectedRole };
        Preferences.Set("CurrentUser", System.Text.Json.JsonSerializer.Serialize(user));

        // Navigate to Main Dashboard
        await Shell.Current.GoToAsync("//dashboard");
    }
}