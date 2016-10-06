﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pl.Exceptions {
    public class ParsingException : ApplicationException {
        public ParsingException() { }

        public ParsingException(string message) : base(message) { }

        public ParsingException(string message, Exception inner) : base(message, inner) { }

        protected ParsingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}