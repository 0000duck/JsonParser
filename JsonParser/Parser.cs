using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {
    public class Parser {

        public readonly List<ParseRule> Rules = new List<ParseRule>();
        public readonly Lexer Lexer;

        public Parser(params ParseRule[] r) {
            Rules.AddRange(r);
        }


        public Node Parse(string source) {
            Node root = null;

            return root;
        }

    }

    public class ParserTask {
        public readonly List<Token> tokens;
        public int index = 0;
        public Node Root;

        public int TokensLeft => tokens.Count - index;
        public Token CurrentToken => tokens[index];

    }

    public class ParseRule : IRule {
        public string Name { get; private set; }
        private readonly List<List<RulePattern>> Patterns;
        public ParseRule(string n, List<List<RulePattern>> pat) {
            Name = n; Patterns = pat;
        }

        public bool Match(List<Token> tokens) {
            foreach (var p in Patterns) {
                foreach (var tok in tokens) {
                    if (tok.Type.Equals() {

                    }
                }
            }
        }

    }

    public class Node {
        public readonly string Type;
        public readonly Node ParentNode = null;
        public readonly List<Node> ChildrenNodes = new List<Node>();

        public Node(string t) {
            Type = t;
        }
    }

}
