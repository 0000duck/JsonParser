namespace JsonParser {
    public class JNumber : JValue {

        public override bool IsNumber => true;

        public double Value;

        public JNumber(double d) => Value = d;

        public static implicit operator JNumber(double d) => new JNumber(d);
        public static implicit operator double(JNumber jn) => jn.Value;

        public static implicit operator JNumber(float f) => new JNumber(f);
        public static implicit operator float (JNumber jn) => (float)jn.Value;

        public override string ToString() => Value.ToString();

        public override string ToJsonString() => ToString(); // TODO: fix localization bug here

        public override object ToObject() => Value;
    }
}
