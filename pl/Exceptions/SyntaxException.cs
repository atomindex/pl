using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pl.Exceptions {
    public class SyntaxException : ApplicationException {
        public SyntaxException() { }

        public SyntaxException(string message) : base(message) { }

        public SyntaxException(string message, Exception inner) : base(message, inner) { }

        protected SyntaxException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
