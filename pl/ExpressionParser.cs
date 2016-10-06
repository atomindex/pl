using pl.Exceptions;
using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class ExpressionParser {

        private ParserData parserData;

        public ExpressionParser(ParserData parserData) {
            this.parserData = parserData;
        }

        public Expression Parse() {
            return additive();
        }

        private Expression additive() {
            Expression expressionLeft = multiplicative();

            while (true) {
                switch (peek(0).Type) {
                    case TokenType.Plus:
                        next();
                        expressionLeft = new BinaryExpression('+', expressionLeft, multiplicative());
                        continue;
                    case TokenType.Minus:
                        next();
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
                        next();
                        expressionLeft = new BinaryExpression('*', expressionLeft, unary());
                        continue;
                    case TokenType.Slash:
                        next();
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
                    next();
                    expression = new UnaryExpression('-', unary());
                    break;
                case TokenType.Plus:
                    next();
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
                    next();
                    return new NumberExpression(Double.Parse(currentToken.Text));
                case TokenType.LParen:
                    next();
                    Expression subExpression = Parse();

                    if (peek(0).Type != TokenType.RParen)
                        next();
                    else
                        throw new SyntaxException("Отсутствует закрывающая скобка в строке " + peek(-1).LineNumber.ToString());

                    return subExpression;
                case TokenType.Word:
                    next();
                    return new VariableExpression(currentToken.Text);
            }

            throw new SyntaxException("Неожиданный операнд в строке " + currentToken.LineNumber.ToString());
        }

        private Token peek(int relativePos) {
            return parserData.Peek(relativePos);
        }

        private void next(int value = 1) {
            parserData.Pos += value;
        }

    }
}
