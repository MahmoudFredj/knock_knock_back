using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Knock_Knock.Models.DataAccessLayer;
using Knock_Knock.Entities;

namespace Knock_Knock.Models.BusinessObjectLayer
{
    public class WoodBo:QueryManager
    {
        public WoodBo() : base() { }

        public int addWood(Wood wood)
        {
            int effectedRow = insertWood(wood.name);
            return effectedRow;
        }
        public int addWood(string name)
        {
            int effectedRow = insertWood(name);
            return effectedRow;
        }

        public int editWood(Wood wood)
        {
            int effectedRow = updateWood(wood.id, wood.name);
            return effectedRow;
        }
        public int editWood(int id,string name)
        {
            int effectedRow = updateWood(id, name);
            return effectedRow;
        }

        public int removeWood(Wood wood)
        {
            int effectedRow = deleteWood(wood.id);
            return effectedRow;
        }
        public int removeWood(int id)
        {
            int effectedRow = deleteWood(id);
            return effectedRow;
        }

        public List<Wood> getAllWoods()
        {
            return defaultConverter(selectAllWoods());
        }



        private List<Wood> defaultConverter(DataTable datatable)
        {
            List<Wood> woodList = new List<Wood>();
            try
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow row = datatable.Rows[i];
                    Wood wood = new Wood(row["id"], row["name"]);
                    woodList.Add(wood);
                }
                return woodList;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}