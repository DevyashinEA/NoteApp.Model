using System.Collections.Generic;

namespace NoteApp.Model
{
    public class Project
    {
        /// <summary>
        /// Список list.
        /// </summary>
        private List<Note> _listNote = new List<Note>();
        public List<Note> ListNote
        {
            get
            {
                return _listNote;
            }
            set
            {
                _listNote = value;
            }

        }
    }
}