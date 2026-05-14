using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using component.Views;

namespace component.ViewModels;

public partial class LoginPageViewModel : ViewModelBase
{
    [ObservableProperty] private string _statusMessage = "请登录您的账户";
    [ObservableProperty] private string _account = "";
    [ObservableProperty] private string _password = "";

    [RelayCommand]
    public void GoToHomePage()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop) return;
        var oldWindow = desktop.MainWindow;
        oldWindow?.Hide();
        // 创建新的登录窗口
        var loginWindow = new HomePage()
        {
            DataContext = new HomePageViewModel() // 绑定登录页的 ViewModel
        };
        if (oldWindow != null)
        {
            loginWindow.Position = oldWindow.Position;
        }

        desktop.MainWindow = loginWindow;
        loginWindow.Show();
        oldWindow?.Close();
    }

    partial void OnAccountChanged(string? value)
    {
        if (value?.Length > 10)
        {
            StatusMessage = "账号长度不能超过10位！";
        }
    }

    partial void OnPasswordChanged(string? value)
    {
        if (value?.Length < 10)
        {
            StatusMessage = "密码长度不能小于10位！";
        }
    }

    [RelayCommand]
    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(_account))
        {
            StatusMessage = "账号不能为空";
            return;
        }

        if (string.IsNullOrEmpty(_password))
        {
            StatusMessage = "密码不能为空";
            return;
        }

        if (_account.Length > 10)
        {
            StatusMessage = "账号长度不能超过10位字符";
            return;
        }

        if (_password.Length < 10)
        {
            StatusMessage = "密码长度不能小于10位字符";
            return;
        }

        StatusMessage = "登录成功！！！";
    }
}