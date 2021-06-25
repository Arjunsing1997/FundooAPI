using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRl : INoteRl
    {
        private FundooContext1 _userDbContext;
        public NoteRl(FundooContext1 userDbContext)
        {
            _userDbContext = userDbContext;
        }

        /// <summary>
        /// Users the details.
        /// </summary>
        /// <returns></returns>
        public List<NoteResponse> NoteDetails(long UserId)
        {
            List<NoteResponse> response = new List<NoteResponse>();
            var Details = _userDbContext.Notes.Where(s => s.UserId == UserId).ToList();
            if(Details != null)
            {
                foreach(var data in Details)
                {
                    NoteResponse note = new NoteResponse();
                    note.Note_ID = data.Note_ID;
                    note.Header = data.Header;
                    note.Body = data.Body;
                    note.Reminder = data.Reminder;
                    note.Colour = data.Colour;
                    note.Trash = data.Trash;
                    note.Archive = data.Archieve;
                    note.Pin = data.Pin;
                    note.UserId = data.UserId;

                    response.Add(note);
                }
                return response;
            }
            return null;
        }
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        public void AddNote(AddNote note)
        {
            var user = _userDbContext.Users.FirstOrDefault(e => e.UserId == note.UserId);
            if (user != null)
            {
                Notes db = new Notes();
                db.Header = note.Header;
                db.Body = note.Body;
                db.Reminder = note.Reminder;
                db.Colour = note.Colour;
                db.Archieve = note.Archive;
                db.Trash = note.Trash;
                db.Pin = note.Pin;
                db.UserId = note.UserId;

                _userDbContext.Notes.Add(db);
                _userDbContext.SaveChanges();
            }

        }

        public void UpdateNote(Notes note)
        {
            var user = _userDbContext.Users.FirstOrDefault(e => e.UserId == note.UserId);
            if (user != null)
            {
                Notes db = new Notes();
                db.Header = note.Header;
                db.Body = note.Body;
                db.Reminder = note.Reminder;
                db.Colour = note.Colour;
                db.Archieve = note.Archieve;
                db.Trash = note.Trash;
                db.Pin = note.Pin;
                db.UserId = note.UserId;
                _userDbContext.SaveChanges();
            }
        }


    }
}
