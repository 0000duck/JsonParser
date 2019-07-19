using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {
    public interface IJValue {

        string ToJson();
    }


    
    public class JString : IJValue {

        private string value;

        public bool IsNull => value == null;

        public JString(string str) {
            value = str;
        }

        public override bool Equals(object obj) => value.Equals(obj);
        public override int GetHashCode() => value.GetHashCode();
        public override string ToString() => value.ToString();

        public string ToJson() => IsNull ? "null" : $"\"{value}\"";

        public static implicit operator JString(string str) => new JString(str);
        public static implicit operator string(JString jstr) => jstr.value;
    }

    public class JBool : IJValue {

        private bool value;

        public JBool(bool bo) {
            value = bo;
        }


        public override bool Equals(object obj) => value.Equals(obj);
        public override int GetHashCode() => value.GetHashCode();
        public override string ToString() => value.ToString();

        public string ToJson() => value.ToString().ToLower();

        public static implicit operator JBool(bool bo) => new JBool(bo);
        public static implicit operator bool(JBool jbo) => jbo.value;
    }

    public class JNumber : IJValue {

        private double value;

        public JNumber(double val) {
            value = val;
        }

        public override bool Equals(object obj) => value.Equals(obj);
        public override int GetHashCode() => value.GetHashCode();
        public override string ToString() => value.ToString();

        public string ToJson() => value.ToString(); // NOTE: there is definetly a bug with localization here

        public static implicit operator JNumber(double val) => new JNumber(val);
        public static implicit operator double(JNumber jval) => jval.value;
    }
}
