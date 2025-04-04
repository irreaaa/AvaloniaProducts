﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts
{
    class ProductList
    {
        private static ProductList? _instance;
        public List<Product> Products { get; private set; }

        public ProductList()
        {
            Products = new List<Product>();
        }

        public static ProductList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductList();
                return _instance;
            }

        }

        public void AddProduct(string productName, double productCost, int productQuantity)
        {
            Products.Add(new Product { ProductName = productName, ProductCost = productCost, ProductQuantity = productQuantity });
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