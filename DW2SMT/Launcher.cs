using DW2SMT.LauncherUI;

namespace DW2SMT
{
    public partial class Launcher : Form
    {
        public static Launcher instance;

        public Launcher()
        {
            InitializeComponent();

            instance = this;

            SetPage(new StartPage());
        }

        private void Launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        public void SetPage(UserControl page)
        {
            hostPanel.Controls.Clear();

            hostPanel.Controls.Add(page);
        }

        public Control CurPage { get { return hostPanel.Controls[0]; } }
    }
}
