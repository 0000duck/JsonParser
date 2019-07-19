using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {
    public class JArray : List<IJValue>, IJValue {

        public void Add(string str) => base.Add((JString)str);
        public void Add(double num) => base.Add((JNumber)num);
        public void Add(bool b) => base.Add((JBool)b);

        public string ToJson() {
            string res = "[";
            foreach (var item in this) {
                res += item.ToJson() + ",";
            }
            res = res.Remove(res.Length - 1);
            return res + "]";
        }
    }
}
