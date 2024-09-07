using System.Text;
using DW2SMT.Data;

namespace DW2SMT.Managers
{
    internal class ProjectManager
    {
        public static Project curProject;

        public static void CreateNew()
        {
            Project project = new Project() { Name = "Untitled", FileFormatVer = Program.ProjectVer, Location = string.Empty, Encoding = Encoding.Default };

            for (int i = 0; i < MapManager.curMap.GameStrings.Count; i++)
            {
                GameString? item = MapManager.curMap.GameStrings[i];

                project.UserStrings.Add(new UserString() { ID = i, Offsets = item.StreamPos, Value = string.Empty });
            }

            curProject = project;
        }

        internal static void CreateProject(string path, string name)
        {
            Project project = new Project() { Name = name, FileFormatVer = Program.ProjectVer, Encoding = Encoding.Default };

            for (int i = 0; i < MapManager.curMap.GameStrings.Count; i++)
            {
                GameString? item = MapManager.curMap.GameStrings[i];

                project.UserStrings.Add(new UserString() { ID = i, Offsets = item.StreamPos, Value = string.Empty });
            }

            FileStream fstream = File.Create(path);

            BinaryWriter writer = new BinaryWriter(fstream);

            project.Write(writer);

            fstream.Close();
        }

        public static void SaveProject()
        {
            FileStream fstream = File.Create(curProject.Location);

            BinaryWriter writer = new BinaryWriter(fstream);

            curProject.Write(writer);

            fstream.Close();
        }

        public static bool LoadProject(string text)
        {
            Project proj = new Project();

            bool projectExists = File.Exists(text);

            if (projectExists)
            {
                FileStream fstream = null;
                try
                {
                    fstream = File.OpenRead(text);

                    BinaryReader reader = new BinaryReader(fstream);

                    proj.Read(reader, false);
                    fstream.Close();

                    proj.Location = text;

                    RecentManager.OpenedProject(proj, text);
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Failed to load project: {e.Message}");

                    if (fstream != null)
                        fstream.Close();

                    proj = null;

                    return false;
                }

                curProject = proj;
                return true;
            }
            else
            {
                MessageBox.Show("DW2SMT was unable to find the language file, was it removed or moved?", "Language file not found");
                proj = null;
                return false;
            }
        }

        internal static Project LoadProjectPartial(string text)
        {
            var project = new Project();

            FileStream fstream = null;

            try
            {
                fstream = File.OpenRead(text);

                BinaryReader reader = new BinaryReader(fstream);

                project.Read(reader, true);

                fstream.Close();

                project.Location = text;
            }catch(Exception e)
            {
                if (fstream != null)
                    fstream.Close();

                return null;
            }

            return project;
        }
    }
}
