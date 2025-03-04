using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;

namespace AvaloniaProducts;

public partial class Win : Window
{

    private List<Product> _products;
    public Win(List<Product> products)
    {
        InitializeComponent();
        _products = products;
        ListBox listBox = this.FindControl<ListBox>("editProductsListBox");

        foreach (var product in _products)
        {
            TextBlock nameBlock = new TextBlock
            {
                Text = $"\nНазвание: {product.GetProductName()}",
                Foreground = new SolidColorBrush(Color.Parse("#326da8"))
            };

            TextBlock costBlock = new TextBlock
            {
                Text = $"Цена: {product.GetProductCost()} руб.",
                Foreground = new SolidColorBrush(Color.Parse("#326da8"))
            };

            Button editButton = new Button
            {
                Content = "Редактировать продукт",
                FontFamily = "Wellinghton",
                Background = new SolidColorBrush(Color.Parse("#326da8")),
                Foreground = new SolidColorBrush(Color.Parse("#cadbed")),
            };
            editButton.Click += (sender, e) => EditProduct_Click(product);
            

            listBox.Items.Add(nameBlock);
            listBox.Items.Add(costBlock);
            listBox.Items.Add(editButton);
        }
    }
    private async void EditProduct_Click(Product product)
    {
        WinEditProduct editWindow = new WinEditProduct(product, _products);
        await editWindow.Show();
       Close();
    }
}