using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knock_Knock.Entities
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }

        public Role() { }
        public Role(ref Role role)
        {
            this.id = role.id;
            this.name = role.name;
        }
        public Role(int id)
        {
            this.id = id;
        }
        public Role(object id)
        {
            this.id = Convert.ToInt32(id);
        }
        public Role(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public Role(object id, object name)
        {
            this.id = Convert.ToInt32(id);
            this.name = Convert.ToString(name);
        }
    }
}