using System.Text;

namespace DW2SMT.Extensions
{
    public static class BinaryEx
    {
        public static string ReadFixedString(this BinaryReader reader, int count)
        {
            return Encoding.UTF8.GetString(reader.ReadBytes(count));
        }

        public static int WriteFixedString(this BinaryWriter writer, string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);

            writer.Write(bytes);

            return bytes.Length;
        }

        public static void Fill(this BinaryWriter writer, int value, int count)
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(value);
            }
        }

        public static void Fill(this BinaryWriter writer, byte value, int count)
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(value);
            }
        }

        public static bool ReadBooleanDWord(this BinaryReader reader)
        {
            return reader.ReadInt32() != 0;
        }

        public static void WriteBooleanDWord(this BinaryWriter writer, bool value)
        {
            writer.Write(value ? (byte)1 : (byte)0);
            writer.Write((byte)0);
            writer.Write((byte)0);
            writer.Write((byte)0);
        }

        public static string ReadNullTerminatedString(this BinaryReader reader)
        {
            StringWriter sw = new StringWriter();

            char ch;
            while ((ch = reader.ReadChar()) != '\0')
            {
                sw.Write(ch);
            }

            return sw.ToString();
        }

        public static void WriteNullTerminatedString(this BinaryWriter writer, string value)
        {
            value += '\0';

            byte[] bytes = Encoding.UTF8.GetBytes(value);

            writer.Write(bytes);
        }

        public static void Align(this BinaryReader reader, int alignment)
        {
            if (alignment <= 0 || alignment % 2 != 0)
            {
                throw new ArgumentException("Alignment must be a positive even number.");
            }

            long position = reader.BaseStream.Position;
            long remainder = position % alignment;
            if (remainder != 0)
            {
                reader.BaseStream.Seek(alignment - remainder, SeekOrigin.Current);
            }
        }

        public static void Align(this BinaryWriter writer, int alignment)
        {
            if (alignment <= 0 || alignment % 2 != 0)
            {
                throw new ArgumentException("Alignment must be a positive even number.");
            }

            long position = writer.BaseStream.Position;
            long remainder = position % alignment;
            if (remainder != 0)
            {
                for (int i = 0; i < alignment - remainder; i++)
                {
                    writer.Write((byte)0);
                }
            }
        }

        public static int ReserveOffset(this BinaryWriter writer)
        {
            int offset = (int)writer.BaseStream.Position;

            writer.BaseStream.Position += 4;

            return offset;
        }

        public static void SatisfyOffset(this BinaryWriter writer, int offset, int value)
        {
            long originalOffset = writer.BaseStream.Position;

            writer.BaseStream.Position = offset;

            writer.Write(value);

            writer.BaseStream.Position = originalOffset;
        }
    }
}
