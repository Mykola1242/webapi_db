using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestBLL
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

            mock = new Mock<BillboardLogic>(_billboard);
        }

        [Test]
        public void AllAdsTest()
        {
            Billboard[] allAds = new Billboard[1];
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            mock.Setup(a => a.AllAds()).Returns(allAds);

            Assert.That(mock.Object.AllAds(), Is.Not.Null);
        }

        [Test]
        public void GetUserTest()
        {
            Billboard[] allAds = new Billboard[1];
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            mock.Setup(a => a.GetUser(1)).Returns(u);

            Assert.That(mock.Object.GetUser(1), Is.EqualTo(u));
        }

        [Test]
        public void DeleteTest()
        {
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            string res = "The ad with ID {id} was deleted!";
            mock.Setup(a => a.DeleteAd(1)).Returns(res);

            Assert.That(mock.Object.DeleteAd(1), Is.EqualTo(res));
        }

        [Test]
        public void isActiveTest()
        {
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            string res2 = "The advertisement with ID {id} was activated!";
            mock.Setup(a => a.Activate(1)).Returns(res2);

            Assert.That(mock.Object.Activate(1), Is.EqualTo(res2));
        }

        [Test]
        public void isActiveTest_should_return_diactivated()
        {
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            string res2 = "The advertisement with ID {id} was deactivated!";
            mock.Setup(a => a.Deactivate(1)).Returns(res2);

            Assert.That(mock.Object.Deactivate(1), Is.EqualTo(res2));
        }

        [Test]
        public void DeleteTest_should_return_doesnt_exist()
        {
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            string res = "This ad doesn't exist!";
            mock.Setup(a => a.DeleteAd(3)).Returns(res);

            Assert.That(mock.Object.DeleteAd(3), Is.EqualTo(res));
        }

        [Test]
        public void GetUserTest_should_return_null()
        {
            Billboard u = new Billboard();
            mock.Setup(a => a.CreateAd(u.User, u.Category, u.Tags));
            mock.Setup(a => a.GetUser(1)).Returns(u);

            Assert.That(mock.Object.GetUser(2), Is.EqualTo(null));
        }
    }
}