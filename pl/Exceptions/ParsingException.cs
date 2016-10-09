using System;
using System.Runtime.Serialization;

namespace pl.Exceptions {
    //Класс лексической ошибки (возникающей при токенизации)
    public class ParsingException : ApplicationException {

        public ParsingException() { }

        public ParsingException(string message) : base(message) { }

        public ParsingException(string message, Exception inner) : base(message, inner) { }

        protected ParsingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
    }
}
