using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class FileParser
    {
        public string Content { get; set; }
        public int Position { get; set; }

        public bool EOF { get { return Position >= Content.Length; } }

        public IList<T> Decode<T>(string file) where T : BaseRecord
        {
            Content = file;
            Position = 0;
            var l = new List<T>();
            while (!EOF)
                l.Add(BaseRecord.ReadRecord<T>(this));
            return l;
        }

        public  decimal ParseDecimalBCD(int len, int decimals)
        {
            return Decimal.Parse(Read( len)) / ((Decimal)Math.Pow(10,decimals));
        }

        public decimal? ConditionalParseDecimalBCD(int? status, int flag, int len, int decimals)
        {
            return status.HasValue && (status.Value & flag) != 0 ? ParseDecimalBCD(len, decimals) : null;
        }


        public int ParseIntBCD(int len)
        {
            return int.Parse(Read(len));
        }

        public int? ConditionalParseIntBCD(int? status, int flag, int len)
        {
            return status.HasValue && (status.Value & flag) != 0 ? ParseIntBCD(len) : null;
        }

        public TimeSpan ParseTimeSpan()
        {
            var hours = ParseIntBCD(1);
            var minutes = ParseIntBCD(1);
            return new TimeSpan(hours, minutes, 0);
        }

        public TimeSpan? ConditionalParseTimeSpan(int? status, int flag)
        {
            return status.HasValue && (status.Value & flag) != 0 ? ParseTimeSpan() : null;
        }


        public int ParseHEX (int len)
        {
            return int.Parse(Read(len), System.Globalization.NumberStyles.HexNumber);
        }

        public int? ConditionalParseHEX(int? status, int flag, int len)
        {
            return status.HasValue && (status.Value & flag) != 0 ? ParseHEX(len) : null;
        }


        public int ParseBIN (int len)
        {
            return int.Parse(Read(len), System.Globalization.NumberStyles.HexNumber);
        }

        public int? ConditionalParseBIN(int? status, int flag, int len)
        {
            return status.HasValue && (status.Value & flag) != 0 ? ParseBIN(len) : null;
        }


        public string Read(int len)
        {
            var ret = Content.Substring(Position, len * 2);
            Position += len * 2;
            return ret;
        }
    }
}
