
namespace DW2SMT.Data
{
    public class GameString
    {
        public int ID;

        public string Value = string.Empty;
        public long Pos = 0;
        public long Size = 0;
        public byte[] PosBytes;

        public List<long> StreamPos = new List<long>();
    }
}
