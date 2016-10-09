namespace pl.Statements {
    //Базовый класс комманды
    public abstract class Statement {

        //Запускает команду
        public abstract void Execute(bool console = true);

        //Возвращает результат выполнения в строковом представленнии (для трассировки)
        public abstract string GetLastResult();

    }
}
