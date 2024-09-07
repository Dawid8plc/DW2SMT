namespace DW2SMT
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            verLabel.Text = "Version " + Program.version + " " + Program.versionQuote;
        }
    }
}
