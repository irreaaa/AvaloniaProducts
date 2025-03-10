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

    public WinEditProduct(Product product, List<Product> products)
    {
        _product = product;
        _products = products;
        InitializeComponent();
        ProductNameTextBox.Text = _product.ProductName;
        ProductCostTextBox.Text = _product.ProductCost.ToString();
    }

    public void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        string enteredProductName = ProductNameTextBox.Text;
        if (double.TryParse(ProductCostTextBox.Text, out double enteredCostOfProduct))
        {
            _product.ProductName = enteredProductName;
            _product.ProductCost = enteredCostOfProduct;

            Win Win = new Win(_products);
           Win.Show();
            this.Close();
          
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