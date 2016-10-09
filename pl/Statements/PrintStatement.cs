using pl.Expressions;
using System;

namespace pl.Statements {
    //Класс команды вывода в консоль
    public class PrintStatement : Statement {

        private Expression expression;      //Выражение
        private string lastResult;          //Значение последнего выполнения



        //Конструктор
        public PrintStatement(Expression expression) {
            this.expression = expression;
        }



        //Запускает команду
        public override void Execute(bool console = true) {
            string result = expression.Eval().ToString();
            if (console) Console.WriteLine(result);
            lastResult = "print " + result;
        }



        //Возвращает результат выполнения в строковом представленнии (для трассировки)
        public override string GetLastResult() {
            return lastResult;
        }

        //Возвращает строковое представление команды
        public override string ToString() {
            return "print " + expression.ToString();
        }

    }
}
