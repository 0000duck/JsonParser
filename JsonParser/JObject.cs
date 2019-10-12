using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JsonParser {
    public class JObject : JValue, IDictionary<string, JValue> {

        public override bool IsObject => true;

        private readonly Dictionary<string, JValue> props = new Dictionary<string, JValue>();
        public int Count => props.Count;

        public ICollection<string> Keys => props.Keys;
        public ICollection<JValue> Values => props.Values;

        public bool IsReadOnly => ((IDictionary<string, JValue>)props).IsReadOnly;
        public JValue this[string key] { get => props[key]; set => props[key] = value; }

        public override string ToJsonString() {
            var res = "{";

            for (int i = 0; i < props.Count; i++) {
                var e = props.ElementAt(i);
                res += $"\"{e.Key}\": {e.Value.ToJsonString()},";
            }
            res = res.TrimEnd(',');

            return res + "}";
        }

        public bool ContainsKey(string key) => props.ContainsKey(key);
        public bool Contains(KeyValuePair<string, JValue> item) => ((IDictionary<string, JValue>)props).Contains(item);

        public void Add(string key, JValue value) => props.Add(key, value);
        public void Add(KeyValuePair<string, JValue> item) => ((IDictionary<string, JValue>)props).Add(item);

        public bool Remove(string key) => props.Remove(key);
        public bool Remove(KeyValuePair<string, JValue> item) => ((IDictionary<string, JValue>)props).Remove(item);

        public bool TryGetValue(string key, out JValue value) => props.TryGetValue(key, out value);
        public void Clear() => props.Clear();
        public void CopyTo(KeyValuePair<string, JValue>[] array, int arrayIndex) => ((IDictionary<string, JValue>)props).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, JValue>> GetEnumerator() => props.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => props.GetEnumerator();
        
    }
}
