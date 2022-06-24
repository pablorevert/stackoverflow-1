// See https://aka.ms/new-console-template for more information
using Parsing;

var file = "000000010016E001000199950105C00000024995001400000002000DC0000000499507000000300015C0010000109508A000000015950030";
var parser = new FileParser();

var records = parser.Decode<Product>(file);

Console.WriteLine("Hello, World!");
