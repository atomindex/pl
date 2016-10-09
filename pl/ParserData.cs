using System.Collections.Generic;

namespace pl {
    //Класс данных парсера
    class ParserData {

        private static Token tokenEOF;      //Токен конца файла

        public int Pos;                     //Индекс текущего токена
        private List<Token> tokens;         //Список токенов
        private int length;                 //Количество токенов    



        //Конструктор
        static ParserData() {
            tokenEOF = new Token(TokenType.EOF, "", 0);
        }

        //Конструктор
        public ParserData(List<Token> tokens) {
            this.tokens = tokens;
            this.length = tokens.Count;
        }



        //Возвращает токен с относительным индексом
        public Token Peek(int relativePosition) {
            int position = Pos + relativePosition;
            if (position >= length) return tokenEOF;
            return tokens[position];
        }

    }
}
