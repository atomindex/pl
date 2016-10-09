using pl.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Statements {
    public class AssigmentStatement : Statement {

        private string variableName;
        private Expression expression;

        private string lastResult;

        public AssigmentStatement(string variableName, Expression expression) {
            this.variableName = variableName;
            this.expression = expression;
        }

        public override void Execute(bool console = true) {
            double result = expression.Eval();
            Variables.Set(variableName, result);
            lastResult = variableName + " = " + result.ToString();
        }

        public override string GetLastResult() {
            return lastResult;
        }

        public override string ToString() {
            return variableName + " = " + expression.ToString();
        }

    }
}
