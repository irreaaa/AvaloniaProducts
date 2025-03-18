using Avalonia;
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

namespace AvaloniaProducts;

public partial class Win : Window
{
    public List<Product> Products => ProductList.Instance.Products;

    public Win()
    {
        InitializeComponent();
        ProductListBox.ItemsSource = Products;
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
            ProductListBox.ItemsSource = new List<string> { "Список продуктов пуст."};
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

    private void Return_Click(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}

