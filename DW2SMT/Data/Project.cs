using DW2SMT.Extensions;
using System.Text;

namespace DW2SMT.Data
{
    public class Project
    {
        public const int SupportedFileFormatVer = 1;

        public const string Signature = "DW2Lang";

        public int FileFormatVer;
        int CodePage = 0;

        public string Name;
        public List<UserString> UserStrings = new List<UserString>();

        //Editor only
        public string Location = string.Empty;

        Encoding _encoding;
        public Encoding Encoding
        {
            get
            {
                if (_encoding != null && _encoding.CodePage == CodePage)
                {
                    return _encoding;
                }
                else
                {
                    _encoding = Encoding.GetEncoding(CodePage);
                    return _encoding;
                }
            }
            set
            {
                _encoding = value;
                CodePage = _encoding.CodePage;
            }
        }

        public void Write(BinaryWriter writer)
        {
            writer.WriteFixedString(Signature);
            writer.Write(Program.ProjectVer);
            writer.Write(CodePage);

            if (string.IsNullOrWhiteSpace(Name))
            {
                byte[] nameBytes = Encoding.GetBytes("Untitled");

                writer.Write(nameBytes.Length);
                writer.Write(nameBytes);
            }
            else
            {
                byte[] nameBytes = Encoding.GetBytes(Name);

                writer.Write(nameBytes.Length);
                writer.Write(nameBytes);
            }

            writer.Write(UserStrings.Count);
            foreach (UserString str in UserStrings)
            {
                str.Write(writer, Encoding);
            }
        }

        public void Read(BinaryReader reader, bool partial)
        {
            if (!(reader.ReadFixedString(Signature.Length) == Signature))
            {
                throw new Exception("Invalid DW2Lang file signature");
            }

            FileFormatVer = reader.ReadInt32();
            if (FileFormatVer > SupportedFileFormatVer)
            {
                throw new Exception("DW2Lang file format version newer than supported");
            }

            CodePage = reader.ReadInt32();

            int nameLength = reader.ReadInt32();
            Name = Encoding.GetString(reader.ReadBytes(nameLength));

            if (partial)
                return;

            int GSCount = reader.ReadInt32();

            for (int i = 0; i < GSCount; i++)
            {
                UserString us = new UserString();
                us.Read(reader, Encoding, FileFormatVer);
                UserStrings.Add(us);
            }
        }
    }
}
