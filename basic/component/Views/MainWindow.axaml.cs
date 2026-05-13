using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace component.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnClickName(object? sender, RoutedEventArgs e)
    {
        Debug.WriteLine($"Name: {NameBox.Text}");
    }

    private void DebugLog_OnTextChangedLog(object? sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(InputTxt.Text))
        {
            OutputTxt.Text = InputTxt.Text;
        }
    }
}