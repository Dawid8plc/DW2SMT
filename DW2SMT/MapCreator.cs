using System.Text.RegularExpressions;
using DW2SMT.Data;

namespace DW2SMT
{
    public partial class MapCreator : Form
    {
        static long DataPos = 0x0006E400;
        static long DataEnd = 0x00081BF0;

        Regex stringRegex = new Regex(".data:([^\t]*)\t([^\t]*)\tC\t(.*)");

        List<GameString> gameStrings = new List<GameString>();

        ulong imageBase = 0x401000;

        public MapCreator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "game exe path";

            FileStream stream = File.OpenRead(fileName);

            BinaryReader reader = new BinaryReader(stream);

            stream.Position = DataPos;

            foreach (var item in gameStrings)
            {
                List<long> indexes = IndexesOf(stream, item.PosBytes);

                for (int i = 0; i < indexes.Count; i++)
                {
                    indexes[i] = indexes[i] + 4201472;
                }

                item.StreamPos = indexes;

                stream.Position = DataPos;
            }

            RefreshView();
        }

        void RefreshView()
        {
            listBox1.Items.Clear();

            foreach (var item in gameStrings)
            {
                listBox1.Items.Add(item.Value);
            }
        }


        /// <summary>
        /// Finds the first occurrence of <paramref name="pattern"/> in a stream
        /// </summary>
        /// <param name="s">The input stream</param>
        /// <param name="pattern">The pattern</param>
        /// <returns>The index of the first occurrence, or -1 if the pattern has not been found</returns>
        public static List<long> IndexesOf(Stream s, byte[] pattern)
        {
            List<long> offsets = new List<long>();

            // Prepare the bad character array is done once in a separate step
            var badCharacters = MakeBadCharArray(pattern);

            // We now repeatedly read the stream into a buffer and apply the Boyer-Moore-Horspool algorithm on the buffer until we get a match
            var buffer = new byte[Math.Max(2 * pattern.Length, 4096)];
            long offset = 0; // keep track of the offset in the input stream
            while (true)
            {
                int dataLength;
                if (offset == 0)
                {
                    // the first time we fill the whole buffer
                    dataLength = s.Read(buffer, 0, buffer.Length);
                }
                else
                {
                    // Later, copy the last pattern.Length bytes from the previous buffer to the start and fill up from the stream
                    // This is important so we can also find matches which are partly in the old buffer
                    Array.Copy(buffer, buffer.Length - pattern.Length, buffer, 0, pattern.Length);
                    dataLength = s.Read(buffer, pattern.Length, buffer.Length - pattern.Length) + pattern.Length;
                }

                var index = IndexOf(buffer, dataLength, pattern, badCharacters, offset);
                if (index.Count > 0)
                {
                    offsets.AddRange(index);
                }
                //if (index >= 0)
                //{
                //    //return offset + index; // found!
                //    offsets.Add(DataPos + offset + index);
                //}
                if (dataLength < buffer.Length)
                    break;
                offset += dataLength - pattern.Length;
            }

            return offsets;
        }

        // --- Boyer-Moore-Horspool algorithm ---
        // (Slightly modified code from
        // https://stackoverflow.com/questions/16252518/boyer-moore-horspool-algorithm-for-all-matches-find-byte-array-inside-byte-arra)
        // Prepare the bad character array is done once in a separate step:
        private static int[] MakeBadCharArray(byte[] pattern)
        {
            var badCharacters = new int[256];

            for (long i = 0; i < 256; ++i)
                badCharacters[i] = pattern.Length;

            for (var i = 0; i < pattern.Length - 1; ++i)
                badCharacters[pattern[i]] = pattern.Length - 1 - i;

            return badCharacters;
        }

        // Core of the BMH algorithm
        private static List<long> IndexOf(byte[] value, int valueLength, byte[] pattern, int[] badCharacters, long offset)
        {
            List<long> indexes = new List<long>();

            int index = 0;

            while (index <= valueLength - pattern.Length)
            {
                for (var i = pattern.Length - 1; value[index + i] == pattern[i]; --i)
                {
                    if (i == 0)
                    {
                        indexes.Add(DataPos + offset + index);
                        break;
                    }
                }

                index += badCharacters[value[index + pattern.Length - 1]];
            }

            return indexes;
        }

        void LoadStrings()
        {
            gameStrings.Clear();

            string[] strings = File.ReadAllLines("Strings.txt");

            foreach (var item in strings)
            {
                Match m = stringRegex.Match(item);

                string pos = m.Groups[1].Value;
                string size = m.Groups[2].Value;
                string value = m.Groups[3].Value;

                byte[] posBytes = StringToByteArray(pos);
                Array.Reverse(posBytes);
                //ulong pos2 = (ulong)BitConverter.ToInt32(posBytes) - 4201472;
                long pos2 = (long)BitConverter.ToInt32(posBytes);
                gameStrings.Add(new GameString() { Value = value, Pos = pos2, Size = long.Parse(size, System.Globalization.NumberStyles.HexNumber), PosBytes = posBytes });
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadStrings();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;

            listBox2.Items.Clear();

            GameString gs = gameStrings[listBox1.SelectedIndex];

            foreach (var item in gs.StreamPos)
            {
                listBox2.Items.Add(item);
            }

            label1.Text = "File offset of string: " + gs.Pos;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            Map newMap = new Map();

            newMap.GameStrings = gameStrings;

            FileStream stream = File.Create(Path.Combine(Program.BasePath, "Map.w2map"));
            BinaryWriter writer = new BinaryWriter(stream);
            newMap.Write(writer);

            stream.Close();
        }
    }
}
