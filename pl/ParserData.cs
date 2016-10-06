using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class ParserData {

        private static Token tokenEOF;

        public int Pos;
        private List<Token> tokens;
        private int length;



        static ParserData() {
            tokenEOF = new Token(TokenType.EOF, "");
        }



        public ParserData(List<Token> tokens) {
            this.tokens = tokens;
            this.length = tokens.Count;
        }

        public Token Peek(int relativePosition) {
            int position = Pos + relativePosition;
            if (position >= length) return tokenEOF;
            return tokens[position];
        }

    }
}
