using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser {

    public enum RuleModifier {
        None,
        Optional,
        OneOrMore,
        ZeroOrMore
    }


    public class RulePattern {
        public readonly IRule Rule;
        public readonly RuleModifier Modifier;

        public RulePattern(IRule r, RuleModifier m) {
            Rule = r; Modifier = m;
        }

        public bool Match(List<Token> tokens) {
            if (Rule is LexRule l) {
                if (Modifier == RuleModifier.None) {
                    foreach (var item in tokens) {
                        if (l.Name.Equals(item.Type)) {

                        }
                    }
                }
            } else if (Rule is ParseRule p) {
                return p.Match(tokens);
            }
        }

        public static implicit operator RulePattern(LexRule r) => new RulePattern(r, RuleModifier.None);
        public static implicit operator RulePattern(ParseRule r) => new RulePattern(r, RuleModifier.None);
    }
}
