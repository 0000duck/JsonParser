using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonParser;

namespace Demo {
    class Program {
        static void Main(string[] args) {

            var jobj = Json.Parse("{\"test\": {\"recProp1\": 60, \"recProp2\": {\"msg\": null, \"arraytest1\": [12, true, false, null, {\"hey\": 8}]}, \"teststr\": \"hello world\"}, \"test2\": true}");

            Console.WriteLine(jobj.ToJsonString());
            
            var jary = Json.Parse("[true, false, null, \"hello to the world\", 62, 7.8]") as JArray;
            jary.Add("tset");
            Console.WriteLine(jary.ToJsonString());

            var jff = Json.FromFile("Files/test.json");
            Console.WriteLine(jff.ToJsonString());

            Console.Read();
        }
    }
}
