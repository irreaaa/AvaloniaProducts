using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.IO;

namespace AvaloniaProducts;

public partial class WinEditProduct : Window
{
    private Product _product;
    private ProductList productList = ProductList.Instance;
    private string? _newPhoto = null;

    public WinEditProduct(Product product)
    {
        InitializeComponent();
        _product = product;

        ProductNameTextBox.Text = _product.ProductName;
        ProductCostTextBox.Text = _product.ProductCost.ToString();
        ProductQuantityTextBox.Text = _product.ProductQuantity.ToString();

        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Images/", _product.ProductPhoto ?? "noPhoto.png");
        ProductImage.Source = new Bitmap(imagePath);

        BtnDeleteImage.IsVisible = _product.ProductPhoto != "noPhoto.png";
    }


    private async void AddImage_Click(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var dialog = await openFileDialog.ShowAsync(this);

        if (dialog != null && dialog.Length > 0)
        {
            string fileName = dialog[0];
            Random random = new Random();
            string newFileName = "photo" + random.Next(1, 1000) + ".jpg";
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Images/", newFileName);
            File.Copy(fileName, imagePath, true);
            _newPhoto = newFileName;
            ProductImage.Source = new Bitmap(imagePath);
            BtnDeleteImage.IsVisible = true;
        }
    }


    private void DeleteImage_Click(object? sender, RoutedEventArgs e)
    {
        _newPhoto = null;
        _product.ProductPhoto = "noPhoto.png";
        ProductImage.Source = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/noPhoto.png");
        BtnDeleteImage.IsVisible = false;
    }


    private void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text))
        {
            ShowError("Название продукта не может быть пустым.");
            return;
        }

        if (!double.TryParse(ProductCostTextBox.Text, out double newCost) || newCost <= 0)
        {
            ShowError("Введите корректную цену.");
            return;
        }

        if (!int.TryParse(ProductQuantityTextBox.Text, out int newQuantity) || newQuantity < 0)
        {
            ShowError("Введите корректное количество.");
            return;
        }

        _product.ProductName = ProductNameTextBox.Text;
        _product.ProductCost = newCost;
        _product.ProductQuantity = newQuantity;
        _product.ProductPhoto = _newPhoto ?? _product.ProductPhoto; 

        ReturnToList();
    }

    private void ShowError(string message)
    {
        var notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.BottomCenter
        };
        notificationManager.Show(new Notification("Ошибка", message, NotificationType.Error));
    }

    private void Return_Click(object? sender, RoutedEventArgs e) => ReturnToList();

    private void ReturnToList()
    {
        var win = new Win();
        win.Show();
        this.Close();
    }
}
