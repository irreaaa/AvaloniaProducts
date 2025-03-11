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
    List<Product> products = new List<Product>();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnAddProduct_Click(object? sender, RoutedEventArgs e)
    {
        string enteredProductName = TextBoxName.Text;
        if (double.TryParse(TextBoxCount.Text, out double enteredCostOfProduct))
        {
            Product product = new Product(enteredProductName, enteredCostOfProduct);
            products.Add(product);

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
        if (products.Count > 0)
        {
            Win Win = new Win(products);
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
}