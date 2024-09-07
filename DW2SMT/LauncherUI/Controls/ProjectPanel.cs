using DW2SMT.Managers;

namespace DW2SMT.LauncherUI.Controls
{
    public partial class ProjectPanel : UserControl
    {
        RecentFile file;
        public ProjectPanel(RecentFile recentfile, bool other)
        {
            InitializeComponent();

            file = recentfile;

            if (file.project != null)
                label1.Text = file.Name + " - " + Path.GetFileName(file.project.Location);
            else
                label1.Text = file.Name;

            DateLabel.Text = file.Date.ToString();

            if (!other)
            {
                BackColor = Color.FromArgb(189, 195, 199);
            }
            else
            {
                BackColor = Color.FromArgb(236, 240, 241);
            }
        }

        private void ProjectPanel_DoubleClick(object sender, EventArgs e)
        {
            //Load the selected project
            if (ProjectManager.LoadProject(file.Path))
            {
                Editor editor = new Editor();
                editor.Show();
                Launcher.instance.Close();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            RecentManager.RecentFiles.Remove(file);
            RecentManager.SaveRecents();

            (Launcher.instance.CurPage as StartPage).refreshView();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (ProjectManager.LoadProject(file.Path))
            {
                Editor editor = new Editor();
                editor.Show();
                Launcher.instance.Close();
            }
        }
    }
}
