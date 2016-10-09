namespace pl.Expressions {
    //Класс выражения числа
    public class NumberExpression : Expression {

        private double value;       //Значение



        //Конструктор
        public NumberExpression(double value) {
            this.value = value;
        }



        //Выполняет выражение
        public override double Eval() {
            return value;
        }



        //Возвращает строковое представление выражения
        public override string ToString() {
            return value.ToString();
        }

    }
}
