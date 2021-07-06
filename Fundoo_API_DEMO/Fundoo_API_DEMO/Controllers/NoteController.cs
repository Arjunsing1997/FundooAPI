using BusinessLayer;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Fundoo_API_DEMO.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteBl noteBl;
        //FundooContext1 fundooContext1;
        public NoteController(INoteBl noteBl)
        {
            this.noteBl = noteBl;
        }

        [HttpPost]
        public ActionResult AddNote(AddNote note)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals(note.UserId));
                this.noteBl.AddNote(note);
                return this.Ok(new { success = true, message = $"Notes Added with UserId: {note.UserId}." });
    
            }

            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpGet("Details")]

        public List<NoteResponse> NoteDetails(int Note_ID)
        {
            return noteBl.NoteDetails(Note_ID);
        }

        [HttpPut("UPDATE")]
        public ActionResult UpdateNote(NoteUpdateModel note)
        {
            try
            {
                this.noteBl.UpdateNote(note);
                return Ok(new { success = true, message = $"Note Successfully Updated" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        [HttpPatch("ColourUpdate")]
        public ActionResult ColourUpdate(int Note_Id, string Colour)
        {
            try
            {
                this.noteBl.ColourUpdate(Note_Id,Colour);
                return Ok(new { success = true, message = $"Note Successfully Updated" });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
