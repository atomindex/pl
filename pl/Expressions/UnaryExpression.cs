namespace pl.Expressions {
    //Класс унарного выражения
    public class UnaryExpression : Expression {

        private Expression expression;      //Выражение
        private char operation;             //Оператор



        //Конструктор
        public UnaryExpression(char operation, Expression expression) {
            this.expression = expression;
            this.operation = operation;
        }



        //Выполняет выражение
        public override double Eval() {
            switch (operation) {
                case '-':
                    return -expression.Eval();
                case '+':
                default:
                    return expression.Eval();
            }
        }



        //Возвращает строковое представление выражения
        public override string ToString() {
            return operation + expression.ToString();
        }

    }
}
