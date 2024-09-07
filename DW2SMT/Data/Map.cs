
namespace DW2SMT.Data
{
    public class Map
    {
        public List<GameString> GameStrings = new List<GameString>();

        public void Write(BinaryWriter writer)
        {
            writer.Write(GameStrings.Count);
            foreach (GameString str in GameStrings)
            {
                writer.Write(str.ID);
                writer.Write(str.Value);

                writer.Write(str.Pos);

                writer.Write(str.StreamPos.Count);
                foreach (var item in str.StreamPos)
                {
                    writer.Write(item);
                }
            }
        }

        public void Read(BinaryReader reader)
        {
            int gsCount = reader.ReadInt32();
            for (int i = 0; i < gsCount; i++)
            {
                GameString str = new GameString();
                str.ID = reader.ReadInt32();
                str.Value = reader.ReadString();

                str.Pos = reader.ReadInt64();
                
                int posCount = reader.ReadInt32();
                for (int j = 0; j < posCount; j++)
                {
                    str.StreamPos.Add(reader.ReadInt64());
                }

                GameStrings.Add(str);
            }
        }
    }
}
