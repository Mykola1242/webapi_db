using AutoMapper;
using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NSubstitute;
using Assert = NUnit.Framework.Assert;

namespace BLLTest
{
    public class BillboardTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BillboardContext _billboard;
        private Mock<BillboardLogic> mock;

        public BillboardTest()
        {
            var options = new DbContextOptionsBuilder<BillboardContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _billboard = new BillboardContext(options);
            _unitOfWork = new UnitOfWork(_billboard);
    
            mock = new Mock<BillboardLogic>();
        }


        [Fact]
        public void Test1()
        {
            Billboard[] allAds = new Billboard[1];
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            mock.Setup(a => a.AllAds()).Returns(allAds);

            Assert.That(mock.Object.AllAds(), Is.Not.Null);
        }
    }
}