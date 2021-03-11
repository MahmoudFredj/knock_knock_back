using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Knock_Knock.Models.BusinessObjectLayer;
using Knock_Knock.Entities;

namespace Knock_Knock.Controllers
{
    public class WoodController : ApiController
    {

        // GET api/<controller>
        public List<Wood> Get()
        {
            WoodBo bo = new WoodBo();
            List<Wood> woodList = bo.getAllWoods();
            return woodList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Wood Post([FromBody]Wood wood)
        {
            WoodBo bo = new WoodBo();
            int effectedRow = bo.addWood(wood);
            wood.id = effectedRow;
            return wood;
        }

        // PUT api/<controller>/5
        public Wood Put([FromBody]Wood wood)
        {
            WoodBo bo = new WoodBo();
            int effectedRow = bo.editWood(wood);
            return wood;
        }

        // DELETE api/<controller>/5
        public int Delete([FromBody]Wood wood)
        {
            WoodBo bo = new WoodBo();
            int effectedRow = bo.removeWood(wood);
            return effectedRow;
        }
    }
}