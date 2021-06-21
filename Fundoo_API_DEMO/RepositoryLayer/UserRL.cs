using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CommonLayer;
using Microsoft.IdentityModel.Tokens;

namespace RepositoryLayer
{
    public class UserRL : IUserRL
    {

        private FundooContext _userDbContext;
        public UserRL(FundooContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public User AddUser(User newuser)
        {
            _userDbContext.Users.Add(newuser);  //"Users" is a Data base name
            _userDbContext.SaveChanges();
            return newuser;
        }

        public IEnumerable<User> UserDetails()
        {
            var Details = _userDbContext.Users.ToList();
            return Details;
        }

        public string UserAuthentication(string email, string password)
        {
            try
            {
                var result = _userDbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (result == null)
                    return null;
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("HelloThisTokenIsGeneretedByMe");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, email)

                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
