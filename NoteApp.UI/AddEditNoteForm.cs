using System;
using System.Windows.Forms;
using NoteApp.Model;
namespace NoteApp.UI
{
    public partial class AddEditNoteForm : Form
    {
        public Note NewNote;
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
        private void OK_Click(object sender, EventArgs e)
        {
            NewNote.Name=TextBoxName.Text;
            NewNote.Text = TextBoxNote.Text;
            NewNote.Category = (NoteCategory)ComboBoxCategory.SelectedItem;
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            NewNote = null;
            Close();
        }
    }
}