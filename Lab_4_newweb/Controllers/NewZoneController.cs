using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewZoneController : Controller
    {
        private ZoneLogic zoneLogic;

        public NewZoneController(DataContext billboardContext)
        {
            zoneLogic = new ZoneLogic(billboardContext);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MZone>>> Get()
        {
            MZone[] ads = zoneLogic.AllAds();
            return Ok(ads);
            //return await zoneLogic;
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<MZone>> Get(int id)
        {
            MZone ads = zoneLogic.GetUser(id);
            return Ok(ads);
            //return await zoneLogic;
        }


        [HttpPost]
        public async Task<ActionResult<string>> CreateAdd(MZone billboard)
        {
            string res = zoneLogic.CreateAd(billboard.Price, billboard.Character, billboard.Attraction);
            return Ok(res);
        }



        [HttpPost("Deactivate/{id}")]
        /*[ActionName("Deactivate")]*/
        public async Task<ActionResult<string>> Deactivate(int id)
        {
            string res = zoneLogic.Deactivate(id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteAd(int id)
        {
            string res = zoneLogic.DeleteAd(id);
            return Ok(res);
        }
    }
}
