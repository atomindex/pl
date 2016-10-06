using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Expressions {
    public class BinaryExpression : Expression {

        private Expression expressionLeft;
        private Expression expressionRight;
        private char operation;

        public BinaryExpression(char operation, Expression expressionLeft, Expression expressionRight) {
            this.expressionLeft = expressionLeft;
            this.expressionRight = expressionRight;
            this.operation = operation;
        }

        public override double Eval() {
            switch (operation) {
                case '+':
                    return expressionLeft.Eval() + expressionRight.Eval();
                case '-':
                    return expressionLeft.Eval() - expressionRight.Eval(); 
                case '*':
                    return expressionLeft.Eval() * expressionRight.Eval();
                case '/':
                    return expressionLeft.Eval() / expressionRight.Eval();
                default:
                    return 0;
            }
        }

        public override string ToString() {
            return expressionLeft.ToString() + " " + operation + " " + expressionRight.ToString(); 
        }

    }
}
