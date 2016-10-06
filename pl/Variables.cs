using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    static class Variables {

        private static Dictionary<string, double> variables;

        static Variables() {
            variables = new Dictionary<string, double>();

            variables["param1"] = 5;
            variables["param2"] = 2;
        }

        public static double Get(string name) {
            return variables[name];
        }

        public static void Set(string name, double value) {
            variables[name] = value;
        }

    }
}
