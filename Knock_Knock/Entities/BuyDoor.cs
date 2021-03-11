using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knock_Knock.Entities
{
    public class BuyDoor
    {
        public int id { get; set; }
        public User user { get; set; }
        public Door door { get; set; }
        public DateTime createdDate { get; set; }
        public int quantity { get; set; }

        BuyDoor() { }
        BuyDoor(BuyDoor buyDoor)
        {
            this.id = buyDoor.id;
            this.user = buyDoor.user;
            this.door = buyDoor.door;
            this.createdDate = buyDoor.createdDate;
            this.quantity = buyDoor.quantity;
        }
        public BuyDoor(int id)
        {
            this.id = id;
        }
        public BuyDoor(object id)
        {
            this.id = Convert.ToInt32(id);
        }
        public BuyDoor(int id,int user,int door,DateTime createdDate, int quantity)
        {
            this.id = id;
            this.user = new User(user);
            this.door = new Door(door);
            this.createdDate = createdDate;
            this.quantity = quantity;
        }
        public BuyDoor(int id,User user,Door door,DateTime createdDate, int quantity)
        {
            this.id = id;
            this.user = user;
            this.door = door;
            this.createdDate = createdDate;
            this.quantity = quantity;
        }
        public BuyDoor(object id,object user,object door,object createdDate,object quantity)
        {
            this.id = Convert.ToInt32(id);
            this.user = new User(user);
            this.door = new Door(door);
            this.createdDate = Convert.ToDateTime(createdDate);
            this.quantity = Convert.ToInt32(quantity);
        }
    }
}