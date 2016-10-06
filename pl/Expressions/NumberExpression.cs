using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Expressions {
    public class NumberExpression : Expression {

        private double value;

        public NumberExpression(double value) {
            this.value = value;
        }

        public override double Eval() {
            return value;
        }

        public override string ToString() {
            return value.ToString();
        }

    }
}
