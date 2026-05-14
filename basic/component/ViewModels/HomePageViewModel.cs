using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using component.Views;

namespace component.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    [RelayCommand]
    public void GoToLoginPage()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        var oldWindow = desktop.MainWindow;
        oldWindow?.Hide();
        // 创建新的登录窗口
        var loginWindow = new LoginPage
        {
            DataContext = new LoginPageViewModel() // 绑定登录页的 ViewModel
        };
        if (oldWindow != null)
        {
            loginWindow.Position = oldWindow.Position;
        }

        desktop.MainWindow = loginWindow;
        loginWindow.Show();
        oldWindow?.Close();
    }
}