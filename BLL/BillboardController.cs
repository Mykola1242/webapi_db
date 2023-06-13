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
    public class BillboardController
    {
        UnitOfWork unitOfWork;
        readonly IMapper _mapper;
        public BillboardController(IMapper mapper, BillboardContext billboardContext) { unitOfWork = new UnitOfWork(billboardContext); _mapper = mapper; }

        public string CreateAd(Billboard blbrd)
        {
            Billboard billboard = blbrd;

            var dbBillboard = _mapper.Map<DBBillboard>(billboard);
            unitOfWork.Billboards<DBBillboard>().Create(dbBillboard);
            unitOfWork.Save();

            return $"User: {billboard.User}\n Category: {billboard.Category}\n Tags:{billboard.Tags}";
        }

        public string DeleteAd(int id)
        {
            if (unitOfWork.Billboards<DBBillboard>().Get(id) == null) return "This ad doesn't exist";

            unitOfWork.Billboards<DBBillboard>().Delete(id);
            unitOfWork.Save();
            return $"The ad with ID {id} was deleted!";
        }

        public Billboard GetUser(int id)
        {
            DBBillboard post = unitOfWork.Billboards<DBBillboard>().GetAll().FirstOrDefault(x => x.ID == id);
            Billboard newPost = new Billboard();

            newPost.User = post.User;
            newPost.Category = post.Category;
            newPost.Tags = post.Tags;
            newPost.IsActive = post.IsActive;

            return newPost;
        }

        public Billboard[] AllAds()
        {
            int size = unitOfWork.Billboards<DBBillboard>().GetAll().Count();

            Billboard[] arr = new Billboard[size];
            DBBillboard[] allAds = unitOfWork.Billboards<DBBillboard>().GetAll().ToArray();


            for (int i = 0; i < arr.Length; i++)
            {
                DBBillboard item = allAds[i];
                Billboard billboard = new Billboard();
                billboard.User = item.User;
                billboard.Tags = item.Tags;
                billboard.Category = item.Category;
                billboard.IsActive = item.IsActive;

                arr[i] = billboard;

                //if (item.IsActive)

                //    arr[i] = $"User: {item.User}\n Category: {item.Category}\n Tags:{item.Tags}\n Active:{item.IsActive}\n"; 
            }

            return arr;
        }

        public string Deactivate(int id)
        {
            if (unitOfWork.Billboards<DBBillboard>().Get(id) == null) return "This ad doesn't exist";

            if (unitOfWork.Billboards<DBBillboard>().Get(id).IsActive == true)
                unitOfWork.Billboards<DBBillboard>().Get(id).IsActive = false;
            else
                unitOfWork.Billboards<DBBillboard>().Get(id).IsActive = true;

            unitOfWork.Save();
            return $"The advertisement with ID {id} was deactivated!";
        }

        public string Activate(int id)
        {
            if (unitOfWork.Billboards<DBBillboard>().Get(id) == null) return "This ad doesn't exist";

            if (unitOfWork.Billboards<DBBillboard>().Get(id).IsActive == true)
                unitOfWork.Billboards<DBBillboard>().Get(id).IsActive = false;
            else
                unitOfWork.Billboards<DBBillboard>().Get(id).IsActive = true;

            unitOfWork.Save();
            return $"The advertisement with ID {id} was activated!";
        }
    }
}
