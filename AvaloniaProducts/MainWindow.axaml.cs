using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;

namespace AvaloniaProducts;

public partial class MainWindow : Window
{
    private ProductList productList = ProductList.Instance;
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void AddImage_Click(object? sender, RoutedEventArgs e)
    {
        new Window().ShowDialog(this);
    }

    private void BtnAddProduct_Click(object? sender, RoutedEventArgs e)
    {
        string enteredProductName = TextBoxName.Text;

        foreach(var product in productList.Products)
        {
            if (product.ProductName == enteredProductName)
            {
                ShowDoubleErrorMessage();
                return;
            }
        }
        if (enteredProductName == null || enteredProductName == "")
        {
            ShowNameErrorMessage();
            return;
        }
        if (!double.TryParse(TextBoxCost.Text, out double enteredCostOfProduct) || enteredCostOfProduct <= 0)
        {
            ShowCostErrorMessage();
            return;
        }
        if(!int.TryParse(TextBoxQuantity.Text, out int enteredQuantityOfProduct) || enteredQuantityOfProduct <= 0)
        {
            ShowQuantityErrorMessage();
            return;
        }
        else
        {
            productList.AddProduct(enteredProductName, enteredCostOfProduct, enteredQuantityOfProduct);

            TextBoxName.Text = "";
            TextBoxCost.Text = "";
            TextBoxQuantity.Text = "";
        }
    }

    private void BtnShowAllProducts_Click(object? sender, RoutedEventArgs e)
    {
        if (productList.Products.Count > 0)
        {
            Win Win = new Win();
            Win.Show();
            this.Close();
        }
        else
        {
            ShowEmptyErrorMessage();
        }
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
        notificationManager.Show(new Notification("Ошибка", "Некорректное количество продукта.", NotificationType.Error));
    }

    private void ShowEmptyErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Список продуктов пуст.", NotificationType.Error));
    }

    private void ShowDoubleErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Такой продукт уже есть.", NotificationType.Error));
    }

    private void ShowNameErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Товар без названия.", NotificationType.Error));
    }

    private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
    }
}