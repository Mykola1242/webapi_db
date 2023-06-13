using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestBLL
{
    public class ZonewTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _zone;
        private Mock<ZoneLogic> mock;

        public ZonewTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _zone = new DataContext(options);
            _unitOfWork = new UnitOfWork(_zone);

            mock = new Mock<ZoneLogic>(_zone);
        }

        [Test]
        public void AllAdsTest()
        {
            MZone[] allAds = new MZone[1];
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            mock.Setup(a => a.AllAds()).Returns(allAds);

            Assert.That(mock.Object.AllAds(), Is.Not.Null);
        }

        [Test]
        public void GetZoneTest()
        {
            MZone[] allAds = new MZone[1];
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            mock.Setup(a => a.GetUser(1)).Returns(u);

            Assert.That(mock.Object.GetUser(1), Is.EqualTo(u));
        }

        [Test]
        public void DeleteTest()
        {
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            string res = "The ad with ID {id} was deleted!";
            mock.Setup(a => a.DeleteAd(1)).Returns(res);

            Assert.That(mock.Object.DeleteAd(1), Is.EqualTo(res));
        }

        [Test]
        public void isActiveTest()
        {
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            string res2 = "The advertisement with ID {id} was activated!";
            mock.Setup(a => a.Activate(1)).Returns(res2);

            Assert.That(mock.Object.Activate(1), Is.EqualTo(res2));
        }

        [Test]
        public void isActiveTest_should_return_diactivated()
        {
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            string res2 = "The advertisement with ID {id} was deactivated!";
            mock.Setup(a => a.Deactivate(1)).Returns(res2);

            Assert.That(mock.Object.Deactivate(1), Is.EqualTo(res2));
        }

        [Test]
        public void DeleteTest_should_return_doesnt_exist()
        {
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            string res = "This ad doesn't exist!";
            mock.Setup(a => a.DeleteAd(3)).Returns(res);

            Assert.That(mock.Object.DeleteAd(3), Is.EqualTo(res));
        }

        [Test]
        public void GetZonesTests_should_return_null()
        {
            MZone u = new MZone();
            mock.Setup(a => a.CreateAd(u.Price, u.Character, u.Attraction));
            mock.Setup(a => a.GetUser(1)).Returns(u);

            Assert.That(mock.Object.GetUser(2), Is.EqualTo(null));
        }
    }
}