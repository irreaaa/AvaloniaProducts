using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace AvaloniaProducts;

public partial class WinEditProduct : Window
{
    private Product _product;
    public List<Product> _products;

    public WinEditProduct()
    {
        InitializeComponent();
        this.FindControl<Button>("SaveButton").Click += SaveChanges_Click;
    }

    public WinEditProduct(Product product, List<Product> products) : this()
    {
        _product = product;
        _products = products;
        this.FindControl<TextBox>("ProductNameTextBox").Text = _product.GetProductName();
        this.FindControl<TextBox>("ProductCostTextBox").Text = _product.GetProductCost().ToString();
    }

    public async void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        string enteredProductName = ProductNameTextBox.Text;
        if (double.TryParse(ProductCostTextBox.Text, out double enteredCostOfProduct))
        {
            _product.ProductName = enteredProductName;
            _product.ProductCost = enteredCostOfProduct;

            Win Win = new Win(_products);
            Close();
           await Win.Show();
          
        }
        else
        {
            ShowCostErrorMessage();
        }
        
    }

    private void ShowCostErrorMessage()
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", "Некорректная цена продукта.", NotificationType.Error));
    }
}