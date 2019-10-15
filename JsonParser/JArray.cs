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

        public override object ToObject() {
            var res = new List<object>();
            foreach (var item in this) {
                res.Add(item.ToObject());
            }
            return res;
        }

        public int IndexOf(JValue item) => items.IndexOf(item);

        public void RemoveAt(int index) => items.RemoveAt(index);
        public bool Remove(JValue item) => items.Remove(item);

        public void Add(JValue item) => items.Add(item);
        public void Add(bool item) => items.Add((JBool)item);
        public void Add(double item) => items.Add((JNumber)item);
        public void Add(string item) => items.Add((JString)item);

        public void Insert(int index, JValue item) => items.Insert(index, item);
        public void Insert(int index, bool item) => items.Insert(index, (JBool)item);
        public void Insert(int index, double item) => items.Insert(index, (JNumber)item);
        public void Insert(int index, string item) => items.Insert(index, (JString)item);

        public void Clear() => items.Clear();
        public bool Contains(JValue item) => items.Contains(item);
        public void CopyTo(JValue[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);

        public IEnumerator<JValue> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
