using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public enum FieldEncodings
    {
        BCD_INT,
        BCD_DECIMAL,
        HEX,
        BIN
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class BaseFieldAttribute : Attribute
    {
        public int Order { get; set; }
        public int Len { get; set; }
        public int Decimals { get; set; }
        public FieldEncodings Encoding { get; set; }

        public BaseFieldAttribute(int order, int len, FieldEncodings encoding, int decimals = 0)
        {
            Order = order;
            Len = len;
            Encoding = encoding;
            Decimals = decimals;
        }

    }
}
