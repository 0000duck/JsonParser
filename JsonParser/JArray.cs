using System.Collections;
using System.Collections.Generic;

namespace JsonParser {
    public class JArray : JValue, IList<JValue> {
        public override bool IsArray => true;

        private readonly List<JValue> items = new List<JValue>();
        public int Count => items.Count;

        public bool IsReadOnly => ((IList<JValue>)items).IsReadOnly;

        public JValue this[int index] { get => items[index]; set => items[index] = value; }

        public override string ToJsonString() {
            var res = "[";

            for (int i = 0; i < items.Count; i++) {
                res += items[i].ToJsonString() + ",";
            }
            res = res.TrimEnd(',');

            return res + "]";
        }

        public int IndexOf(JValue item) => items.IndexOf(item);

        public void RemoveAt(int index) => items.RemoveAt(index);
        public bool Remove(JValue item) => items.Remove(item);

        public void Add(JValue item) => items.Add(item);
        public void Insert(int index, JValue item) => items.Insert(index, item);

        public void Clear() => items.Clear();
        public bool Contains(JValue item) => items.Contains(item);
        public void CopyTo(JValue[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public IEnumerator<JValue> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
