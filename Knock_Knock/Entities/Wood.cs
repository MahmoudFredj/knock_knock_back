using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knock_Knock.Entities
{
    public class Wood
    {
        public int id { get; set; }
        public string name { get; set; }

        public Wood() { }
        public Wood(ref Wood wood)
        {
            this.id = wood.id;
            this.name = wood.name;
        }
        public Wood(int id)
        {
            this.id = id;
        }
        public Wood(object id)
        {
            this.id = Convert.ToInt32(id);
        }
        public Wood(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public Wood(object id,object name)
        {
            this.id = Convert.ToInt32(id);
            this.name = Convert.ToString(name);
        }

    }
}