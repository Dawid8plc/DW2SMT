using DW2SMT.LauncherUI.Controls;
using DW2SMT.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW2SMT.LauncherUI
{
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();

            refreshView();

            Launcher.instance.Text = "DW2SMT - Launcher";
        }

        public void refreshView()
        {
            RecentManager.LoadRecents();

            projectPanel.Controls.Clear();

            var projs = RecentManager.RecentFiles;

            for (int i = 0; i < projs.Count; i++)
            {
                ProjectPanel panel = new ProjectPanel(projs[i], i % 2 == 0);

                projectPanel.Controls.Add(panel);
            }

            if (projectPanel.Controls.Count > 6)
            {
                foreach (UserControl item in projectPanel.Controls)
                {
                    item.Width = 454;
                }
            }
        }

        private void createProjBtn_Click(object sender, EventArgs e)
        {
            ProjectManager.CreateNew();

            Editor editor = new Editor();
            editor.Show();
            Launcher.instance.Close();
        }

        private void openProjBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Load the selected project
                if(ProjectManager.LoadProject(openFileDialog1.FileName))
                {
                    Editor editor = new Editor();
                    editor.Show();
                    Launcher.instance.Close();
                }
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            Program.OpenAbout();
        }
    }
}
