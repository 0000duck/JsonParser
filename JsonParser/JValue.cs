using System;
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

        public bool IsPrimitive => IsString || IsNumber || IsBool;
        public bool IsStruct => IsArray || IsObject;

        public abstract string ToJsonString();
        public abstract object ToObject();

    }
}
