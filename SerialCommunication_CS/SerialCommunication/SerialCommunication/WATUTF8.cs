using System.Collections.Generic;
using System.Text;

namespace SerialCommunication
{
    public class WATUTF8
    {
        List<byte> RemainBytes = new List<byte>();

        bool IsUTF8(byte _byte)
        {
            if ((_byte & 0xE0) == 0xE0) return true;
            return false;

        }

        public string AddBytes(List<byte> _bytes)
        {
            RemainBytes.AddRange(_bytes);

            if (RemainBytes.Count >= 2 && IsUTF8(RemainBytes[RemainBytes.Count - 2]))
            {
                string s = Encoding.UTF8.GetString(RemainBytes.ToArray(), 0, RemainBytes.Count - 2);
                RemainBytes.RemoveRange(0, RemainBytes.Count - 2);
                return s;
            }
            else if (RemainBytes.Count >= 1 && IsUTF8(RemainBytes[RemainBytes.Count - 1]))
            {
                string s = Encoding.UTF8.GetString(RemainBytes.ToArray(), 0, RemainBytes.Count - 1);
                RemainBytes.RemoveRange(0, RemainBytes.Count - 1);
                return s;
            }
            else
            {
                string s = Encoding.UTF8.GetString(RemainBytes.ToArray(), 0, RemainBytes.Count);
                RemainBytes.Clear();
                return s;
            }




        }

    }
}
