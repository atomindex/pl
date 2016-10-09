using pl.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace pl {
    //Класс лексического анализатора
    class Lexer {

        private static string spaces;                    //Список символов пробелов
        private static string operators;                 //Список символов операторов
        private static TokenType[] operatorsTokenTypes;  //Массив типов токенов, соответсвующих операторам

        private string input;                            //Входная строка
        private int length;                              //Длина строки
        private int pos;                                 //Индекс текущего символа
        private List<Token> tokens;                      //Список токенов
        private int currentLine;                         //Номер текущей строки



        //Статический конструктор
        static Lexer() {
            spaces = " \t\r\n";
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



        //Конструктор
        public Lexer(string input) {
            this.input = input;
            this.length = input.Length;
            currentLine = 1;
        }



        //Разбивает входную строку на токены и возвращает их
        public List<Token> Tokenize() {
            tokens = new List<Token>();
            pos = 0;

            while (pos < length) {
                char currentChar = peek();

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

        //Добавляет токен числа
        private void tokenizeNumber() {
            StringBuilder sb = new StringBuilder();

            bool hasDot = false;
            while (true) {
                char currentChar = peek();

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

        //Добавляет токен слова
        private void tokenizeWord() {
            StringBuilder sb = new StringBuilder();

            char currentChar = peek();
            while (char.IsLetterOrDigit(currentChar) || currentChar == '_') {
                sb.Append(currentChar);
                pos++;
                currentChar = peek();
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

        //Добавляет токен оператора
        private void tokenizeOperator() {
            char currentChar = peek();
            addToken( 
                operatorsTokenTypes[ operators.IndexOf(currentChar) ], 
                currentChar.ToString() 
            );
            pos++;
        }

        //Добавляет токен в список
        private void addToken(TokenType type, string text) {
            tokens.Add(new Token(type, text, currentLine));
        }



        //Возвращает символ с относительным индексом
        private char peek(int relativePosition = 0) {
            int position = pos + relativePosition;
            return position >= length ? '\0' : input[position];
        }

    }
}
