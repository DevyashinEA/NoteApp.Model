using System;
using System.Windows.Forms;
using NoteApp.Model;

namespace NoteApp.UI
{
    public partial class FormMain : Form
    {
        private Project _project;
        public FormMain()
        {
            _project = ProjectManager<Project>.Deserializer(@"ListNote.Mylb");
            if (_project == null)
            {
                _project = new Project();
            }
            InitializeComponent();
            foreach (var note in _project.ListNote.ToArray())
            {
                NoteListBox.Items.Add(note.Name);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddEditNote addEditNote = new FormAddEditNote(new Note());
            addEditNote.ShowDialog();
            if (addEditNote.NewNote != null)
            {
                _project.ListNote.Add(addEditNote.NewNote);
                NoteListBox.Items.Add(addEditNote.NewNote.Name);
                ProjectManager<Project>.Serializer(_project, @"ListNote.Mylb");
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                int selectedIndex = NoteListBox.SelectedIndex;
                Note selectedNote = _project.ListNote[selectedIndex];
                FormAddEditNote addEditNote = new FormAddEditNote(selectedNote);
                addEditNote.ShowDialog();
                NoteListBox.Items.RemoveAt(selectedIndex);
                NoteListBox.Items.Add(addEditNote.NewNote.Name);
                ProjectManager<Project>.Serializer(_project, @"ListNote.Mylb");
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (NoteListBox.SelectedIndex != -1)
            {
                int selectedIndex = NoteListBox.SelectedIndex;
                _project.ListNote.RemoveAt(selectedIndex);
                NoteListBox.Items.RemoveAt(selectedIndex);
                ProjectManager<Project>.Serializer(_project, @"ListNote.Mylb");
            }
        }
    }
}
