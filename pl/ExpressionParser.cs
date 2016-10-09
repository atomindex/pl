using pl.Exceptions;
using pl.Expressions;
using System;

namespace pl {
    //Класс синтаксического анализатора арифметических выражений
    class ExpressionParser {

        private ParserData parserData;      //Данные парсера



        //Конструктор
        public ExpressionParser(ParserData parserData) {
            this.parserData = parserData;
        }



        //Возвращает выражение
        public Expression Parse() {
            return additive();
        }

        //Формирует и возвращает выражение суммы и разности
        private Expression additive() {
            Expression expressionLeft = multiplicative();

            while (true) {
                switch (peek().Type) {
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

        //Формирует и возвращает выражение умножени и деления
        private Expression multiplicative() {
            Expression expressionLeft = unary();

            while (true) {

                switch (peek().Type) {
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

        //Формирует и возвращает унарные выражения
        private Expression unary() {
            Expression expression;

            switch (peek().Type) {
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

        //Формирует и возвращает выражения чисел, переменных и подвыражения в скобках
        private Expression primary() {
            Token currentToken = peek();

            switch (currentToken.Type) {
                case TokenType.Number:
                    next();
                    return new NumberExpression(Double.Parse(currentToken.Text));
                case TokenType.LParen:
                    next();
                    Expression subExpression = Parse();

                    if (peek().Type == TokenType.RParen)
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



        //Возвращает токен с относительным индексом
        private Token peek(int relativePos = 0) {
            return parserData.Peek(relativePos);
        }

        //Увеличивает позицию (переходит на следующий токен)
        private void next(int value = 1) {
            parserData.Pos += value;
        }

    }
}
