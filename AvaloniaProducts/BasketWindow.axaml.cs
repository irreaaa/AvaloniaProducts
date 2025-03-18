using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaProducts;

public partial class BasketWindow : Window
{
    public BasketWindow()
    {
        InitializeComponent();
    }

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        Win win = new Win();
        win.Show();
        this.Close();
    }
}