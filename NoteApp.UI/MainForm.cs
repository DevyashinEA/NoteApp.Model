using System;
using System.Windows.Forms;
using NoteApp.Model;
namespace NoteApp.UI
{
    public partial class MainForm : Form
    {
        private Project _project;
        public MainForm()
        {
            _project = ProjectManager.Deserializer();
            if (_project == null)
            {
                _project = new Project();
            }
            InitializeComponent();
            foreach (var category in Enum.GetValues(typeof(NoteCategory)))
            {
                ComboBoxCategory.Items.Add(category);
            }
            ComboBoxCategory.Items.Add("All");
            foreach (var note in _project.ListNote.ToArray())
            {
                NoteListBox.Items.Add(note.Name);
            }
        }
        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            AddEditNoteForm addEditNote = new AddEditNoteForm(new Note());
            DialogResult result = addEditNote.ShowDialog();
            if (result == DialogResult.OK)
            {
                _project.ListNote.Add(addEditNote.NewNote);
                NoteListBox.Items.Add(addEditNote.NewNote.Name);
                ProjectManager.Serializer(_project);
            }
        }
        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                int selectedIndex = NoteListBox.SelectedIndex;
                Note selectedNote = _project.ListNote[selectedIndex];
                AddEditNoteForm addEditNote = new AddEditNoteForm(selectedNote);
                DialogResult result = addEditNote.ShowDialog();                if (result == DialogResult.OK)
                {
                    NoteListBox.Items.RemoveAt(selectedIndex);
                    NoteListBox.Items.Add(addEditNote.NewNote.Name);
                    ProjectManager.Serializer(_project);
                }
            }
        }
        private void pictureBoxRemove_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                int selectedIndex = NoteListBox.SelectedIndex;
                _project.ListNote.RemoveAt(selectedIndex);
                NoteListBox.Items.RemoveAt(selectedIndex);
                ProjectManager.Serializer(_project);
                CategoryLabel.Text = "";
                CreateDateLabel.Text = "";
                ModifiedDateLabel.Text = "";
                NoteTextBox.Text = "";
            }
        }
        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndexCategory = ComboBoxCategory.SelectedIndex;
            NoteListBox.Items.Clear();
            CategoryLabel.Text = "";
            CreateDateLabel.Text = "";
            ModifiedDateLabel.Text = "";
            NoteTextBox.Text = "";
            int lenghtEnum=0;
            foreach (int i in NoteCategory.GetValues(typeof(NoteCategory)))
                lenghtEnum = i;
            if (selectedIndexCategory != -1 && selectedIndexCategory < lenghtEnum+1)
            {
                foreach (var note in _project.ListNote.ToArray())
                {
                    if (note.Category == (NoteCategory)selectedIndexCategory)
                        NoteListBox.Items.Add(note.Name);
                }
            }
            else
            {
                foreach (var note in _project.ListNote.ToArray())
                        NoteListBox.Items.Add(note.Name);
            }
        }
        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndexName = NoteListBox.SelectedIndex;
            if (selectedIndexName >= 0)
            {
                Note selectedNote = _project.ListNote[selectedIndexName];
                CategoryLabel.Text = selectedNote.Category.ToString();
                CreateDateLabel.Text = selectedNote.DateCreate.ToString();
                ModifiedDateLabel.Text = selectedNote.DateChange.ToString();
                NoteTextBox.Items.Clear();
                NoteTextBox.Items.Add(selectedNote.Text);
            }
        }
    }
}
