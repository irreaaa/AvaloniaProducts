using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts
{
    class ProductList
    {
        private static ProductList? _products;
        public List<Product> Products { get; private set; }

        public ProductList()
        {
            Products = new List<Product>();
        }

        public static ProductList Instance
        {
            get
            {
                if (_products == null)
                    _products = new ProductList();
                return _products;
            }
        }

        public void AddProduct(string productName, double productCost)
        {
            Products.Add(new Product { ProductName = productName, ProductCost = productCost });
        }

        public void RemoveProduct(Product product)
        {
            if (product != null && Products.Contains(product))
            {
                Products.Remove(product);
            }
        }
    }
}
