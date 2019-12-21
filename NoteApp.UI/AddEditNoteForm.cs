using System;
using System.Windows.Forms;
using NoteApp.Model;
namespace NoteApp.UI
{
    /// <summary>
    /// Форма для работы с текущей заметкой.
    /// </summary>
    public partial class AddEditNoteForm : Form
    {
        public Note NewNote;
        /// <summary>
        ///Инициализация формы
        /// </summary>
        public AddEditNoteForm(Note ImportNote)
        {
            InitializeComponent();
            foreach (var note in Enum.GetValues(typeof(NoteCategory)))
            {
                ComboBoxCategory.Items.Add(note);
            }
            NewNote = ImportNote;
            TextBoxName.Text = NewNote.Name;
            TextBoxNote.Text = NewNote.Text;
            ComboBoxCategory.SelectedItem = NewNote.Category;
        }
        /// <summary>
        /// Кнопка ОК.
        /// </summary>
        private void OK_Click(object sender, EventArgs e)
        {
            NewNote.Name=TextBoxName.Text;
            NewNote.Text = TextBoxNote.Text;
            NewNote.Category = (NoteCategory)ComboBoxCategory.SelectedItem;
            Close();
        }
        /// <summary>
        /// Кнопка Cancel.
        /// </summary>
        private void Cancel_Click(object sender, EventArgs e)
        {
            NewNote = null;
            Close();
        }
    }
}