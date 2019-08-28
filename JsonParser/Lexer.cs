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

        public List<Token> Lex(string source) {
            var tokens = new List<Token>();
            var src = source;

            while(!string.IsNullOrEmpty(src)) {
                for(int i = 0; i <= Rules.Count; i++) {
                    if(i == Rules.Count) {
                        throw new Exception($"Unexpected Token:\nHERE=>{src}");
                    }
                    var rule = Rules[i];
                    if (rule.Match(src, out Token tok)) {
                        src = src.Remove(tok.StartIndex, tok.Length);
                        if(!rule.skip) {
                            tokens.Add(tok);
                        }
                        break;
                    }
                }
            }

            return tokens;
        }

    }

    public class LexRule : IRule {
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
                tok = new Token(Name, m.Value, m.Index);
                return true;
            }
            return false;
        }
    }

    public class Token {
        public readonly string Type;
        public readonly string Value;
        public readonly int StartIndex;
        public int Length => Value.Length;
        public Token(string t, string v, int s) {
            Type = t; Value = v; StartIndex = s;
        }
    }
}
