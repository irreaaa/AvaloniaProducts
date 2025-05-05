using Avalonia.Media.Imaging;
using System;

namespace AvaloniaProducts;

public class Product
{
    public string ProductName { get; set; }
    public double ProductCost { get; set; }
    public int ProductQuantity { get; set; }
    public string? ProductPhoto {  get; set; }

    public Bitmap? ProductImage
    {
        get
        {
            if (ProductPhoto != "" && ProductPhoto != " " && ProductPhoto != null)
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "AvaloniaProducts/Images/" + ProductPhoto);
            }
            else
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/noPhoto.png");
            }
        }
        set { }
    }
}