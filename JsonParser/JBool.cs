namespace JsonParser {
    public class JBool : JValue {

        public override bool IsBool => true;

        public bool Value;

        public JBool(bool b) => Value = b;

        public static implicit operator JBool(bool b) => new JBool(b);
        public static implicit operator bool(JBool jb) => jb.Value;

        public override string ToString() => Value.ToString();

        public override string ToJsonString() => Value.ToString();

        public override object ToObject() => Value;
    }
}
