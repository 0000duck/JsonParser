namespace JsonParser {
    public class JNull : JValue {

        public override bool IsNull => true;
        internal JNull() { }

        public override string ToJsonString() => "null";

        public override object ToObject() => null;
    }
}
