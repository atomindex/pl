using pl.Expressions;
using pl.Statements;
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

        public List<Statement> Parse() {
            List<Statement> expressions = new List<Statement>();

            while (peek(0).Type != TokenType.EOF) {
                expressions.Add(statement());
            }

            return expressions;
        }

        private Statement statement() {
            return assigmentStatement();
        }

        private Statement assigmentStatement() {
            Token currentToken = peek(0);

            if (currentToken.Type == TokenType.Word && peek(1).Type == TokenType.Eq) {
                string variableName = currentToken.Text;
                pos += 2;
                Expression variableExpression = expression();
                return new AssigmentStatement(variableName, variableExpression);
            }

            return null;
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
            Expression expression;

            switch (peek(0).Type) {
                case TokenType.Minus:
                    pos++;
                    expression = new UnaryExpression('-', unary());
                    break;
                case TokenType.Plus:
                    pos++;
                    expression = new UnaryExpression('+', unary());
                    break;
                default:
                    expression = primary();
                    break;
            }

            return expression;
        }

        private Expression primary() {
            Token currentToken = peek(0);

            switch (currentToken.Type) {
                case TokenType.Number:
                    pos++;
                    return new NumberExpression(Double.Parse(currentToken.Text));
                case TokenType.LParen:
                    pos++;
                    Expression subExpression = expression();
                    
                    //TODO exception
                    //if (peek(0).Type != TokenType.RParen)
                    pos++;

                    return subExpression;
                case TokenType.Word:
                    pos++;
                    return new VariableExpression(currentToken.Text);
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
