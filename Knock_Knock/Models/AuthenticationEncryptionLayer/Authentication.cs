using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knock_Knock.Entities;
using Knock_Knock.Models.BusinessObjectLayer;

namespace Knock_Knock.Models.AuthenticationEncryptionLayer
{ 
    public class Authentication:UserBo
    {
        public Authentication() : base() { }


        public string registerUser(User user)
        {
            string token = null;
            EncryptionDecryption ed = new EncryptionDecryption();
            UserBo bo = new UserBo();

            user.role = new Role(3, "user");
            bool userExist = bo.checkUserExistance(user.pseudo);
            if (userExist) return "alreadyExist";
            string hashedPassword = ed.hashPassword(user.password);
            user.password = hashedPassword;
            int id = bo.addUser(user);
            if (id < 0) return "error";

            token = ed.generateToken(user);
            return token;
        }

        public string loginUser(User user)
        {
            string token = null;
            EncryptionDecryption ed = new EncryptionDecryption();
            UserBo bo = new UserBo();

            User searchedUser = bo.getUserByPseudo(user);
            if (searchedUser == null) return "wrong credentials";
            bool passwordValid = ed.compare(user.password, searchedUser.password);
            if (!passwordValid) return "wrong credentials";
            token = ed.generateToken(searchedUser);
            return token;
        }
    }
}