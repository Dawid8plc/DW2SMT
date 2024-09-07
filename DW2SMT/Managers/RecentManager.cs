using DW2SMT.Data;
using System.Xml.Serialization;

namespace DW2SMT.Managers
{
    internal class RecentManager
    {
        public static List<RecentFile> RecentFiles = new List<RecentFile>();

        static XmlSerializer serializer;

        public static void Initialize()
        {
            serializer = new XmlSerializer(typeof(List<RecentFile>));

            if (File.Exists(Program.RecentPath))
            {
                LoadRecents();
            }
            else
            {
                SaveRecents();
            }
        }

        public static void SaveRecents()
        {
            FileStream stream = File.Create(Program.RecentPath);
            serializer.Serialize(stream, RecentFiles);
            stream.Close();
        }

        public static void LoadRecents()
        {
            FileStream stream = null;

            try
            {
                stream = File.OpenRead(Program.RecentPath);

                RecentFiles = (List<RecentFile>)serializer.Deserialize(stream);

                List<RecentFile> toIgnore = new List<RecentFile>();

                foreach (var item in RecentFiles)
                {
                    if (File.Exists(item.Path))
                    {
                        Project proj = ProjectManager.LoadProjectPartial(item.Path);

                        if (proj != null)
                            item.project = proj;
                        else
                            toIgnore.Add(item);
                    }
                }

                foreach (var item in toIgnore)
                {
                    RecentFiles.Remove(item);
                }

                stream.Close();
            }
            catch
            {
                if(stream != null)
                    stream.Close();
            }
        }

        public static void OpenedProject(Project project, string path)
        {
            if (RecentFiles.Any(x => x.Path == path))
            {
                RecentFiles.RemoveAt(RecentFiles.FindIndex(x => x.Path == path));
                RecentFiles.Insert(0, new RecentFile() { Name = project.Name, Path = path, Date = DateTime.Now });
            }
            else
            {
                RecentFiles.Insert(0, new RecentFile() { Name = project.Name, Path = path, Date = DateTime.Now });
            }

            SaveRecents();
        }

        internal static void UpdateProject(Project curProject)
        {
            RecentFile rec = RecentFiles.Where(x => x.Path == curProject.Location).FirstOrDefault();

            if (rec != null)
            {
                rec.Name = curProject.Name;
                SaveRecents();
            }
        }
    }

    public class RecentFile
    {
        public string Name;
        public string Path;
        public DateTime Date;

        [XmlIgnore]
        public Project project;
    }
}
