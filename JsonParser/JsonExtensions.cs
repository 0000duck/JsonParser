
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace JsonParser {
    public static class JsonExtensions {
        public static string ToJson(this string str) => $"\"{str}\"";
        public static string ToJson(this bool bo) => bo.ToString().ToLower();
        public static string ToJson(this double d) => d.ToString(); // NOTE: localiztion bug here, best way to fix?

        
    }


    
}
