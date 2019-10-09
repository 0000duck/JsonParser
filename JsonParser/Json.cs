
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace JsonParser {
    public static class Json {

        public static readonly Lexer Lexer;
        static Json() {
            Lexer = new Lexer(
                new LexRule("whitespace", "\\s").Skip(true),
                new LexRule("opencurlb", "{"),
                new LexRule("closecurlb", "}"),
                new LexRule("opensquareb", "\\["),
                new LexRule("closesquareb", "\\]"),
                new LexRule("comma", ","),
                new LexRule("colon", ":"),
                new LexRule("bool", "true|false"),
                new LexRule("null", "null"),
                new LexRule("number", "[0-9]+(\\.[0-9]+)?"),
                new LexRule("string", "\".*?[^\\\\]\""));
        }


        public static JObject ParseObject(string source) {
            var tokens = Lexer.Lex(source);
            var jObj = new JObject();


            /* 
             * 1. assert that first token is opencurlbracket.
             * 2. next is a list of key-value pairs
             *      first: string (the key)
             *      second: colon (the key-value sepperation char)
             *      third: an uknown number of tokens to describe the value
             *          for single token values (string, null, bool, number) do TryParsePrimitive()
             *          else create new TokenList and parse recursively
             *      forth: there may be a comma here, if so repeat step 2
             */


            return jObj;
        }

        private static bool TryParsePrimitive(Token t, out JValue res) {
            switch (t.Type) {
                case "bool": res = new JBool(bool.Parse(t.Value)); return true;
                case "null": res = JValue.Null; return true;
                case "number": res = new JNumber(double.Parse(t.Value)); return true;
                case "string": res = new JString(t.Value); return true; // possible bug with qoutes here, TODO: remove first and last double quotes.
                default:
                    res = null;
                    return false;
            }
        }




    }


    
}
