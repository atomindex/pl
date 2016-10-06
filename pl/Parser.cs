using pl.Expressions;
using pl.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Parser {
        private ExpressionParser expressionParser;
        private ParserData parserData;


        public Parser(List<Token> tokens) {
            parserData = new ParserData(tokens);
            expressionParser = new ExpressionParser(parserData);
        }

        public List<Statement> Parse() {
            List<Statement> expressions = new List<Statement>();

            while (peek(0).Type != TokenType.EOF) {
                expressions.Add(statement());
            }

            return expressions;
        }

        private Statement statement() {
            if (peek(0).Type == TokenType.Print) {
                next();
                return new PrintStatement(expressionParser.Parse());
            } else
                return assigmentStatement();
        }

        private Statement assigmentStatement() {
            Token currentToken = peek(0);

            if (currentToken.Type == TokenType.Word && peek(1).Type == TokenType.Eq) {
                string variableName = currentToken.Text;
                next(2);
                Expression variableExpression = expressionParser.Parse();
                return new AssigmentStatement(variableName, variableExpression);
            }

            return null;
        }

        private Token peek(int relativePos) {
            return parserData.Peek(relativePos);
        }

        private void next(int value = 1) {
            parserData.Pos += value;
        }

    }
}
