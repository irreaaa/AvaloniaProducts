using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using Avalonia.Controls.Shapes;
using Avalonia.OpenGL;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Styling;
using System.Reflection.Metadata;
using System.Data.Common;
using Avalonia.Markup.Xaml.MarkupExtensions;
using System.Collections.ObjectModel;
using Avalonia.Controls.Notifications;
using Avalonia.Media.Imaging;
using System.Windows.Input;

namespace AvaloniaProducts;

public partial class Win : Window
{
    public List<Product> Products => ProductList.Instance.Products;
    private BasketList basketList = BasketList.Instance;

    public Win()
    {
        InitializeComponent();
        ProductListBox.ItemsSource = Products;
    }
    private void AddToBasket_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Product product)
        {
            basketList.AddToBasket(product.ProductName, 1);
            if (basketList != null)
            {
                AddedMessage();
            }
        }
    }

    private void Del_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Product deleteProduct)
        {
            ProductList.Instance.RemoveProduct(deleteProduct);
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
        if(basketList.Basket.Count == 0)
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
            Position = NotificationPosition.TopRight
        };
        notificationManager.Show(new Notification("Успешно", "Товар добавлен в корзину.", NotificationType.Success));
    }
}







//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Interactivity;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;

//namespace AvaloniaProducts;

//public partial class Win : Window
//{
//    public List<Product> Products => ProductList.Instance.Products;
//    public ObservableCollection<Product> Basket => BasketList.Instance.Basket;
//    private BasketList basketList = BasketList.Instance;

//    public Win()
//    {
//        InitializeComponent();
//        ProductListBox.ItemsSource = Products;
//    }

//    private void AddToBasket_Click(object? sender, RoutedEventArgs e)
//    {
//        if (sender is Button button && button.DataContext is Product product)
//        {
//            int quantityToAdd = 1;
//            basketList.AddToBasket(product, quantityToAdd);
//        }
//    }

//    private void Del_Click(object? sender, RoutedEventArgs e)
//    {
//        if (sender is Button button && button.DataContext is Product deleteProduct)
//        {
//            ProductList.Instance.RemoveProduct(deleteProduct);
//            ProductListBox.ItemsSource = null;
//            ProductListBox.ItemsSource = Products;
//        }
//        if (ProductList.Instance.Products.Count == 0)
//        {
//            ProductListBox.ItemsSource = null;
//            ProductListBox.ItemsSource = new List<string> { "Список продуктов пуст." };
//        }
//    }

//    private void Edit_Click(object? sender, RoutedEventArgs e)
//    {
//        if (sender is Button button && button.DataContext is Product productToEdit)
//        {
//            WinEditProduct editWindow = new WinEditProduct(productToEdit);
//            editWindow.Show();
//            this.Close();
//        }
//    }

//    private void Basket_Click(object? sender, RoutedEventArgs e)
//    {
//        BasketWindow basketWindow = new BasketWindow();
//        basketWindow.Show();
//        Close();
//    }

//    private void Return_Click(object? sender, RoutedEventArgs e)
//    {
//        MainWindow mainWindow = new MainWindow();
//        mainWindow.Show();
//        Close();
//    }
//}









////using Avalonia;
////using System;
////using Avalonia.Controls;
////using Avalonia.Interactivity;
////using Avalonia.Media;
////using System.Collections.Generic;
////using System.ComponentModel.DataAnnotations;
////using System.Linq;
////using static System.Runtime.InteropServices.JavaScript.JSType;
////using System.Numerics;
////using Avalonia.Controls.Shapes;
////using Avalonia.OpenGL;
////using Avalonia.Markup.Xaml.Templates;
////using Avalonia.Styling;
////using System.Reflection.Metadata;
////using System.Data.Common;
////using Avalonia.Markup.Xaml.MarkupExtensions;
////using System.Collections.ObjectModel;
////using Avalonia.Controls.Notifications;

////namespace AvaloniaProducts;

////public partial class Win : Window
////{
////    public List<Product> Products => ProductList.Instance.Products;
////    public List<Product> Basket => BasketList.Instance.Basket;
////    private BasketList basketList = BasketList.Instance;

////    public Win()
////    {
////        InitializeComponent();
////        ProductListBox.ItemsSource = Products;
////    }
////    private void AddToBasket_Click(object? sender, RoutedEventArgs e)
////    {
////        if(sender is Button button && button.DataContext is Product product)
////        {
////            int quantityToAdd = 1;
////            basketList.AddToBasket(product, quantityToAdd);
////        }
////    }

////    private void Del_Click(object? sender, RoutedEventArgs e)
////    {
////        if (sender is Button button && button.DataContext is Product deleteProduct)
////        {
////            ProductList.Instance.RemoveProduct(deleteProduct);
////            ProductListBox.ItemsSource = null;
////            ProductListBox.ItemsSource = Products;
////        }
////        if (ProductList.Instance.Products.Count == 0)
////        {
////            ProductListBox.ItemsSource = null;
////            ProductListBox.ItemsSource = new List<string> { "Список продуктов пуст."};
////        }
////    }

////    private void Edit_Click(object? sender, RoutedEventArgs e)
////    {
////        if (sender is Button button && button.DataContext is Product productToEdit)
////        {
////            WinEditProduct editWindow = new WinEditProduct(productToEdit);
////            editWindow.Show();
////            this.Close();
////        }
////    }

////    private void Basket_Click(object? sender, RoutedEventArgs e)
////    {
////        BasketWindow basket = new BasketWindow(Basket);
////        basket.Show();
////        this.Close();
////    }

////    private void Return_Click(object? sender, RoutedEventArgs e)
////    {
////        MainWindow mainWindow = new MainWindow();
////        mainWindow.Show();
////        this.Close();
////    }
////}