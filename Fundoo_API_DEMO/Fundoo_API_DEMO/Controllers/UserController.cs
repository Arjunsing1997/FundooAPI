using BusinessLayer;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost]
        public ActionResult AddUser(User user)
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

        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(User user)
        {
            try
            {
                bool isExist = this.userBl.ForgotPassword(user.Email);
                if (isExist) return Ok(new { success = true, message = $"Reset Link sent to {user.Email}" });
                else return BadRequest(new { success = false, message = $"No user Exist with {user.Email}" });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
