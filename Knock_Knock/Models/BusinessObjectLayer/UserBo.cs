using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knock_Knock.Models.DataAccessLayer;
using Knock_Knock.Entities;
using System.Data;

namespace Knock_Knock.Models.BusinessObjectLayer
{
    public class UserBo : QueryManager
    {
        public UserBo() : base() { }

        public int addUser(User user) {
            int effectedRow = insertUser(user.pseudo, user.password,user.name,user.phoneNumber, user.role.id);
            return effectedRow;
        }
        public int addUser(string pseudo,string password,string name,int phoneNumber,Role role)
        {
            int effectedRow = insertUser(pseudo, password, name, phoneNumber, role.id);
            return effectedRow;
        }
        public int addUser(string pseudo,string password,string name,int phoneNumber,int role)
        {
            int effectedRow = insertUser(pseudo, password, name, phoneNumber, role);
            return effectedRow;
        }

        public int editUser(User user)
        {
            int effectedRow = updateUser(user.id,user.pseudo,user.password,user.name,user.phoneNumber,user.role.id);
            return effectedRow;
        }
        public int editUser(int id,string pseudo,string password, string name,int phoneNumber,Role role)
        {
            int effectedRow = updateUser(id, pseudo, password, name, phoneNumber, role.id);
            return effectedRow;
        }
        public int editUser(int id,string pseudo,string password,string name,int phoneNumber,int role)
        {
            int effectedRow = updateUser(id, pseudo, password, name, phoneNumber, role);
            return effectedRow;
        }

        public int removeUser(User user)
        {
            int effectedRow = deleteUser(user.id);
            return effectedRow;
        }
        public int removeUser(int id)
        {
            int effectedRow = deleteUser(id);
            return effectedRow;
        }

        public List<User> getAllUsers()
        {
            List<User> userList = defaultConverter(selectAllUsers());
            return userList;
        }

        public User getUserByPseudo(User user)
        {
            List<User> userList = poppulatedConverter(selectUserByPseudo(user.pseudo));
            if (userList==null||userList.Count==0) return null;
            User result = userList[0];
            return result;
        }
        public User getUserByPseudo(string pseudo)
        {
            List<User> userList = poppulatedConverter(selectUserByPseudo(pseudo));
            if (userList == null) return null;
            User result = userList[0];
            return result;
        }
        public bool checkUserExistance(User user)
        {
            object count = selectUserCountByPseudo(user.pseudo);
            return (int)count > 0;
        }
        public bool checkUserExistance(string pseudo)
        {
            object count = selectUserCountByPseudo(pseudo);
            return (int)count > 0;
        }

        private List<User> defaultConverter(DataTable datatable)
        {
            List<User> userList = new List<User>();
            try
            {
                for(int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow row = datatable.Rows[i];

                    User user = new User(
                        row["id"],
                        row["pseudo"],
                        row["password"],
                        row["name"],
                        row["phoneNumber"],
                        row["role"]
                        );
                    userList.Add(user);
                }

                return userList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<User> poppulatedConverter(DataTable datatable)
        {
            List<User> userList = new List<User>();
            try
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow row = datatable.Rows[i];

                    User user = new User(
                        row["id"],
                        row["pseudo"],
                        row["password"],
                        row["name"],
                        row["phoneNumber"],
                        row["role"]);
                    user.role.name=(string)row["roleName"];
                    userList.Add(user);
                }

                return userList;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("error user converter populated = ",e.Message);
                return null;
            }
        }
    }
}