using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knock_Knock.Entities
{
    public class Door
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float price { get; set; }
        public Wood wood { get; set; }

        public Door() { }
        public Door(ref Door door)
        {
            this.id = door.id;
            this.name = door.name;
            this.description = door.description;
            this.quantity = door.quantity;
            this.width = door.width;
            this.height = door.height;
            this.price = door.price;
            this.wood = door.wood;
        }
        public Door(int id)
        {
            this.id = id;
        }
        public Door(object id)
        {
            this.id = Convert.ToInt32(id);
        }
        public Door(int id,string name,string description,int quatity,float width,float height,float price,int wood)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.width = width;
            this.height = height;
            this.price = price;
            this.wood = new Wood(wood);
        }
        public Door(int id, string name, string description, int quatity, float width, float height, float price, Wood wood)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.width = width;
            this.height = height;
            this.price = price;
            this.wood = wood;
        }
        public Door(object id,object name,object description ,object quantity, object width,object height,object price, object wood)
        {
            this.id = Convert.ToInt32(id);
            this.name = Convert.ToString(name);
            this.description = Convert.ToString(description);
            this.quantity = Convert.ToInt32(quantity);
            this.width = Convert.ToSingle(width);
            this.height = Convert.ToSingle(height);
            this.price = Convert.ToSingle(price);
            this.wood = new Wood(wood);
        }
    }
}