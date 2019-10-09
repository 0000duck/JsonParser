using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace JsonParser {
    public class Lexer {

        public readonly List<LexRule> Rules = new List<LexRule>();

        public Lexer(params LexRule[] rules) {
            Rules.AddRange(rules);
        }

        public TokenList Lex(string source) {
            var tokens = new List<Token>();
            var src = source;

            while(!string.IsNullOrEmpty(src)) {
                for(int i = 0; i <= Rules.Count; i++) {
                    if(i == Rules.Count) {
                        throw new Exception($"Unexpected Token:\nHERE=>{src}");
                    }
                    var rule = Rules[i];
                    if (rule.Match(src, out Token tok)) {
                        src = src.Remove(0, tok.Length);
                        if(!rule.skip) {
                            tokens.Add(tok);
                        }
                        break;
                    }
                }
            }

            return new TokenList(tokens);
        }

    }

    public class LexRule {
        public string Name { get; private set; }
        private readonly Regex Pattern;
        public bool skip;

        public LexRule(string n, string p) {
            Name = n;
            Pattern = new Regex($"^({p})");
            skip = false;
        }

        public LexRule Skip(bool b) {
            skip = b;
            return this;
        }

        public bool Match(string src, out Token tok) {
            var m = Pattern.Match(src);
            tok = null;
            if (m.Success) {
                tok = new Token(Name, m.Value);
                return true;
            }
            return false;
        }
    }

    public class Token {
        public readonly string Type;
        public readonly string Value;
        public int Length => Value.Length;
        public Token(string t, string v) {
            Type = t; Value = v;
        }
    }

    public class TokenList {

        private int index = 0;

        public readonly List<Token> tokens;

        public Token Current => tokens[index];

        public TokenList(List<Token> ts) {
            tokens = ts;
        }

        public bool AssertNext(string type) {
            var t = tokens[index];
            if (t.Type == type) {

            }

            throw new NotImplementedException();
        }

        public int GetLengthOfValue(string closeType) {
            var openType = Current.Type;
            var length = 0;
            var i = index;
            var track = 1;

            while (track != 0) {
                i++;
                var e = tokens[i];
                if (e.Type.Equals(closeType)) {
                    track--;
                } else if (e.Type.Equals(openType)) {
                    track++;
                }
                length++;
            }

            return length;
        }

    }
}
