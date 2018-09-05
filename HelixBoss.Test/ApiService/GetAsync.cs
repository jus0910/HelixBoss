using HelixBoss.ApiService;
using HelixBoss.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace HelixBoss.Test.ApiService
{
    public partial class ProductServiceTest
    {
        [Fact]
        public void GetAsync_Successful()
        {
            Setup();

            _dbContextMock.Setup(ctx => ctx.Products)
                .Returns(_mockSet.Object);

            var service = new ProductService(_dbContextMock.Object);
            var result = service.GetAsync(1).Result;

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetAllAsync_Successful()
        {
            Setup();

            _dbContextMock.Setup(ctx => ctx.Products)
                .Returns(_mockSet.Object);


            var service = new ProductService(_dbContextMock.Object);
            var result = service.GetAllAsync().Result;

            Assert.NotNull(result);
            Assert.Equal(1, result.First().Id);
        }
    }
}
