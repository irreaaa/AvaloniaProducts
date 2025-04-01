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

<<<<<<< HEAD
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

=======
        public bool AddToBasket(string productName, int productQuantityInBasket)
        {
>>>>>>> 4f12617 (basket super)
            var productInBasket = Basket.FirstOrDefault(p => p.ProductName == productName);
            var productInStore = ProductList.Instance.Products.FirstOrDefault(p => p.ProductName == productName);

            if (productInStore == null || productInStore.ProductQuantity == 0)
            {
                return false;
            }

            int availableToAdd = Math.Min(productQuantityInBasket, productInStore.ProductQuantity);

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
                    ProductQuantity = availableToAdd,
                    ProductCost = productInStore.ProductCost * availableToAdd
                });
            }

            productInStore.ProductQuantity -= availableToAdd;
<<<<<<< HEAD
=======
            return true;
>>>>>>> 4f12617 (basket super)
        }


        public void RemoveOneFromBasket(string productName, int productQuantityInBasket)
        {
            var productInBasket = Basket.FirstOrDefault(p => p.ProductName == productName);
            var productInStore = ProductList.Instance.Products.FirstOrDefault(p => p.ProductName == productName);

            if (productInBasket == null) return;

<<<<<<< HEAD
            if (productInStore != null)
            {
                productInStore.ProductQuantity += productQuantityInBasket;
            }

            productInBasket.ProductQuantity -= productQuantityInBasket;

=======
            productInBasket.ProductQuantity -= productQuantityInBasket;
            if (productInStore != null)
            {
                productInStore.ProductQuantity += productQuantityInBasket;
                productInBasket.ProductCost = productInStore.ProductCost * productInBasket.ProductQuantity;
            }

>>>>>>> 4f12617 (basket super)
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