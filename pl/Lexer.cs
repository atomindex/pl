﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Lexer {

        private static string operators;
        private static TokenType[] operatorsTokenTypes;

        private string input;
        private List<Token> tokens;
        private int length;
        private int pos;

        static Lexer() {
            operators = "+-*/";
            operatorsTokenTypes = new TokenType[] {
                TokenType.Plus,
                TokenType.Minus,
                TokenType.Star,
                TokenType.Slash
            };
        }

        public Lexer(string input) {
            this.input = input;
            this.length = input.Length;
            this.tokens = new List<Token>();
        }

        public List<Token> Tokenize() {

            while (pos < length) {

                char currentChar = peek(0);

                if (char.IsDigit(currentChar))
                    tokenizeNumber();
                else if (operators.IndexOf(currentChar) != -1)
                    tokenizeOperator();
                else 
                    next();

            }

            return tokens;
        }

        private void tokenizeNumber() {
            StringBuilder sb = new StringBuilder();

            char currentChar = peek(0);
            while (char.IsDigit(currentChar)) {
                sb.Append(currentChar);
                currentChar = next();
            }

            addToken(TokenType.Number, sb.ToString());
        }

        private void tokenizeOperator() {
            addToken( operatorsTokenTypes[ operators.IndexOf(peek(0)) ] );
            next();
        }

        private char next() {
            pos++;
            return peek(0);
        }

        private char peek(int relativePosition) {
            int position = pos + relativePosition;
            return position >= length ? '\0' : input[position];
        }

        private void addToken(TokenType type) {
            tokens.Add(new Token(type, ""));
        }

        private void addToken(TokenType type, string text) {
            tokens.Add(new Token(type, text));
        }

    }
}
