using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace AvaloniaProducts;

public partial class WinEditProduct : Window
{
    public List<Product> Products;

    public WinEditProduct()
    {
        InitializeComponent();
        this.FindControl<Button>("SaveButton").Click += SaveChanges_Click;
    }

    public WinEditProduct(List<Product> products)
    {
        Products = products;
        InitializeComponent();
    }

    public void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {

            Win Win = new Win(Products);
            Win.Show();
            this.Close();


    }

}