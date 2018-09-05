using HelixBoss.ApiService;
using HelixBoss.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace HelixBoss.Test.ApiService
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void DeleteAsync_Successful()
        {
            Setup();

            _dbContextMock.Setup(ctx => ctx.Products)
                .Returns(_mockSet.Object);

            var service = new ProductService(_dbContextMock.Object);
            var result = service.DeleteAsync(1).Result;

            _mockSet.Verify(m => m.Remove(It.IsAny<Product>()), Times.Once());
            _dbContextMock.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }
    }
}
