using HelixBoss.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelixBoss.Test.ApiService
{
    public partial class ProductServiceTest
    {
        private Mock<ProductContext> _dbContextMock { get; set; }
        private Mock<DbSet<Product>> _mockSet { get; set; }

        public void Setup()
        {
            var products = TestData.GetProducts().AsQueryable();

            _mockSet = new Mock<DbSet<Product>>();
            _dbContextMock = new Mock<ProductContext>();

            _mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            _mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
        }
    }
}
