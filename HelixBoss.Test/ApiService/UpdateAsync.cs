using HelixBoss.ApiService;
using HelixBoss.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace HelixBoss.Test.ApiService
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void UpdateAsync_Successful()
        {
            var prd = TestData.GetProduct();
            var products = TestData.GetProducts().AsQueryable();
            var localView = new Mock<LocalView<Product>>();

            localView.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            localView.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            localView.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            localView.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            Setup();


            _dbContextMock.Setup(ctx => ctx.Products).Returns(_mockSet.Object);
            _dbContextMock.Setup(ctx => ctx.SaveChangesAsync(default(CancellationToken)))
                .ReturnsAsync(1).Verifiable();

            _mockSet.Setup(ctx => ctx.Local.ToObservableCollection()).Returns(localView.Object.ToObservableCollection());

            var service = new ProductService(_dbContextMock.Object);
            var result = service.UpdateAsync(prd).Result;


            //mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            _dbContextMock.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());

        }
    }
}
