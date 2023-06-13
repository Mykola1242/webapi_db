using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewBillboardController : Controller
    {
        private BillboardLogic billboardLogic;

        public NewBillboardController(BillboardContext billboardContext)
        {
            billboardLogic = new BillboardLogic(billboardContext);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billboard>>> Get()
        {
            Billboard[] ads = billboardLogic.AllAds();
            return Ok(ads);
            //return await billboardLogic;
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Billboard>> Get(int id)
        {
            Billboard ads = billboardLogic.GetUser(id);
            return Ok(ads);
            //return await billboardLogic;
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateAdd(Billboard billboard)
        {
            string res = billboardLogic.CreateAd(billboard.User, billboard.Category, billboard.Tags);
            return Ok(res);
        }

        //[HttpPost("{id}")]
        //[ActionName("Activate")]
        //public async Task<ActionResult<string>> Activate(int id)
        //{
        //    string res = billboardLogic.Activate(id);
        //    return Ok(res);
        //}

        [HttpPost("Deactivate/{id}")]
        /*[ActionName("Deactivate")]*/
        public async Task<ActionResult<string>> Deactivate(int id)
        {
            string res = billboardLogic.Deactivate(id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteAd(int id)
        {
            string res = billboardLogic.DeleteAd(id);
            return Ok(res);
        }
    }
}
