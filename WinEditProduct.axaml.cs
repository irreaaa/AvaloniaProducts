using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaProducts;

public partial class WinEditProduct : Window
{
    public Product _product;

    public WinEditProduct()
    {
        InitializeComponent();
        this.FindControl<Button>("SaveButton").Click += SaveChanges_Click; 
    }

    public WinEditProduct(Product product) : this()
    {
        _product = product;
        this.FindControl<TextBox>("ProductNameTextBox").Text = _product.GetProductName();
        this.FindControl<TextBox>("ProductCostTextBox").Text = _product.GetProductCost().ToString();
    }

    public void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        _product.ProductName = this.FindControl<TextBox>("ProductNameTextBox").Text;
        _product.ProductCost = double.Parse(this.FindControl<TextBox>("ProductCostTextBox").Text);

        this.Close();
    }
}