using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public abstract class BaseRecord
    {
        public static T ReadRecord<T>(FileParser parser) where T: BaseRecord
        {
            var instance = Activator.CreateInstance<T>();
            instance.FillFields(parser);
            return instance;
        }

        public int ProductId { get; set; }
        public int Length { get; set; }
        public int StatusA { get; set; }

        public void FillFields(FileParser parser)
        {
            ProductId = parser.ParseIntBCD(4);
            Length = parser.ParseHEX(2);
            StatusA = parser.ParseBIN(2);
            InternalFillFields(parser);
        }

        public abstract void InternalFillFields(FileParser parser);
    }
}
