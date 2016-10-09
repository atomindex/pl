using System;
using System.Runtime.Serialization;

namespace pl.Exceptions {
    //Класс синтаксической ошибки (возникающий при анализе токенов)
    public class SyntaxException : ApplicationException {

        public SyntaxException() { }

        public SyntaxException(string message) : base(message) { }

        public SyntaxException(string message, Exception inner) : base(message, inner) { }

        protected SyntaxException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
    }
}
