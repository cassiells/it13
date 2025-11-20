namespace RentalManagementSystem.Views;

public partial class MainPage : ContentPage
{
    public string WelcomeMessage => $"Hello, {GetCurrentUserRole()}!";

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private string GetCurrentUserRole()
    {
        var json = Preferences.Get("CurrentUser", "");
        if (string.IsNullOrEmpty(json)) return "User";
        var user = System.Text.Json.JsonSerializer.Deserialize<User>(json);
        return user?.Role ?? "User";
    }
}