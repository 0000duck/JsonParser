namespace JsonParser {
    public class JString : JValue {

        public override bool IsString => true;

        public string Value;

        public JString(string str) => Value = str; 

        public static implicit operator JString(string s) => new JString(s);
        public static implicit operator string(JString js) => js.Value;

        public override string ToString() => Value;

        public override string ToJsonString() => $"\"{Value}\"";

        public override object ToObject() => Value;
    }
}
