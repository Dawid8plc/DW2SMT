using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2SMT.Data
{
    public class TblItem
    {
        public char Original = char.MinValue;
        public char Custom = char.MinValue;

        public TblItem() { }

        public TblItem(char original, char custom)
        {
            Original = original;
            Custom = custom;
        }

        internal void Write(BinaryWriter writer, Encoding encoding)
        {
            writer.Write(Original);
            writer.Write(Custom);
        }

        internal void Read(BinaryReader reader, Encoding encoding, int fileFormatVer)
        {
            Original = reader.ReadChar();
            Custom = reader.ReadChar();
        }
    }
}
