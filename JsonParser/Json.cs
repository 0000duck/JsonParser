
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace JsonParser {
    public static class Json {
        //public static string ToJson(this string str) => $"\"{str}\"";
        //public static string ToJson(this bool bo) => bo.ToString().ToLower();
        //public static string ToJson(this double d) => d.ToString(); // NOTE: localiztion bug here, best way to fix?

        /*public static string ToJson(this object obj) {

            if (obj == null) {
                return "null";
            }

            // Primitives:
            if (obj is string s) {
                return $"\"{s}\"";
            } else if (obj is bool b) {
                return b.ToString().ToLower();
            } else if (obj is double d) {
                return d.ToString();
            }

            // object:

            var type = obj.GetType();

            type.FindMembers(MemberTypes.Field | MemberTypes.Property, BindingFlags.Public, null, null); //?
        }*/

        // NOTE: this method doesnt belong
        public static void CharPair(string src, char open, char close, out int firstindex, out int lastindex) {


            firstindex = src.IndexOf(open);

            int current = firstindex;
            int o, e = -1;
            int i = 1;
            while (i != 0) {
                o = src.IndexOf(open, current + 1);
                o = o == -1 ? int.MaxValue : o;
                e = src.IndexOf(close, current + 1);
                if(o < e) {
                    i++;
                    current = o;
                } else {
                    i--;
                    current = e;
                }
            }

            lastindex = e;
        }

        /*public static IJValue Parse(string json) {

        }*/

    }


    
}
