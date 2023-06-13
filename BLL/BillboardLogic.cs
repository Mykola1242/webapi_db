using AutoMapper;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class BillboardLogic
    {
        public BillboardController BillboardController;

        public BillboardLogic(BillboardContext billboardContext)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingController());
            });

            var mapper = config.CreateMapper();

            var serviceProvider = new ServiceCollection()
               .AddSingleton(mapper)
               .BuildServiceProvider(); 

            BillboardController = new BillboardController(serviceProvider.GetService<IMapper>(), billboardContext);
        }

        public virtual string CreateAd(string user, string category, string tags)
        {
            Billboard billboard = new Billboard();
            billboard.User = user;
            billboard.Category = category;
            billboard.Tags = tags;

            return BillboardController.CreateAd(billboard);
        }

        public virtual Billboard GetUser(int id) { return BillboardController.GetUser(id); }

        public virtual string DeleteAd(int id) { return BillboardController.DeleteAd(id); }
        public virtual Billboard[] AllAds() { return BillboardController.AllAds(); }
        public virtual string Deactivate(int id) { return BillboardController.Deactivate(id); }
        public virtual string Activate(int id) { return BillboardController.Activate(id); }
    }
}