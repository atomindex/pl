using pl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Lexer {

        private static string spaces;
        private static string operators;
        private static TokenType[] operatorsTokenTypes;

        private string input;
        private List<Token> tokens;
        private int length;
        private int pos;
        private int currentLine;



        static Lexer() {
            spaces = " \t\n";
            operators = "+-*/()=";
            operatorsTokenTypes = new TokenType[] {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Star,
                TokenType.Slash,
                TokenType.LParen,
                TokenType.RParen,
                TokenType.Eq
            };
        }



        public Lexer(string input) {
            this.input = input;
            this.length = input.Length;
            this.tokens = new List<Token>();
            currentLine = 1;
        }

        public List<Token> Tokenize() {

            while (pos < length) {

                char currentChar = peek(0);

                if (char.IsDigit(currentChar))
                    tokenizeNumber();
                else if (char.IsLetter(currentChar) || currentChar == '_')
                    tokenizeWord();
                else if (operators.IndexOf(currentChar) != -1)
                    tokenizeOperator();
                else if (spaces.IndexOf(currentChar) != -1) {
                    if (currentChar == '\n')
                        currentLine++;
                    pos++;
                } else
                    throw new ParsingException("Неожиданный символ " + currentChar + " в строке " + currentLine.ToString());

            }

            return tokens;
        }

        private void tokenizeNumber() {
            StringBuilder sb = new StringBuilder();

            bool hasDot = false;
            while (true) {
                char currentChar = peek(0);

                if (currentChar == '.') {
                    if (hasDot)
                        throw new ParsingException("Неожиданный символ точки в строке " + currentLine.ToString());
                    else {
                        if (sb.Length == 0)
                            sb.Append('0');
                        sb.Append(currentChar);
                        hasDot = true;
                    }
                } else if (char.IsDigit(currentChar)) {
                    sb.Append(currentChar);
                } else 
                    break;

                pos++;
            }

            addToken(TokenType.Number, sb.ToString());
        }

        private void tokenizeWord() {
            StringBuilder sb = new StringBuilder();

            char currentChar = peek(0);
            while (char.IsLetterOrDigit(currentChar) || currentChar == '_') {
                sb.Append(currentChar);
                pos++;
                currentChar = peek(0);
            }

            string word = sb.ToString();

            switch (word) {
                case "print":
                    addToken(TokenType.Print, word);
                    break;
                default:
                    addToken(TokenType.Word, word);
                    break;
            }
        }

        private void tokenizeOperator() {
            char currentChar = peek(0);
            addToken( 
                operatorsTokenTypes[ operators.IndexOf(currentChar) ], 
                currentChar.ToString() 
            );
            pos++;
        }


        private char peek(int relativePosition) {
            int position = pos + relativePosition;
            return position >= length ? '\0' : input[position];
        }

        private void addToken(TokenType type, string text) {
            tokens.Add(new Token(type, text, currentLine));
        }

    }
}
