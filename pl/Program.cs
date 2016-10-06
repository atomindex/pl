using pl.Exceptions;
using pl.Expressions;
using pl.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Program {

        static void PrintError(string error) {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n" + error + "\n\n");
            Console.ForegroundColor = tempColor;
        }

        static void Main(string[] args) {
            string input = "print 5 + 5 print 2 + 2)";
            Lexer lexer = new Lexer(input);

            List<Token> tokens;
            try {
                tokens = lexer.Tokenize();
            } catch (ParsingException exception) {
                PrintError(exception.Message);
                return;
            }

            foreach (Token token in tokens)
                Console.WriteLine(token.ToString());

            Parser parser = new Parser(tokens);

            List<Statement> statements;
            try {
                statements = parser.Parse();
            } catch (SyntaxException exception) {
                PrintError(exception.Message);
                return;
            }

            foreach (Statement statement in statements)
                statement.Execute();
            
            Console.ReadKey();
        }
    }
}
