
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace JsonParser {
    public static class Json {

        public static readonly JValue Null = JValue.Null;

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

        public static JValue ToJson(this object obj) {
            if (obj == null) {
                return Json.Null;
            }

            throw new NotImplementedException();
        }

        public static JValue FromFile(string path) => Parse(System.IO.File.ReadAllText(path));

        public static JValue Parse(string source) {
            var toks = Lexer.Lex(source);

            if (toks.Current.Type.Equals("opencurlb")) {
                return ParseObject(toks);
            } else if (toks.Current.Type.Equals("opensquareb")) {
                return ParseArray(toks);
            }

            return null;
        }

        private static JObject ParseObject(TokenList tokens) {
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
             * 3. assert that the last token is closecurlbracket
             */

            if (!tokens.AssertNext("opencurlb")) {
                Console.WriteLine("error. given token list is not a json object"); // TODO: proper error handling...
            }

            while (true) {
                if (tokens.AssertNext(out string[] values, "string", "colon")) {
                    var identifier = values[0].Substring(1, values[0].Length - 2);
                    if (TryParsePrimitive(tokens.Current, out JValue value)) {
                        jObj.Add(identifier, value);
                        tokens.MoveNext();
                    } else {
                        if (tokens.Current.Type.Equals("opencurlb")) {
                            jObj.Add(identifier, ParseObject(tokens.GetNext(tokens.GetLengthOfValue("closecurlb"))));
                        } else if (tokens.Current.Type.Equals("opensquareb")) {
                            jObj.Add(identifier, ParseArray(tokens.GetNext(tokens.GetLengthOfValue("closesquareb"))));
                        }
                    }
                }

                if (!tokens.AssertNext("comma")) {
                    break;
                }
            }

            if (!tokens.AssertNext("closecurlb")) {
                Console.WriteLine("error. given token list is not a json object"); // TODO: proper error handling...
            }

            return jObj;
        }

        private static JArray ParseArray(TokenList tokens) {
            var jary = new JArray();

            if (!tokens.AssertNext("opensquareb")) {
                Console.WriteLine("error. given token list is not a json array"); // TODO: proper error handling...
            }

            while (true) {

                if (TryParsePrimitive(tokens.Current, out JValue value)) {
                    jary.Add(value);
                    tokens.MoveNext();
                } else if (tokens.Current.Type.Equals("opencurlb")) {
                    jary.Add(ParseObject(tokens.GetNext(tokens.GetLengthOfValue("closecurlb"))));
                } else if (tokens.Current.Type.Equals("opensquareb")) {
                    jary.Add(ParseArray(tokens.GetNext(tokens.GetLengthOfValue("closesquareb"))));
                }

                if (!tokens.AssertNext("comma")) {
                    break;
                }
            }

            if (!tokens.AssertNext("closesquareb")) {
                Console.WriteLine("error. given token list is not a json array"); // TODO: proper error handling...
            }

            return jary;
        }

        private static bool TryParsePrimitive(Token t, out JValue res) {
            switch (t.Type) {
                case "bool": res = new JBool(bool.Parse(t.Value)); return true;
                case "null": res = JValue.Null; return true;
                case "number": res = new JNumber(double.Parse(t.Value)); return true;
                case "string": res = new JString(t.Value.Substring(1, t.Value.Length - 2)); return true;
                default: res = null; return false;
            }
        }




    }


    
}
