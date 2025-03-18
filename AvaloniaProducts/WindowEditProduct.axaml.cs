using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvaloniaProducts;

public partial class WinEditProduct : Window
{
    private Product _product;

    public WinEditProduct(Product product)
    {
        InitializeComponent();
        _product = product;

        ProductNameTextBox.Text = _product.ProductName;
        ProductCostTextBox.Text = _product.ProductCost.ToString();
    }

    public void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        var nameTextBox = this.FindControl<TextBox>("ProductNameTextBox");
        var costTextBox = this.FindControl<TextBox>("ProductCostTextBox");

        _product.ProductName = nameTextBox.Text;

        if(double.TryParse(costTextBox.Text, out double newCost))
        {
            if (newCost <= 0)
            {
                ShowCostErrorMessage();
                return;
            }
            _product.ProductCost = newCost;
            Win Win = new Win();
            Win.Show();
            this.Close();
        }
        else
        {
            ShowCostErrorMessage();
        }
    }

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        Win Win = new Win();
        Win.Show();
        this.Close();
    }

    private void ShowCostErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Некорректная цена продукта.", NotificationType.Error));
    }
}
