using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Expressions {
    class VariableExpression : Expression {

        private string name;

        public VariableExpression(string name) {
            this.name = name;
        }

        public override double Eval() {
            return Variables.Get(name);
        }

        public override string ToString() {
            return name;
        }

    }
}
