using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl.Statements {
    public abstract class Statement {

        public abstract void Execute(bool console = true);

        public abstract string GetLastResult();

    }
}
