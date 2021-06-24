using CommonLayer;
using CommonLayer.RequestModel;
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
        public IEnumerable<Notes> NoteDetails()
        {
            var Details = _userDbContext.Notes.ToList();
            return Details;
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
                db.Archieve = note.Archieve;
                db.Trash = note.Trash;
                db.Pin = note.Pin;
                db.UserId = note.UserId;
                _userDbContext.Notes.Add(db);
                _userDbContext.SaveChanges();
            }

        }


    }
}
