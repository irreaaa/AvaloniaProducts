using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace AvaloniaProducts;

public partial class MainWindow : Window
{
    private ProductList productList = ProductList.Instance;
    public MainWindow()
    {
        InitializeComponent();
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
        if (double.TryParse(TextBoxCount.Text, out double enteredCostOfProduct))
        {
            productList.AddProduct(enteredProductName, enteredCostOfProduct);

            TextBoxName.Text = "";
            TextBoxCount.Text = "";
        }
        else
        {
            ShowCostErrorMessage();
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
            ShowErrorMessage();
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

    private void ShowErrorMessage()
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
}