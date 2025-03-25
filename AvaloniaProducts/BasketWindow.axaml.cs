using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace AvaloniaProducts
{
    public partial class BasketWindow : Window
    {
        public List<Product> Basket => BasketList.Instance.Basket;
        public BasketWindow()
        {
            InitializeComponent();
            BasketListBox.ItemsSource = Basket;
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