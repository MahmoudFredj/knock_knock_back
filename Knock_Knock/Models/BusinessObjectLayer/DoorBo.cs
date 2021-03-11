using System;
using System.Collections.Generic;
using System.Data;
using Knock_Knock.Models.DataAccessLayer;
using Knock_Knock.Entities;
namespace Knock_Knock.Models.BusinessObjectLayer
{
    public class DoorBo : QueryManager
    {
        public DoorBo() : base() { }

        public int addDoor(Door door)
        {
            int effectedRow = insertDoor(door.name, door.description, door.quantity, door.width, door.height, door.price, door.wood.id);
            return effectedRow;
        }
        public int addDoor(string name,string description,int quantity,float width,float height,float price,Wood wood)
        {
            int effectedRow = insertDoor(name, description, quantity, width, height, price, wood.id);
            return effectedRow;
        }
        public int addDoor(string name, string description, int quantity, float width, float height, float price, int wood)
        {
            int effectedRow = insertDoor(name, description, quantity, width, height, price, wood);
            return effectedRow;
        }

        public int editDoor(Door door)
        {
            int effectedRow = updateDoor(door.id, door.name, door.description, door.quantity, door.width, door.height, door.price,door.wood.id);
            return effectedRow;
        }
        public int editDoor(int id,string name, string description, int quantity, float width, float height, float price, Wood wood)
        {
            int effectedRow = updateDoor(id, name, description, quantity, width, height, price, wood.id);
            return effectedRow;
        }
        public int editDoor(int id, string name, string description, int quantity, float width, float height, float price, int wood)
        {
            int effectedRow= updateDoor(id, name, description, quantity, width, height, price, wood);
            return effectedRow;
        }

        public int removeDoor(Door door)
        {
            int effectedRow = deleteDoor(door.id);
            return effectedRow;
        }
        public int removeDoor(int id)
        {
            int effectedRow = deleteDoor(id);
            return effectedRow;
        }

        public List<Door> getAllDoors()
        {
            List<Door> doorList = defaultConverter(selectAllDoors());
            return doorList;
        }




        private List<Door> defaultConverter(DataTable datatable)
        {
            List<Door> doorList = new List<Door>();
            try
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow row = datatable.Rows[i];

                    Door door = new Door(
                        row["id"],
                        row["name"],
                        row["description"],
                        row["quantity"],
                        row["width"],
                        row["height"],
                        row["price"],
                        row["wood"]
                        );
                    doorList.Add(door);
                }

                return doorList;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}