using RentalManagementSystem.ViewModels;

[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "IT13")]
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "IT13.Pages")]
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    private async Task Logout()
    {
        Preferences.Clear();
        await Shell.Current.GoToAsync("//LoginPage");
    }
}