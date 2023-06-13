using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace BLL
{
    public class ZoneController
    {
        UnitOfWork unitOfWork;
        readonly IMapper _mapper;
        public ZoneController(IMapper mapper, DataContext zoneContext) { unitOfWork = new UnitOfWork(zoneContext); _mapper = mapper; }

        public string CreateAd(MZone mzn)
        {
            MZone zone = mzn;

            var dbZone = _mapper.Map<Zone>(zone);
            unitOfWork.Zones<Zone>().Create(dbZone);
            unitOfWork.Save();

            return $"Price: {zone.Price}\n Character: {zone.Character}\n Attraction:{zone.Attraction}";
        }

        public string DeleteAd(int id)
        {
            if (unitOfWork.Zones<Zone>().Get(id) == null) return "This ad doesn't exist";

            unitOfWork.Zones<Zone>().Delete(id);
            unitOfWork.Save();
            return $"The ad with ID {id} was deleted!";
        }

        public MZone GetZone(int id)
        {
            Zone post = unitOfWork.Zones<Zone>().GetAll().FirstOrDefault(x => x.ID == id);
            MZone newPost = new MZone();

            newPost.Price = post.Price;
            newPost.Character = post.Character;
            newPost.Attraction = post.Attraction;
            newPost.IsActive = post.IsActive;

            return newPost;
        }

        public MZone[] AllAds()
        {
            int size = unitOfWork.Zones<Zone>().GetAll().Count();

            MZone[] arr = new MZone[size];
            Zone[] allAds = unitOfWork.Zones<Zone>().GetAll().ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                Zone item = allAds[i];
                MZone zone = new MZone();
                zone.Price = item.Price;
                zone.Attraction = item.Attraction;
                zone.Character = item.Character;
                zone.IsActive = item.IsActive;

                arr[i] = zone;

                
            }

            return arr;
        }

        public string Deactivate(int id)
        {
            if (unitOfWork.Zones<Zone>().Get(id) == null) return "This ad doesn't exist";

            if (unitOfWork.Zones<Zone>().Get(id).IsActive == true)
                unitOfWork.Zones<Zone>().Get(id).IsActive = false;
            else
                unitOfWork.Zones<Zone>().Get(id).IsActive = true;

            unitOfWork.Save();
            return $"The advertisement with ID {id} was deactivated!";
        }

        public string Activate(int id)
        {
            if (unitOfWork.Zones<Zone>().Get(id) == null) return "This ad doesn't exist";

            if (unitOfWork.Zones<Zone>().Get(id).IsActive == true)
                unitOfWork.Zones<Zone>().Get(id).IsActive = false;
            else
                unitOfWork.Zones<Zone>().Get(id).IsActive = true;

            unitOfWork.Save();
            return $"The advertisement with ID {id} was activated!";
        }
    }
}
