using System;

namespace NoteApp.Model
{
    public class Note
    {
        private string _name = "Без имени";
        private NoteCategory _category;
        private string _text;
        private DateTime _dateCreate = DateTime.Now;
        private DateTime _dateChange;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                try
                {
                    if (value.Length > 50 || value.Length < 1)
                        throw new ArgumentException("Имя мeньше 50 знаков или является пустым");
                    _name = value;
                    _dateChange = DateTime.Now;
                }
                catch
                {
                    _name = "Incorrect";
                    _dateChange = DateTime.Now;
                }
            }
        }
        public NoteCategory Category
        {
            get { return _category; }
            set
            {
                _category = value;
                _dateChange = DateTime.Now;
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                _dateChange = DateTime.Now;
            }
        }
        public DateTime DateCreate
        {
            get
            {
                return _dateCreate;
            }
            private set
            {
                _dateCreate = value;
            }
        }
        public DateTime DateChange
        {
            get
            {
                return _dateChange;
            }
            private set
            {
                _dateChange = value;
            }
        }
    }
}