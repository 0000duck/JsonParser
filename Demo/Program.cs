using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonParser;

namespace Demo {
    class Program {
        static void Main(string[] args) {


            var o = new JObject() {
                { "str1", "test" },
                { "obj1", new JObject() {
                    { "num1", 12.5f },
                    { "obj2", new JObject() {
                        { "val1", null },
                        { "val2", true },
                        { "val3", false }
                        }}
                    }
                },
                { "arry1", new JArray() {
                    15, true, null,
                    new JArray() {
                        3, 6, 9
                    },
                    new JObject() {
                        { "type", "string" },
                        { "value", "Hello World" }
                    }
                }}
            };

            var str = "xx{x{}xx{xx{}}}xx{{{}x";
            Json.CharPair(str, '{', '}', out int f, out int l);
            Console.WriteLine(str + "  |  " + f + " " + l);
            Console.Read();
        }
    }
}
