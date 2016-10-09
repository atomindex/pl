using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Statements {
    public class PrintStatement : Statement {

        private Expression expression;
        private string lastResult;

        public PrintStatement(Expression expression) {
            this.expression = expression;
        }

        public override void Execute(bool console = true) {
            string result = expression.Eval().ToString();
            if (console) Console.WriteLine(result);
            lastResult = "print " + result;
        }

        public override string GetLastResult() {
            return lastResult;
        }

        public override string ToString() {
            return "print " + expression.ToString();
        }

    }
}
