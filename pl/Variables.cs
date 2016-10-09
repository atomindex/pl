using System;
using System.Collections.Generic;

namespace pl {
    //Класс дляхранения значений перемнных
    static class Variables {

        private static Dictionary<string, double> variables;    //Таблица с переменными



        //Конструктор
        static Variables() {
            variables = new Dictionary<string, double>();

            variables["PI"] = Math.PI;
            variables["E"] = Math.E;
        }



        //Возвращает значение переменной
        public static double Get(string name) {
            return variables[name];
        }

        //Установливает значение переменной
        public static void Set(string name, double value) {
            variables[name] = value;
        }

    }
}
