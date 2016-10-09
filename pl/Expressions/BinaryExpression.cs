namespace pl.Expressions {
    //Класс бинарного выражения
    public class BinaryExpression : Expression {

        private Expression expressionLeft;      //Левая часть выражения
        private Expression expressionRight;     //Правая часть выражения
        private char operation;                 //Оператор



        //Конструктор
        public BinaryExpression(char operation, Expression expressionLeft, Expression expressionRight) {
            this.expressionLeft = expressionLeft;
            this.expressionRight = expressionRight;
            this.operation = operation;
        }



        //Выполняет выражение
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


        
        //Возвращает строковое представление выражения
        public override string ToString() {
            return expressionLeft.ToString() + " " + operation + " " + expressionRight.ToString(); 
        }

    }
}
