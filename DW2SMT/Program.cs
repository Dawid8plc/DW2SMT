using DW2SMT.Managers;
using System.Text;

namespace DW2SMT
{
    internal static class Program
    {
        public static string BasePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string RecentPath = Path.Combine(BasePath, "Recent.xml");

        public static int ProjectVer = 1;

        public static string version = "1.0.0";
        public static string versionQuote = "\"New Horizons\"";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            MapManager.LoadMap();

            RecentManager.Initialize();

            try
            {
                RegistryManager.Initialize();
            }
            catch
            {

            }

            if (args.Length > 0 && System.IO.File.Exists(args[0]))
            {
                //Load the provided project
                if(ProjectManager.LoadProject(args[0]))
                {
                    Editor editor = new Editor();
                    editor.Show();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Launcher main = new Launcher();
                main.Show();

                //MapCreator creator = new MapCreator();
                //creator.Show();
            }

            Application.Run();
        }

        public static void OpenAbout()
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}