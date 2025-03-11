using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts;

public class Product
{
    public string ProductName { get; set; }
    public double ProductCost { get; set; }

    internal Product(string productName, double productCost)
    {
        ProductName = productName;
        ProductCost = productCost;
    }
}