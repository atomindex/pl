using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Parser {

        private static Token tokenEOF;

        private List<Token> tokens;
        private int length;
        private int pos;

        static Parser() {
            tokenEOF = new Token(TokenType.EOF, "");
        }

        public Parser(List<Token> tokens) {
            this.tokens = tokens;
            length = tokens.Count;
        }

        public List<Expression> Parse() {
            List<Expression> expressions = new List<Expression>();

            while (peek(0).Type != TokenType.EOF) {
                expressions.Add(expression());
            }

            return expressions;
        }


        private Expression expression() {
            return additive();
        }

        private Expression additive() {
            Expression expressionLeft = multiplicative();

            while (true) {

                switch (peek(0).Type) {
                    case TokenType.Plus:
                        pos++;
                        expressionLeft = new BinaryExpression('+', expressionLeft, multiplicative());
                        continue;
                    case TokenType.Minus:
                        pos++;
                        expressionLeft = new BinaryExpression('-', expressionLeft, multiplicative());
                        continue;
                }

                break;

            }

            return expressionLeft;
        }

        private Expression multiplicative() {
            Expression expressionLeft = unary();

            while (true) {

                switch (peek(0).Type) {
                    case TokenType.Star:
                        pos++;
                        expressionLeft = new BinaryExpression('*', expressionLeft, unary());
                        continue;
                    case TokenType.Slash:
                        pos++;
                        expressionLeft = new BinaryExpression('/', expressionLeft, unary());
                        continue;
                }

                break;

            }

            return expressionLeft;
        }

        private Expression unary() {
            return primary();
        }

        private Expression primary() {
            Token currentToken = peek(0);
            if (currentToken.Type == TokenType.Number) {
                pos++;
                return new NumberExpression(Double.Parse(currentToken.Text));
            }
            //TODO Exception
            return null;
        }

        private Token peek(int relativePosition) {
            int position = pos + relativePosition;
            if (position >= length) return tokenEOF;
            return tokens[position];
        }

    }
}
