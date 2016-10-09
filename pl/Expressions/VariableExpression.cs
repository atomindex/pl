using pl.Exceptions;

namespace pl.Expressions {
    //Класс выражения переменной
    class VariableExpression : Expression {

        private string name;    //Имя переменной



        //Конструктор
        public VariableExpression(string name) {
            this.name = name;
        }



        //Выполняет выражение
        public override double Eval() {
            if (!Variables.Exists(name))
                throw new UndefinedVariableException("Переменная " + name + " не определена");
            return Variables.Get(name);
        }



        //Возвращает строковое представление выражения
        public override string ToString() {
            return name;
        }

    }
}
