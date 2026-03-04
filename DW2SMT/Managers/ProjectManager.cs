using System.Reflection;
using System.Text;
using DW2SMT.Data;
using DW2SMT.Properties;

namespace DW2SMT.Managers
{
    internal class ProjectManager
    {
        public static Project curProject;

        static List<TblItem> DefaultTbl = new List<TblItem>();

        public static void Initialize()
        {
            LoadDefaultTbl();
        }

        public static void CreateNew()
        {
            Project project = new Project() { Name = "Untitled", FileFormatVer = Program.ProjectVer, Location = string.Empty, Encoding = Encoding.Default };

            for (int i = 0; i < MapManager.curMap.GameStrings.Count; i++)
            {
                GameString? item = MapManager.curMap.GameStrings[i];

                project.UserStrings.Add(new UserString() { ID = i, Offsets = item.StreamPos, Value = string.Empty });
            }

            project.Tbl = GenDefaultTbl();

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

            foreach (var userString in curProject.UserStrings)
            {
                foreach (var tbl in curProject.Tbl)
                {
                    userString.Value = userString.Value.Replace(tbl.Custom, tbl.Original);
                }
            }

            curProject.Write(writer);

            foreach (var userString in curProject.UserStrings)
            {
                foreach (var tbl in curProject.Tbl)
                {
                    userString.Value = userString.Value.Replace(tbl.Original, tbl.Custom);
                }
            }

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

                    if(proj.FileFormatVer == 1)
                    {
                        MessageBox.Show("This project has been created with an older version of the tool. The encoding setting has been removed in favor of the Characters tab.");
                    }

                    foreach (var userString in proj.UserStrings)
                    {
                        foreach (var tbl in proj.Tbl)
                        {
                            userString.Value = userString.Value.Replace(tbl.Original, tbl.Custom);
                        }
                    }

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

        public static List<TblItem> GenDefaultTbl()
        {
            List<TblItem> items = new List<TblItem>();

            foreach (var item in DefaultTbl)
            {
                items.Add(new TblItem(item.Original, item.Custom));
            }

            return items;
        }

        static void LoadDefaultTbl()
        {
            var tblLines = ReadLines(() => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("DW2SMT.Resources.Worms2TABLE.txt"),
                  Encoding.UTF8)
            .ToList();

            DefaultTbl.Clear();

            foreach (var line in tblLines)
            {
                char originalval = line[3];
                char customval = (char)Convert.ToByte(line.Substring(0, 2), 16);

                DefaultTbl.Add(new TblItem(originalval, customval));
            }
        }

        static IEnumerable<string> ReadLines(Func<Stream> streamProvider,
                                     Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
