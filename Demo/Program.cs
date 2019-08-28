using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonParser;

namespace Demo {
    class Program {
        static void Main(string[] args) {
            var t = Json.Lexer.Lex(System.IO.File.ReadAllText("Files/test.json"));
            Console.Read();
        }
    }
}
