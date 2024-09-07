using System.Text;

namespace DW2SMT.Data
{
    public class UserString
    {
        public int ID;
        public List<long> Offsets = new List<long>();
        public string Value = string.Empty;

        internal void Write(BinaryWriter writer, Encoding encoding)
        {
            writer.Write(ID);

            writer.Write(Offsets.Count);
            foreach (var offset in Offsets)
            {
                writer.Write(offset);
            }

            byte[] bytes = encoding.GetBytes(Value);

            writer.Write(bytes.Length);
            writer.Write(bytes);
        }

        internal void Read(BinaryReader reader, Encoding encoding, int fileFormatVer)
        {
            ID = reader.ReadInt32();

            int offsetCount = reader.ReadInt32();
            for (int i = 0; i < offsetCount; i++)
            {
                Offsets.Add(reader.ReadInt64());
            }

            int valLength = reader.ReadInt32();
            Value = encoding.GetString(reader.ReadBytes(valLength));
        }
    }
}
