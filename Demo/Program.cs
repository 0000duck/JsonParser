using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonParser;

namespace Demo {
    class Program {
        static void Main(string[] args) {

            var jobj = Json.Parse("{\"test\": {\"recProp1\": 60, \"teststr\": \"hello world\"}, \"test2\": true}");

            Console.WriteLine(jobj.ToJsonString());

            Console.Read();
        }
    }
}
