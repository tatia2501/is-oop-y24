using Shops.Services;
using Shops.Tools;
using Shops.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace Shops.Tests
{
    public class Tests
    {
        private IShopsService _shopsService;

        [SetUp]
        public void Setup()
        {
            _shopsService = new ShopsService();
        }
        
        [Test]
        public void DeliveryProductsToShop_ShopContainsProducts()
        {
            Shop shop1 = _shopsService.AddShop("Magnit", "First st., 20");
            Product product1 = _shopsService.AddProduct("Cucumber", 25, 45, shop1);
            Assert.True(_shopsService.IsProductInShop(product1, shop1));
        }

        [Test]
        public void SettingAndChengingProductsPrices_PriceChanched()
        {
            Shop shop1 = _shopsService.AddShop("Lenta", "Second st., 25");
            Product product1 = _shopsService.AddProduct("Cheese", 20, 200, shop1);
            product1.AddPrice(220);
            Assert.AreEqual(product1.Price, 220);
        }

        [Test]
        public void SearchWhereCheaper_ThrowExceptionsOrFound()
        {
            Shop shop1 = _shopsService.AddShop("Okey", "Third st. 64");
            Product product1 = _shopsService.AddProduct("Apple", 40, 30, shop1);
            Shop shop2 = _shopsService.AddShop("Magnit", "Fourth st. 29");
            Product product2 = _shopsService.AddProduct("Apple", 25, 45, shop2);
            Shop shop3 = _shopsService.AddShop("Maksi", "Fifth st. 67");
            Product product3 = _shopsService.AddProduct("Apple", 15, 37, shop3);

            Assert.Catch<ShopsException>(() =>
            {
                Shop shop3 =_shopsService.FindCheapestProduct("Apple", 100);
            });

            Assert.Catch<ShopsException>(() =>
            {
                Shop shop4 = _shopsService.FindCheapestProduct("Banana", 5);
            });

            Shop shop5 = _shopsService.FindCheapestProduct("Apple", 10);
            Assert.True(shop5.ID == 3);
        }

        [Test]
        public void BuyBatchOfProducts()
        {
            Shop shop1 = _shopsService.AddShop("Diksi", "Sixth st. 92");
            Product product1 = _shopsService.AddProduct("Lemon", 30, 20, shop1);
            product1.AddPrice(20);
            Product product2 = _shopsService.AddProduct("Tea", 150, 15, shop1);
            product2.AddPrice(15);
            Product product3 = _shopsService.AddProduct("Sugar", 25, 40, shop1);
            product3.AddPrice(40);

            var buyer1 = new Buyer("Tanya", 1000);
            int MoneyBefore = buyer1.Money;
            List<int> AmountBefore;
            AmountBefore = new List<int>();
            var shopList = new Dictionary<string, int>
            {
                ["Tea"] = 10,
                ["Lemon"] = 2,
                ["Sugar"] = 1
            };
            AmountBefore.Add(150);
            AmountBefore.Add(30);
            AmountBefore.Add(25);
            int i = 0;

            int checkAmount = _shopsService.Buy(shopList, buyer1, shop1);

            Assert.True(buyer1.Money == MoneyBefore - checkAmount);

            foreach (KeyValuePair<string, int> keyValue in shopList)
            {
                string productName = keyValue.Key;
                int amount = keyValue.Value;
                Product product = _shopsService.FindProduct(productName, shop1);
                Assert.True(AmountBefore[i] - product.Amount == amount);
                i++;
            }
        }
    }
}
