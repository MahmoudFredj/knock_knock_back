using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Knock_Knock.Entities
{
    public class User
    {
        public int id { get; set; }
        public string pseudo { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int phoneNumber { get; set; }
        public Role role { get; set; }

        public User() {}
        public User(ref User user)
        {
            this.id = user.id;
            this.pseudo = user.pseudo;
            this.password = user.password;
            this.name = user.name;
            this.phoneNumber = user.phoneNumber;
            this.role = user.role;
        }
        public User(int id)
        {
            this.id = id;
        }
        public User(object id)
        {
            this.id = Convert.ToInt32(id);
        }
        public User(int id,string pseudo ,string password,string name,int phoneNumber,int role)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.role = new Role(role);
        }
        public User(int id,string pseudo, string password,string name,int phoneNumber,Role role)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.role = role;
        }
        public User(object id,object pseudo,object password,object name,object phoneNumber,object role)
        {
            this.id = Convert.ToInt32(id);
            this.pseudo = Convert.ToString(pseudo);
            this.password = Convert.ToString(password);
            this.name = Convert.ToString(name);
            this.phoneNumber = Convert.ToInt32(phoneNumber);
            this.role = new Role(role);
        }

    }
}