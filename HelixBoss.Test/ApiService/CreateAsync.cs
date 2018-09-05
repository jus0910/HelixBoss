using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using HelixBoss.Model;
using HelixBoss.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using HelixBoss.ApiService;

namespace HelixBoss.Test.ApiService
{
    public partial class ProductServiceTest
    {
        
        [Fact]
        public void CreateAsync_Successful()
        {
            Setup();
            var prd = TestData.GetProduct();
            
            _dbContextMock.Setup(ctx => ctx.Products).Returns(_mockSet.Object);
            _dbContextMock.Setup(ctx => ctx.SaveChangesAsync(default(CancellationToken)))
                .ReturnsAsync(1).Verifiable();
            var service = new ProductService(_dbContextMock.Object);
            var result = service.CreateAsync(prd).Result;


            _mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            _dbContextMock.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());

        }
    }
}
