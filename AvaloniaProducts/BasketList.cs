using Avalonia.Controls.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaProducts
{
    class BasketList
    {
        public static BasketList? _instance;
        public List<Product> Basket { get; private set; }

        public BasketList()
        {
            Basket = new List<Product>();
        }

        public static BasketList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BasketList();
                return _instance;
            }
        }

        public void AddToBasket(string productName, int productQuantityInBasket)
        {
            var productInStore = ProductList.Instance.Products?.FirstOrDefault(p => p.ProductName == productName);
            if (productInStore == null || productInStore.ProductQuantity == 0)
            {
                var notificationManager = new WindowNotificationManager()
                {
                    Position = NotificationPosition.BottomCenter
                };
                notificationManager.Show(new Notification("Ошибка", "Такого продукта больше нет.", NotificationType.Error));
                return;
            }

            var productInBasket = Basket.FirstOrDefault(p => p.ProductName == productName);

            int availableToAdd = Math.Min(productQuantityInBasket, productInStore.ProductQuantity);

            if (productInBasket != null)
            {
                productInBasket.ProductQuantity += availableToAdd;
                productInBasket.ProductCost = productInStore.ProductCost * productInBasket.ProductQuantity;
            }
            else
            {
                Basket.Add(new Product
                {
                    ProductName = productName,
                    ProductCost = productInStore.ProductCost * availableToAdd,
                    ProductQuantity = availableToAdd
                });
            }

            productInStore.ProductQuantity -= availableToAdd;
        }


        public void RemoveOneFromBasket(string productName, int productQuantityInBasket)
        {
            var productInBasket = Basket.FirstOrDefault(p => p.ProductName == productName);
            var productInStore = ProductList.Instance.Products.FirstOrDefault(p => p.ProductName == productName);

            if (productInBasket == null) return;

            if (productInStore != null)
            {
                productInStore.ProductQuantity += productQuantityInBasket;
            }

            productInBasket.ProductQuantity -= productQuantityInBasket;

            if (productInBasket.ProductQuantity <= 0)
            {
                Basket.RemoveAll(p => p.ProductName == productName);
            }
        }



        public void RemoveFromBasket(Product product)
        {
            if (Basket.Contains(product))
            {
                var productInStore = ProductList.Instance.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
                if (productInStore != null)
                {
                    productInStore.ProductQuantity += product.ProductQuantity;
                }

                Basket.Remove(product);
            }
        }

    }
}