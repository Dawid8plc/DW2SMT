using DW2SMT.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DW2SMT.Managers
{
    internal class MapManager
    {
        public static Map curMap;

        static Regex stringRegex = new Regex(".data:([^\t]*)\t([^\t]*)\tC\t(.*)");

        public static void LoadMap()
        {
            curMap = new Map();

            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("DW2SMT.Resources.Map.w2map"))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                curMap.Read(reader);
            }
        }
    }
}
