using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace component.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        // CurrentPage = _homePage;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(LoginPageIsActive))]
    private ViewModelBase _currentPage;

    private readonly HomePageViewModel _homePage = new HomePageViewModel();
    private readonly LoginPageViewModel _loginPage = new LoginPageViewModel();
    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool LoginPageIsActive => CurrentPage == _loginPage;

    [RelayCommand]
    private void GoToHomePage()
    {
        CurrentPage = _homePage;
    }

    [RelayCommand]
    private void GoToLoginPage()
    {
        CurrentPage = _loginPage;
    }
}