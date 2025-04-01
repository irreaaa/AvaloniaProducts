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
    private ProductList productList = ProductList.Instance;

    public WinEditProduct(Product product)
    {
        InitializeComponent();
        _product = product;

        ProductNameTextBox.Text = _product.ProductName;
        ProductCostTextBox.Text = _product.ProductCost.ToString();
        ProductQuantityTextBox.Text = _product.ProductQuantity.ToString();
    }

    public void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        var nameTextBox = this.FindControl<TextBox>("ProductNameTextBox");
        var costTextBox = this.FindControl<TextBox>("ProductCostTextBox");
        var quantityTextBox = this.FindControl<TextBox>("ProductQuantityTextBox");

        foreach (var product in productList.Products)
        {
            if (product.ProductName == nameTextBox.Text)
            {
                ShowDoubleErrorMessage();
                return;
            }
        }
        if (!double.TryParse(costTextBox.Text, out double newCost) || newCost <= 0)
        {
            ShowCostErrorMessage();
            return;
        }
        if (!int.TryParse(quantityTextBox.Text, out int newQuantity) || newQuantity <= 0)
        {
            ShowQuantityErrorMessage();
            return;
        }
        if(nameTextBox == null || nameTextBox.Text == "")
        {
            ShowNameErrorMessage();
        }
        else
        {
            _product.ProductName = nameTextBox.Text;
            _product.ProductCost = newCost;
            _product.ProductQuantity = newQuantity;
            Win Win = new Win();
            Win.Show();
            this.Close();
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
    private void ShowQuantityErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Некорректное количетво продукта.", NotificationType.Error));
    }
    private void ShowNameErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Товар без названия.", NotificationType.Error));
    }
    private void ShowDoubleErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Такой продукт уже есть.", NotificationType.Error));
    }
}
