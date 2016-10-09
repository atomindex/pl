using pl.Exceptions;
using pl.Expressions;
using pl.Statements;
using System.Collections.Generic;

namespace pl {
    //Класс синтаксического анализатора
    class Parser {

        private ExpressionParser expressionParser;  //Синтаксический анализатор арифметических выражений
        private ParserData parserData;              //Данные парсера



        //Конструктор
        public Parser(List<Token> tokens) {
            parserData = new ParserData(tokens);
            expressionParser = new ExpressionParser(parserData);
        }



        //Парсит токены и возвращает список из statement
        public List<Statement> Parse() {
            List<Statement> statements = new List<Statement>();

            while (peek().Type != TokenType.EOF)
                statements.Add(statement());

            return statements;
        }

        //Формирует определенный statement исходя из текущего токена
        private Statement statement() {
            if (peek().Type == TokenType.Print) {
                next();
                return new PrintStatement(expressionParser.Parse());
            } else
                return assigmentStatement();
        }

        //Формирует statement присваивания
        private Statement assigmentStatement() {
            Token currentToken = peek();

            if (currentToken.Type == TokenType.Word && peek(1).Type == TokenType.Eq) {
                string variableName = currentToken.Text;
                next(2);
                Expression variableExpression = expressionParser.Parse();
                return new AssigmentStatement(variableName, variableExpression);
            }

            throw new SyntaxException("Неожиданное выражение '" + currentToken.Text + "' в строке " + currentToken.LineNumber.ToString());
        }



        //Возвращает токен с относительным индексом
        private Token peek(int relativePos =0) {
            return parserData.Peek(relativePos);
        }

        //Переходит на следующий индекс
        private void next(int value = 1) {
            parserData.Pos += value;
        }

    }
}
