
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
                new LexRule("curlbracket", "{|}"),
                new LexRule("squarebracket", "\\[|\\]"),
                new LexRule("comma", ","),
                new LexRule("colon", ":"),
                new LexRule("bool", "true|false"),
                new LexRule("null", "null"),
                new LexRule("number", "[0-9]+(\\.[0-9]+)?"),
                new LexRule("string", "\".*?[^\\\\]\""));
        }


        public static void Parse(string source) {
            var tokens = Lexer.Lex(source);


        }


    }


    
}
