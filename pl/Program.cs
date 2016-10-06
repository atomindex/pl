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
            string input = "bla = (param1 + param2) * --4.5";
            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            foreach (Token token in tokens)
                Console.WriteLine(token.ToString());

            Parser parser = new Parser(tokens);
            List<Statement> statements = parser.Parse();

            foreach (Statement statement in statements) {
                statement.Execute();
                Console.WriteLine(statement.ToString());
            }
            
            Console.ReadKey();
        }
    }
}
