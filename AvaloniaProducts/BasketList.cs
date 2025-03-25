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

        public void AddToBasket(string productName, int productQuantityinBasket)
        {
            var productInStore = ProductList.Instance.Products.FirstOrDefault(p => p.ProductName == productName);

            var productInBasket = Basket.FirstOrDefault(p => p.ProductName == productName);
            if(productInBasket != null)
            {
                int availableToAdd = Math.Min(productQuantityinBasket, productInStore.ProductQuantity - productInBasket.ProductQuantity);
                productInBasket.ProductQuantity += availableToAdd;
                productInBasket.ProductCost = productInStore.ProductCost * productInBasket.ProductQuantity;
            } else
            {
                int availableToAdd = Math.Min(productQuantityinBasket, productInStore.ProductQuantity);
                Basket.Add(new Product
                {
                    ProductName = productName,
                    ProductCost = productInStore.ProductCost * availableToAdd,
                    ProductQuantity = availableToAdd
                });
            }
        }

        public void RemoveFromBasket(Product product)
        {
            if (Basket.Contains(product))
            {
                Basket.Remove(product);
            }
        }
    }
}



//using System;
//using System.Collections.ObjectModel;
//using System.Linq;

//namespace AvaloniaProducts
//{
//    class BasketList
//    {
//        private static BasketList? _instance;
//        public ObservableCollection<Product> Basket { get; private set; }

//        private BasketList()
//        {
//            Basket = new ObservableCollection<Product>();
//        }

//        public static BasketList Instance
//        {
//            get
//            {
//                if (_instance == null)
//                    _instance = new BasketList();
//                return _instance;
//            }
//        }

//        public void AddToBasket(Product product, int quantityToAdd)
//        {
//            if (product == null || quantityToAdd <= 0) return;

//            var basketProduct = Basket.FirstOrDefault(p => p.ProductName == product.ProductName);
//            int availableQuantity = product.ProductQuantity;
//            int currentInBasket = basketProduct?.ProductQuantity ?? 0;
//            int maxCanAdd = availableQuantity - currentInBasket;

//            if (maxCanAdd <= 0) return;

//            if (basketProduct != null)
//            {
//                basketProduct.ProductQuantity += Math.Min(quantityToAdd, maxCanAdd);
//            }
//            else
//            {
//                Basket.Add(new Product
//                {
//                    ProductName = product.ProductName,
//                    ProductCost = product.ProductCost,
//                    ProductQuantity = Math.Min(quantityToAdd, maxCanAdd)
//                });
//            }
//        }

//        public void RemoveFromBasket(Product product)
//        {
//            if (product != null && Basket.Contains(product))
//            {
//                Basket.Remove(product);
//            }
//        }
//    }
//}





////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace AvaloniaProducts
////{
////    class BasketList
////    {
////        private static BasketList? _instance;
////        public List<Product> Basket { get; private set; }

////        private BasketList()
////        {
////            Basket = new List<Product>();
////        }

////        public static BasketList Instance
////        {
////            get
////            {
////                if (_instance == null)
////                    _instance = new BasketList();
////                return _instance;
////            }
////        }

////        public void AddToBasket(Product product, int quantityToAdd)
////        {
////            if (product == null || quantityToAdd <= 0) return;

////            var basketProduct = Basket.FirstOrDefault(p => p.ProductName == product.ProductName);

////            int availableQuantity = product.ProductQuantity; 
////            int currentInBasket = basketProduct?.ProductQuantity ?? 0; 
////            int maxCanAdd = availableQuantity - currentInBasket; 

////            if (maxCanAdd <= 0) return; 

////            if (basketProduct != null)
////            {
////                basketProduct.ProductQuantity += Math.Min(quantityToAdd, maxCanAdd);
////            }
////            else
////            {
////                Basket.Add(new Product
////                {
////                    ProductName = product.ProductName,
////                    ProductCost = product.ProductCost,
////                    ProductQuantity = Math.Min(quantityToAdd, maxCanAdd)
////                });
////            }
////        }

////        public void RemoveFromBasket(Product product)
////        {
////            if (product == null) return;
////            var basketProduct = Basket.FirstOrDefault(p => p.ProductName == product.ProductName);
////            if (basketProduct != null)
////            {
////                Basket.Remove(basketProduct);
////            }
////        }
////    }
////}




//////public bool AddToBasket(Product product)
//////{
//////    if (Basket.ContainsKey(product))
//////    {
//////        if (Basket[product] < product.ProductQuantity)
//////        {
//////            Basket[product]++;
//////        }
//////        return false;
//////    }
//////    else
//////    {
//////        if (product.ProductQuantity > 0)
//////        {
//////            Basket[product] = 1;
//////            return true;
//////        }
//////        return true;
//////    }
//////}

//////public void RemovefromBasket(Product product)
//////{
//////    if (Basket.ContainsKey(product))
//////    {
//////        Basket[product]--;
//////        if (Basket[product] <= 0)
//////            Basket.Remove(product);
//////    }
//////}