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

namespace AvaloniaProducts;

public partial class Win : Window
{
    public List<Product> Products { get; set; }

    public Win(List<Product> products)
    {
        InitializeComponent();
        Products = products;
        ProductListBox.ItemsSource = Products;
    }


    private void Del_Click(object? sender, RoutedEventArgs e)
    {
        if(sender is Button button) 
        {
            Product deleteProduct = (Product)button.DataContext;

            if (Products.Contains(deleteProduct))
            {
                Products.Remove(deleteProduct);
                ProductListBox.ItemsSource = null;
                ProductListBox.ItemsSource = Products;
            }
        }
    }

    private void Edit_Click(object? sender, RoutedEventArgs e)
    {
        WinEditProduct editWindow = new WinEditProduct(Products);
        editWindow.Show();
        this.Close();
    }
}
