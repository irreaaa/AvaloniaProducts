using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts;

public class Product
{
    public string ProductName;
    public double ProductCost;

    internal Product(string productName, double productCost)
    {
        ProductName = productName;
        ProductCost = productCost;
    }

    public string GetProductName()
    {
        return ProductName;
    }

    public double GetProductCost()
    {
        return ProductCost;
    }

}