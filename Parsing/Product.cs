using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Product : BaseRecord
    {
        public decimal? Price { get; set; }
        public int? Label1 { get; set; }
        public int? Label2 { get; set; }
        public int? StatusB { get; set; }
        public decimal? SecondPrice { get; set; }
        public int? SellByDate { get; set; }
        public TimeSpan? SellByTime { get; set; }
        public override void InternalFillFields(FileParser parser)
        {
            Price = parser.ConditionalParseDecimalBCD(StatusA, 0x8000, 4, 2);
            Label1 = parser.ConditionalParseHEX(StatusA, 0x4000, 1);
            Label2 = parser.ConditionalParseHEX(StatusA, 0x2000, 1);
            StatusB = parser.ConditionalParseBIN(StatusA, 0x0001, 2);
            SecondPrice = parser.ConditionalParseDecimalBCD(StatusB, 0x8000, 4, 2);
            SellByDate = parser.ConditionalParseIntBCD(StatusB, 0x4000, 2);
            SellByTime = parser.ConditionalParseTimeSpan(StatusB, 0x2000);
        }
    }
}
