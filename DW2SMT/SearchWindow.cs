using DW2SMT.Managers;
using System.Media;

namespace DW2SMT
{
    public partial class SearchWindow : Form
    {
        Editor Editor;

        internal bool forceClose = false;

        public SearchWindow(Editor editor)
        {
            InitializeComponent();

            Editor = editor;
        }

        private void findNextBtn_Click(object sender, EventArgs e)
        {
            bool found = false;
            int selIndex = 0;

            if (Editor.mainListView.SelectedIndices.Count > 0)
                selIndex = Editor.mainListView.SelectedIndices[0];

            if (vanillaRadio.Checked)
            {
                for (int i = selIndex + 1; i < MapManager.curMap.GameStrings.Count; i++)
                {
                    if (MapManager.curMap.GameStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = selIndex + 1; i < ProjectManager.curProject.UserStrings.Count; i++)
                {
                    if (ProjectManager.curProject.UserStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                SystemSounds.Exclamation.Play();
        }

        private void findLastBtn_Click(object sender, EventArgs e)
        {
            bool found = false;
            int selIndex = Editor.mainListView.Items.Count;

            if (vanillaRadio.Checked)
            {
                for (int i = selIndex - 1; i >= 0; i--)
                {
                    if (MapManager.curMap.GameStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = selIndex - 1; i >= 0; i--)
                {
                    if (ProjectManager.curProject.UserStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                SystemSounds.Exclamation.Play();
        }

        private void findFirstBtn_Click(object sender, EventArgs e)
        {
            bool found = false;
            int selIndex = 0;

            if (vanillaRadio.Checked)
            {
                for (int i = selIndex + 1; i < MapManager.curMap.GameStrings.Count; i++)
                {
                    if (MapManager.curMap.GameStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = selIndex + 1; i < ProjectManager.curProject.UserStrings.Count; i++)
                {
                    if (ProjectManager.curProject.UserStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                SystemSounds.Exclamation.Play();
        }

        private void SearchWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.FormOwnerClosing)
            {
                return;
            }

            if (!forceClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void findPreviousBtn_Click(object sender, EventArgs e)
        {
            bool found = false;
            int selIndex = 0;

            if (Editor.mainListView.SelectedIndices.Count > 0)
                selIndex = Editor.mainListView.SelectedIndices[0];

            if (vanillaRadio.Checked)
            {
                for (int i = selIndex - 1; i >= 0; i--)
                {
                    if (MapManager.curMap.GameStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = selIndex - 1; i >= 0; i--)
                {
                    if (ProjectManager.curProject.UserStrings[i].Value.ToLower().Contains(inputBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Editor.mainListView.Items[i].Selected = true;
                        Editor.mainListView.EnsureVisible(i);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                SystemSounds.Exclamation.Play();
        }
    }
}
