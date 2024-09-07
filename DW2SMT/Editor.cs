using DW2SMT.Data;
using DW2SMT.Managers;
using System.Text;

namespace DW2SMT
{
    public partial class Editor : Form
    {
        bool returning = false;

        SearchWindow searchWindow;

        EncodingInfo[] encodings;

        public Editor()
        {
            InitializeComponent();

            RefreshView();

            Text = "DW2SMT - Editor - " + ProjectManager.curProject.Name;

            searchWindow = new SearchWindow(this);
        }

        void RefreshView()
        {
            projNameBox.Text = ProjectManager.curProject.Name;

            encodings = Encoding.GetEncodings();

            encodingBox.Items.Clear();
            foreach (var item in encodings)
            {
                encodingBox.Items.Add($"{item.DisplayName} - {item.Name} - {item.CodePage}");
            }

            bool encodingFound = false;

            for (int i = 0; i < encodings.Length; i++)
            {
                if (encodings[i].CodePage == ProjectManager.curProject.Encoding.CodePage)
                {
                    encodingBox.SelectedIndex = i;
                    encodingFound = true;
                    break;
                }
            }

            if (!encodingFound)
                encodingBox.SelectedIndex = 0;

            mainListView.Items.Clear();

            foreach (var item in ProjectManager.curProject.UserStrings)
            {
                GameString gs = MapManager.curMap.GameStrings[item.ID];

                ListViewItem lvitem = new ListViewItem(gs.Pos.ToString());
                lvitem.SubItems.Add(gs.Value);
                lvitem.SubItems.Add(item.Value);
                mainListView.Items.Add(lvitem);
            }

            if (mainListView.Items.Count > 0)
                mainListView.Items[0].Selected = true;
        }

        private void mainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainListView.SelectedIndices.Count == 0)
                return;

            vanillaBox.Text = MapManager.curMap.GameStrings[mainListView.SelectedIndices[0]].Value;
            customBox.Text = ProjectManager.curProject.UserStrings[mainListView.SelectedIndices[0]].Value;
        }

        private void customBox_Leave(object sender, EventArgs e)
        {
            if (mainListView.SelectedIndices.Count == 0)
                return;

            mainListView.SelectedItems[0].SubItems[2].Text = customBox.Text;
            ProjectManager.curProject.UserStrings[mainListView.SelectedIndices[0]].Value = customBox.Text;
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (returning) return;
            DialogResult dialogResult = MessageBox.Show("Unsaved changes are going to be lost!", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                searchWindow.forceClose = true;
            }
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (searchWindow != null)
            {
                searchWindow.forceClose = true;
                searchWindow.Close();
            }

            if (Application.OpenForms.Count == 0 && !returning)
            {
                Application.Exit();
            }
        }

        private void returnToLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Unsaved changes are going to be lost!", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            returning = true;
            Close();

            ProjectManager.curProject = null;

            Launcher launcher = new Launcher();
            launcher.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.OpenAbout();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customBox.Focused || projNameBox.Focused)
                ActiveControl = null;

            if (string.IsNullOrWhiteSpace(ProjectManager.curProject.Location))
            {
                SaveAs();
                return;
            }

            ProjectManager.SaveProject();
            RecentManager.UpdateProject(ProjectManager.curProject);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customBox.Focused || projNameBox.Focused)
                ActiveControl = null;

            SaveAs();
        }

        void SaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ProjectManager.curProject.Location = saveFileDialog1.FileName;

                ProjectManager.SaveProject();

                RecentManager.OpenedProject(ProjectManager.curProject, ProjectManager.curProject.Location);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (ProjectManager.LoadProject(openFileDialog1.FileName))
                {
                    Editor editor = new Editor();
                    editor.Show();

                    returning = true;
                    Close();
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Unsaved changes are going to be lost!", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            ProjectManager.CreateNew();

            Editor editor = new Editor();
            editor.Show();

            returning = true;
            Close();
        }

        private void projNameBox_Leave(object sender, EventArgs e)
        {
            ProjectManager.curProject.Name = projNameBox.Text;

            if (string.IsNullOrWhiteSpace(projNameBox.Text))
            {
                Text = "DW2SMT - Editor - Untitled";
            }
            else
            {
                Text = "DW2SMT - Editor - " + ProjectManager.curProject.Name;
            }
        }

        private void ovewriteCustomWithVanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This is going to replace ALL of your custom text with the vanilla ones. It cannot be reverted, are you sure?", "Wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (customBox.Focused)
                    ActiveControl = null;

                for (int i = 0; i < ProjectManager.curProject.UserStrings.Count; i++)
                {
                    UserString? item = ProjectManager.curProject.UserStrings[i];
                    item.Value = MapManager.curMap.GameStrings[i].Value;

                    mainListView.Items[i].SubItems[2].Text = item.Value;
                }
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                if (searchWindow.Visible)
                    searchWindow.Focus();
                else
                    searchWindow.Show(this);
                e.Handled = true;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchWindow.Visible)
                searchWindow.Focus();
            else
                searchWindow.Show(this);
        }

        private void encodingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectManager.curProject.Encoding = Encoding.GetEncoding(encodings[encodingBox.SelectedIndex].CodePage);
        }
    }
}
