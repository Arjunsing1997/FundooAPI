using BusinessLayer;
using CommonLayer;
using CommonLayer.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace Fundoo_API_DEMO.Controllers
{
   
 
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBl;
        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddUser(AddUser user)
        {
            try
            {
                this.userBl.AddUser(user);
                return this.Ok(new { success = true, message = "Registration Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

       
        [HttpGet]
        public IEnumerable<User> UserDetails()
        {

            return userBl.UserDetails();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authentication")]
       
        public ActionResult UserAuthentication(EmailModel eModel)
        {
            try
            {
                var token = this.userBl.UserAuthentication(eModel.Email, eModel.Password);
                if (token == null)
                    return Unauthorized();
                return this.Ok(new { token = token, success = true, message = "Token Generated Successfull" });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(string Email)
        {
            try
            {
               
                bool isExist = this.userBl.ForgotPassword(Email);
                if (isExist) return Ok(new { success = true, message = $"Reset Link sent to {Email}" });
                else return BadRequest(new { success = false, message = $"No user Exist with {Email}" });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("Reset-Password")]
        public ActionResult ResetPassword(string newPass, string confirmPass)
        {
            try
            {
                if (newPass != confirmPass)
                {
                    return Ok(new { success = false, message = "New Password and Confirm Password are not equal." });
                }
                var Claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                var UserEmailObject = Claims?.FirstOrDefault(x => x.Type.Equals("Email", StringComparison.InvariantCultureIgnoreCase))?.Value;
                this.userBl.ResetPassword(UserEmailObject, newPass);
                //return Ok($"Updated Email: {UserEmailObject.Value} NewPassword: {user.Password}");
                return Ok(new { success = true, message = "Password Changed Sucessfully", email = $"{UserEmailObject}" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

        ////Filter specific claim    
        //claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value
    }
}
