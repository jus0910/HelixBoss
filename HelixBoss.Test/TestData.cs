using HelixBoss.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelixBoss.Test
{
    public static class TestData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "apple",
                    Quantity = 4,
                    SaleAmount = 2,
                    CreatedBy = "User1",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "User1",
                    ModifiedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "mango",
                    Quantity = 10,
                    SaleAmount = 3,
                    CreatedBy = "User2",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "User1",
                    ModifiedDate = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "carrot",
                    Quantity = 45,
                    SaleAmount = 1,
                    CreatedBy = "User3",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "User3",
                    ModifiedDate = DateTime.Now
                }
            };
        }

        public static Product GetProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "apple",
                Quantity = 4,
                SaleAmount = 2,
                CreatedBy = "User1",
                CreatedDate = DateTime.Now,
                ModifiedBy = "User1",
                ModifiedDate = DateTime.Now
            };
        }
    }
}
