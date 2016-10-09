using pl.Expressions;

namespace pl.Statements {
    //Класс команды присваивания
    public class AssigmentStatement : Statement {

        private string variableName;            //Название переменной
        private Expression expression;          //Выражение

        private string lastResult;              //Значение последнего выполнения



        //Конструктор
        public AssigmentStatement(string variableName, Expression expression) {
            this.variableName = variableName;
            this.expression = expression;
        }



        //Запускает команду
        public override void Execute(bool console = true) {
            double result = expression.Eval();
            Variables.Set(variableName, result);
            lastResult = variableName + " = " + result.ToString();
        }



        //Возвращает результат выполнения в строковом представленнии (для трассировки)
        public override string GetLastResult() {
            return lastResult;
        }

        //Возвращает строковое представление команды
        public override string ToString() {
            return variableName + " = " + expression.ToString();
        }

    }
}
