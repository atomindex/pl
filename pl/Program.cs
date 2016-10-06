using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Program {
        static void Main(string[] args) {

            string input = "2 + 2 * --4";
            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            Parser parser = new Parser(tokens);
            List<Expression> expressions = parser.Parse();

            foreach (Expression expression in expressions)
                Console.WriteLine(expression.ToString() + " = " + expression.Eval().ToString());

            Console.ReadKey();
        }
    }
}
