using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Knock_Knock.Entities;
using Knock_Knock.Models.BusinessObjectLayer;
using Knock_Knock.Filters;

namespace Knock_Knock.Controllers
{
    public class DoorController : ApiController
    {

        public List<Door> Get()
        {
            DoorBo bo = new DoorBo();
            List<Door> doorList = bo.getAllDoors();
            return doorList;
        }

        [Auth(role = "admin")]
        public Door Post([FromBody]Door door)
        {
            DoorBo bo = new DoorBo();
            int effectedRow = bo.addDoor(door);
            door.id = effectedRow;

            return door;
        }

        [Auth(role ="admin")]
        public Door Put([FromBody]Door door)
        {
            DoorBo bo = new DoorBo();
            int effectedRow =bo.editDoor(door);
            return door;

        }

        [Auth(role = "admin")]
        public IHttpActionResult Delete([FromBody]Door door)
        {
            DoorBo bo = new DoorBo();
            int effectedRow = bo.removeDoor(door);
            if (effectedRow < 0) BadRequest("db query error");
            return Ok(door.id);
        }
    }
}