using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Knock_Knock.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;

namespace Knock_Knock.Models.AuthenticationEncryptionLayer
{
    public class EncryptionDecryption
    {
        private string privateKey;
        private string issuer;
        public EncryptionDecryption()
        {
            privateKey = "relax_this_is_just_for_job_hiring-------";
            issuer = "knock_knock";
        }


        public bool compare(string password,string hashedPassword)
        {
            string hash = hashPassword(password);
            return hash.Equals(hashedPassword);
        }

        public bool validateToken(string token)
        {
            SymmetricSecurityKey privateSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(privateKey));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = privateSecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string getRole(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken decoded = tokenHandler.ReadJwtToken(token);
            List<Claim> claims= decoded.Claims.ToList();
            for(int i = 0; i < claims.Count; i++)
            {
                if (claims[i].Type == "role") return claims[i].Value;
            }
            return null;
        }

        public string generateToken(User user)
        {
            byte[] key = Encoding.UTF8.GetBytes(privateKey);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new Claim[3];
            claims[0] = new Claim("role", user.role.name);
            claims[1] = new Claim(JwtRegisteredClaimNames.Email, user.pseudo);
            claims[2] = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            JwtSecurityToken token = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.AddMonths(1), signingCredentials: credentials);
            string encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }

        public string hashPassword(string password)
        {
            byte[] plainPassNSalt = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(new SHA256Managed().ComputeHash(plainPassNSalt));
        }
    }
}