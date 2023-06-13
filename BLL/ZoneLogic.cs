using AutoMapper;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class ZoneLogic
    {
        public ZoneController ZoneController;

        public ZoneLogic(DataContext zoneContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingController());
            });

            var mapper = config.CreateMapper();

            var serviceProvider = new ServiceCollection()
               .AddSingleton(mapper)
               .BuildServiceProvider(); 

            ZoneController = new ZoneController(serviceProvider.GetService<IMapper>(), zoneContext);
        }

        public virtual string CreateAd(string price, string character, string attraction)
        {
            MZone zone = new MZone();
            zone.Price = price;
            zone.Character = character;
            zone.Attraction = attraction;

            return ZoneController.CreateAd(zone);
        }

        public virtual MZone GetUser(int id) { return ZoneController.GetZone(id); }

        public virtual string DeleteAd(int id) { return ZoneController.DeleteAd(id); }
        public virtual MZone[] AllAds() { return ZoneController.AllAds(); }
        public virtual string Deactivate(int id) { return ZoneController.Deactivate(id); }
        public virtual string Activate(int id) { return ZoneController.Activate(id); }
    }
}