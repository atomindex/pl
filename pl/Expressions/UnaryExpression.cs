using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Expressions {
    public class UnaryExpression : Expression {

        private Expression expression;
        private char operation;

        public UnaryExpression(char operation, Expression expression) {
            this.expression = expression;
            this.operation = operation;
        }

        public override double Eval() {
            switch (operation) {
                case '-':
                    return -expression.Eval();
                case '+':
                default:
                    return expression.Eval();
            }
        }

        public override string ToString() {
            return operation + expression.ToString();
        }

    }
}
