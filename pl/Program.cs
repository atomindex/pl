using pl.Expressions;
using pl.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Program {
        static void Main(string[] args) {
            string input = "print 5 + 5 print 2 + 2";
            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            Parser parser = new Parser(tokens);
            List<Statement> statements = parser.Parse();

            foreach (Statement statement in statements)
                statement.Execute();
            
            Console.ReadKey();
        }
    }
}
