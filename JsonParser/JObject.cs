using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {
    public class JObject : Dictionary<string, IJValue>, IJValue {

        public JObject() {

        }

        public void Add(string key, string str) => base.Add(key, (JString)str);
        public void Add(string key, double num) => base.Add(key, (JNumber)num);
        public void Add(string key, bool b) => base.Add(key, (JBool)b);

        
        public string ToJson() {
            string res = "{";
            foreach (var item in this) {
                res += $"\"{item.Key}\": {item.Value.ToJson()},"; 
            }
            res = res.Remove(res.Length - 1);
            return res + "}";
        }
    }
}
