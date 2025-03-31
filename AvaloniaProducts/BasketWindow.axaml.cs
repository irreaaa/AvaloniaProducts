using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace AvaloniaProducts
{
    public partial class BasketWindow : Window
    {
        public List<Product> Basket => BasketList.Instance.Basket;
        private BasketList basketList = BasketList.Instance;
        public BasketWindow()
        {
            InitializeComponent();
            BasketListBox.ItemsSource = Basket;
        }

        private void AddMoreToBasket_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Product product)
            {
                basketList.AddToBasket(product.ProductName, 1);
                BasketListBox.ItemsSource = null;
                BasketListBox.ItemsSource = Basket;
            }
        }

        private void RemoveOneFromBasket_Click(object? sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is Product product)
            {
                basketList.RemoveOneFromBasket(product.ProductName, 1);
                BasketListBox.ItemsSource = null;
                BasketListBox.ItemsSource = Basket;
            }
        }

        private void RemoveFromBasket_Click(object? sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is Product deleteProductFrombasket)
            {
                BasketList.Instance.RemoveFromBasket(deleteProductFrombasket);
                BasketListBox.ItemsSource = null;
                BasketListBox.ItemsSource = Basket;
            }
            if (BasketList.Instance.Basket.Count == 0)
            {
                BasketListBox.ItemsSource = null;
                BasketListBox.ItemsSource = new List<string> { "Ваша корзина пуста. " };
            }
        }

        private void Return_Click(object? sender, RoutedEventArgs e)
        {
            Win win = new Win();
            win.Show();
            this.Close();
        }
    }
}





//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Interactivity;
//using Avalonia.Markup.Xaml;
//using System.Collections.Generic;

//namespace AvaloniaProducts;

//public partial class BasketWindow : Window
//{
//    private List<Product> Basket { get; }
//    public BasketWindow(List<Product> basket)
//    {
//        InitializeComponent();
//        Basket = basket;
//        BasketListBox.ItemsSource = Basket;
//    }

//    private void Return_Click(object? sender, RoutedEventArgs e)
//    {
//        Win win = new Win();
//        win.Show();
//        this.Close();
//    }
//}