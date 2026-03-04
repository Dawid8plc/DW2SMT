using DW2SMT.Extensions;
using DW2SMT.Managers;
using System.Text;

namespace DW2SMT.Data
{
    public class Project
    {
        public const int SupportedFileFormatVer = 2;

        public const string Signature = "DW2Lang";

        public int FileFormatVer;
        int CodePage = 0;

        public string Name;
        public List<UserString> UserStrings = new List<UserString>();
        public List<TblItem> Tbl = new List<TblItem>();

        //Editor only
        public string Location = string.Empty;

        Encoding _encoding = Encoding.Default;
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
            //writer.Write(CodePage);

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

            long curPos = writer.BaseStream.Position;
            writer.BaseStream.Position += 4;

            writer.Write(Tbl.Count);
            foreach (TblItem tbl in Tbl)
            {
                tbl.Write(writer, Encoding);
            }

            int userStringsPos = (int)writer.BaseStream.Position;

            writer.Write(UserStrings.Count);
            foreach (UserString str in UserStrings)
            {
                str.Write(writer, Encoding);
            }

            writer.BaseStream.Position = curPos;
            writer.Write(userStringsPos);
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

            if (FileFormatVer == 1)
                CodePage = reader.ReadInt32();
            else
                CodePage = Encoding.Default.CodePage;

            int nameLength = reader.ReadInt32();
            Name = Encoding.GetString(reader.ReadBytes(nameLength));

            if (partial)
                return;

            if (FileFormatVer >= 2)
            {
                int userStringsPos = reader.ReadInt32();

                int TBLCount = reader.ReadInt32();
                for (int i = 0; i < TBLCount; i++)
                {
                    TblItem tbl = new TblItem();
                    tbl.Read(reader, Encoding, FileFormatVer);
                    Tbl.Add(tbl);
                }
            }
            else
            {
                Tbl = ProjectManager.GenDefaultTbl();
            }

            int GSCount = reader.ReadInt32();

            for (int i = 0; i < GSCount; i++)
            {
                UserString us = new UserString();
                us.Read(reader, Encoding, FileFormatVer);
                UserStrings.Add(us);
            }

            if (FileFormatVer == 1)
                Encoding = Encoding.Default;
        }
    }
}
