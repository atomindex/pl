using System;

namespace pl {
    //Класс токена
    class Token {

        public TokenType Type;      //Тип токена
        public string Text;         //Значение токена
        public int LineNumber;      //Строка в исходном коде



        //Конструктор
        public Token(TokenType type, string text, int lineNumber) {
            Type = type;
            Text = text;
            LineNumber = lineNumber;
        }



        //Возвращает информацию о токене
        public override string ToString() {
            return Type.ToString() + " " + Text;
        }

    }
}
