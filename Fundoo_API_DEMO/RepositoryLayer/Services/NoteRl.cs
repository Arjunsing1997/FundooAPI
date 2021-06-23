using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRl : INoteRl
    {
        private FundooContext _userDbContext;
        public NoteRl(FundooContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        /// <summary>
        /// Users the details.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> NotesDetails()
        {
            var Details = _userDbContext.Users.ToList();
            return Details;
        }
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        public void AddNotes(Notes note)
        {
            var user = _userDbContext.Users.FirstOrDefault(e => e.UserId == note.UserId);
            note.user = user;
            _userDbContext.Notes.Add(note);
        }

        
    }
}
