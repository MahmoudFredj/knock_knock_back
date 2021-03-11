using System;
using System.Data;
using System.Data.SqlClient;

namespace Knock_Knock.Models.DataAccessLayer
{
    public class QueryManager : DatabaseAccess
    {
        public QueryManager() : base() { }

        //Create

        protected int insertUser(string pseudo,string password,string name,int phoneNumber,int role)
        {
            string query = "insert into \"user\" (pseudo,password,name,phoneNumber,role) OUTPUT Inserted.ID values(@pseudo,@password,@name,@phoneNumber,@role)";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@pseudo", pseudo);
            parameters[1] = new SqlParameter("@password", password);
            parameters[2] = new SqlParameter("@name", name);
            parameters[3] = new SqlParameter("@phoneNumber", phoneNumber);
            parameters[4] = new SqlParameter("@role", role);

            int effectedRow = (int)onlineScaler(query, parameters);
            return effectedRow;
        }

        protected int insertWood(string name)
        {
            string query = "insert into wood (name) OUTPUT Inserted.ID values (@name)";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@name", name);

            int effectedRow = (int)onlineScaler(query, parameters);
            return effectedRow;
        }

        protected int insertDoor(string name,string description,int quantity,float width,float height,float price,int wood)
        {
            string query = "insert into door (name,description,quantity,width,height,price,wood) OUTPUT Inserted.ID values (@name,@description,@quantity,@width,@height,@price,@wood)";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@name", name);
            parameters[1] = new SqlParameter("@description", description);
            parameters[2] = new SqlParameter("@quantity", quantity);
            parameters[3] = new SqlParameter("@width", width);
            parameters[4] = new SqlParameter("@height", height);
            parameters[5] = new SqlParameter("@price", price);
            parameters[6] = new SqlParameter("@wood", wood);

            int effectedRow = (int)onlineScaler(query, parameters);
            return effectedRow;
        }

        protected int insertBuyDoor(int user,int door , int quantity ,DateTime createdDate)
        {
            string query = "insert into buyDoor (user,door,quantity,createdDate) OUTPUT Inserted.ID  values (@user,@door,@quantity,@createdDate)";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@user", user);
            parameters[1] = new SqlParameter("@door", door);
            parameters[2] = new SqlParameter("@quantity", quantity);
            parameters[3] = new SqlParameter("@createdDate", createdDate);

            int effectedRow = (int)onlineScaler(query, parameters);
            return effectedRow;
        }

        //Read

        protected DataTable selectAllUsers()
        {
            string query = "select * from \"user\" u inner join role r on u.role=r.id";
            DataTable result = offlineSelection(query);
            return result;
        }
        protected DataTable selectUserByPseudo(string pseudo)
        {
            string query = "select u.*,r.name as roleName from \"user\" u inner join role r on u.role=r.id where u.pseudo=@pseudo";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("pseudo", pseudo);
            DataTable result = onlineSelection(query, parameters);
            return result;
        }
        protected object selectUserCountByPseudo(string pseudo)
        {
            string query = "select top 1 count(*) from \"user\" where pseudo=@pseudo";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("pseudo", pseudo);
            object result = onlineScaler(query, parameters);
            return result;
        }

        protected DataTable selectAllDoors()
        {
            string query = "select * from door d inner join wood w on d.wood=w.id";
            DataTable result = offlineSelection(query);
            return result;
        }

        protected DataTable selectAllWoods()
        {
            string query = "select * from wood";
            DataTable result = offlineSelection(query);
            return result;
        }

        protected DataTable selectAllBuyDoor()
        {
            string query = "select * from buyDoor b inner join door d on b.door=d.id inner join user u on b.user=u.id";
            DataTable result = offlineSelection(query);
            return result;
        }

        protected DataTable selectAllRoles()
        {
            string query = "select * from role";
            DataTable result = offlineSelection(query);
            return result;
        }

        //Update

        protected int updateUser(int id,string pseudo,string password,string name,int phoneNumber,int role)
        {
            string query = "update user set pseudo=@pseudo , password=@password, name=@name,phoneNumber=@phoneNumber , role=@role where id=@id";
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@pseudo", pseudo);
            parameters[1] = new SqlParameter("@password", password);
            parameters[2] = new SqlParameter("@name", name);
            parameters[3] = new SqlParameter("@phoneNumber", phoneNumber);
            parameters[4] = new SqlParameter("@role", role);
            parameters[5] = new SqlParameter("@id", id);

            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

        protected int updateDoor(int id,string name,string description,int quantity,float width,float height,float price ,int wood)
        {
            string query = "update door set name=@name , description=@description ,quantity=@quantity ,widht=@width, height=@height,price=@price ,wood=@wood where id=@id";
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("@name", name);
            parameters[1] = new SqlParameter("@description", description);
            parameters[2] = new SqlParameter("@quantity", quantity);
            parameters[3] = new SqlParameter("@width", width);
            parameters[4] = new SqlParameter("@height", height);
            parameters[5] = new SqlParameter("@price", price);
            parameters[6] = new SqlParameter("@wood", wood);
            parameters[7] = new SqlParameter("@id", id);

            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

        protected int updateWood(int id,string name)
        {
            string query = "update wood set name=@name where id=@id";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@name", name);
            parameters[1] = new SqlParameter("@id", id);
            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

        //Delete

        protected int deleteUser(int id)
        {
            string query = "delete user where id=@id";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

        protected int deleteDoor(int id)
        {
            string query = "delete door where id=@id";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

        protected int deleteWood(int id)
        {
            string query = "delete wood where id=@id";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", id);

            int effectedRow = onlineOperation(query, parameters);
            return effectedRow;
        }

    }
}