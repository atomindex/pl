using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Token {

        public TokenType Type; 
        public string Text;

        public Token(TokenType type, string text) {
            Type = type;
            Text = text;
        }

        public override string ToString() {
            return Type.ToString() + " " + Text;
        }

    }
}
