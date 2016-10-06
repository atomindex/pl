using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Statements {
    public class PrintStatement : Statement {

        private Expression expression;

        public PrintStatement(Expression expression) {
            this.expression = expression;
        }

        public override void Execute() {
            Console.WriteLine(expression.Eval().ToString());
        }

        public override string ToString() {
            return "print " + expression.ToString();
        }

    }
}
