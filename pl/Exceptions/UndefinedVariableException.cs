using System;
using System.Runtime.Serialization;

namespace pl.Exceptions {
    //Класс ошибки отсутсвия переменной
    public class UndefinedVariableException : ApplicationException {

        public UndefinedVariableException() { }

        public UndefinedVariableException(string message) : base(message) { }

        public UndefinedVariableException(string message, Exception inner) : base(message, inner) { }

        protected UndefinedVariableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    
    }
}
