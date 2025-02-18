using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;

namespace AvaloniaProducts;

public partial class Win : Window
{
    public Win(List<Product> products)
    {
        InitializeComponent();
        StackPanel panel = this.FindControl<StackPanel>("Panel");

        foreach (var product in products)
        {
            TextBlock nameBlock = new TextBlock
            {
                Text = $"Название: {product.GetProductName()}",
                Foreground = new SolidColorBrush(Color.Parse("#326da8"))
            };

            TextBlock costBlock = new TextBlock
            {
                Text = $"Цена: {product.GetProductCost()} руб.\n",
                Foreground = new SolidColorBrush(Color.Parse("#326da8"))
            };

            panel.Children.Add(nameBlock);
            panel.Children.Add(costBlock);
        }
    }
}
