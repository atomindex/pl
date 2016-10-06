using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Token {

        public TokenType Type; 
        public string Text;
        public int LineNumber;

        public Token(TokenType type, string text, int lineNumber) {
            Type = type;
            Text = text;
            LineNumber = lineNumber;
        }

        public override string ToString() {
            return Type.ToString() + " " + Text;
        }

    }
}
