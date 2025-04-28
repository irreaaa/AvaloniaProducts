using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls.Notifications;
using Avalonia.Media.Imaging;

namespace AvaloniaProducts;

public partial class Win : Window
{
    public List<Product> Products => ProductList.Instance.Products;
    private BasketList basketList = BasketList.Instance;
    public Bitmap? ImageFromBinding { get; } = ImageHelper.LoadFromResources(new Uri("avares://AvaloniaProducts/LoadingImages/Assets/hp.jpg"));


    public Win()
    {
        InitializeComponent();
        ProductListBox.ItemsSource = Products;
    }

    private void AddToBasket_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Product product)
        {
            if (product.ProductQuantity == 0)
            {
                NoMoreError();
            }

            if (product.ProductQuantity > 0)
            {
                basketList.AddToBasket(product.ProductName, 1);
                ProductListBox.ItemsSource = null;
                ProductListBox.ItemsSource = Products;
                AddedMessage();
            }
        }
    }

    private void Del_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Product deleteProduct)
        {
            ProductList.Instance.RemoveProduct(deleteProduct);
            BasketList.Instance.RemoveFromBasket(deleteProduct);

            ProductListBox.ItemsSource = null;
            ProductListBox.ItemsSource = Products;
        }
        if (ProductList.Instance.Products.Count == 0)
        {
            ProductListBox.ItemsSource = null;
            ProductListBox.ItemsSource = new List<string> { "Список продуктов пуст." };
        }
    }

    private void Edit_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Product productToEdit)
        {
            WinEditProduct editWindow = new WinEditProduct(productToEdit);
            editWindow.Show();
            this.Close();
        }
    }

    private void Basket_Click(object? sender, RoutedEventArgs e)
    {
        var productsInStore = ProductList.Instance.Products.Select(p => p.ProductName).ToHashSet();
        basketList.Basket.RemoveAll(p => !productsInStore.Contains(p.ProductName));
        if (basketList.Basket.Count == 0)
        {
            var notificationManager = new WindowNotificationManager(this)
            {
                Position = NotificationPosition.BottomCenter
            };
            notificationManager.Show(new Notification("Ошибка", "Ваша корзина пуста.", NotificationType.Error));
        }
        else
        {
            BasketWindow basket = new BasketWindow();
            basket.Show();
            this.Close();
        }
    }

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void AddedMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.TopCenter
        };
        notificationManager.Show(new Notification("Успешно", "Товар добавлен в корзину.", NotificationType.Success));
    }

    private void NoMoreError()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.TopCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Такого товара больше нет в наличии.", NotificationType.Error));
    }
}