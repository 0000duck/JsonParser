using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {
    public abstract class JValue {

        public static readonly JValue Null = new JNull();

        public virtual bool IsString => false;
        public virtual bool IsNumber => false;
        public virtual bool IsBool => false;
        public virtual bool IsNull => false;
        public virtual bool IsObject => false;
        public virtual bool IsArray => false;

        public bool IsPrimitive => IsString || IsNumber || IsBool || IsNull;
        public bool IsStruct => IsArray || IsObject;

        public abstract string ToJsonString();

    }

    public class JString : JValue {

        public override bool IsString => true;

        public string Value;

        public JString(string str) => Value = str; 

        public static implicit operator JString(string s) => new JString(s);
        public static implicit operator string(JString js) => js.Value;

        public override string ToString() => Value;

        public override string ToJsonString() => $"\"{Value}\"";
    }

    public class JNumber : JValue {

        public override bool IsNumber => true;

        public double Value;

        public JNumber(double d) => Value = d;

        public static implicit operator JNumber(double d) => new JNumber(d);
        public static implicit operator double(JNumber jn) => jn.Value;

        public override string ToString() => Value.ToString();

        public override string ToJsonString() => ToString(); // TODO: fix localization bug here
    }

    public class JBool : JValue {

        public override bool IsBool => true;

        public bool Value;

        public JBool(bool b) => Value = b;

        public static implicit operator JBool(bool b) => new JBool(b);
        public static implicit operator bool(JBool jb) => jb.Value;

        public override string ToString() => Value.ToString();

        public override string ToJsonString() => Value.ToString();
    }

    public class JNull : JValue {

        public override bool IsNull => true;
        internal JNull() { }

        public override string ToJsonString() => "null";
    }

    public class JObject : JValue {

        public override bool IsObject => true;

        private readonly Dictionary<string, JValue> props = new Dictionary<string, JValue>();

        public override string ToJsonString() {
            var res = "{";

            for (int i = 0; i < props.Count; i++) {
                var e = props.ElementAt(i);
                res += $"\"{e.Key}\": {e.Value.ToJsonString()},";
            }
            res = res.TrimEnd(',');

            return res + "}";
        }

    }

    public class JArray : JValue {
        public override bool IsArray => true;

        private readonly List<JValue> items = new List<JValue>();


        public override string ToJsonString() {
            var res = "[";

            for (int i = 0; i < items.Count; i++) {
                res += items[i].ToJsonString() + ",";
            }
            res = res.TrimEnd(',');

            return res + "]";
        }
    }
}
