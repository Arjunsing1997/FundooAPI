using BusinessLayer;
using BusinessLayer.Interface;
using BusinessLayer.Services;
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
    public class NoteController : ControllerBase
    {
        INoteBl noteBl;
        public NoteController(INoteBl noteBl)
        {
            this.noteBl = noteBl;
        }
        [HttpPost]
        public ActionResult AddUser(Notes note)
        {
            try
            {
                this.noteBl.AddNote(note);
                return this.Ok(new { success = true, message = "Registration Successful " });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpGet]

        public IEnumerable<Notes> UserDetails()
        {
            return noteBl.NoteDetails();
        }
    }
}
