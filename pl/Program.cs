﻿using pl.Exceptions;
using pl.Expressions;
using pl.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl {
    class Program {

        static void PrintError(string error) {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n" + error + "\n\n");
            Console.ForegroundColor = tempColor;
        }

        static void PrintArgumentError(string error) {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n" + error + "\n\n");
            Console.ForegroundColor = tempColor;
        }

        static void PrintHelp() {
            Console.WriteLine("help\t\t- помощь");
            Console.WriteLine("run [path]\t- запуск программы");
            Console.WriteLine("tokens [path]\t- отображение токенов");
            Console.WriteLine("trace [path]\t- отображение вызова функций\n");
        }

        static void PrintTokens(List<Token> tokens) {
            foreach (Token token in tokens)
                Console.WriteLine(token.ToString());
            Console.WriteLine("");
        }

        static void PrintStatements(List<Statement> statements) {
            foreach (Statement statement in statements) {
                Console.Write(statement.ToString());
                statement.Execute(false);
                Console.WriteLine(" [" + statement.GetLastResult() + "]");
            }
            Console.WriteLine("");
        }

        static string CommandQuery(string[] args) {
            string command;
            string[] commands = new string[] {
                "help", "run", "tokens", "trace"
            };

            if (args.Length > 0) {
                command = args[0];
            } else {
                Console.Write("Введите комманду:\n> ");
                command = Console.ReadLine();
            }

            if (!commands.Contains(command)) {
                PrintArgumentError("Такой команды нет.\nВведите help для вывода списка команд.");
                return null;
            }

            return command;
        }

        static string PathQuery(string[] args) {
            string path;

            if (args.Length > 1) {
                path = args[1];
            } else {
                Console.Write("Введите путь к файлу:\n> ");
                path = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());             
            }

            if (!File.Exists(path)) {
                PrintArgumentError("Файл не найден");
                return null;
            } 

            return path;
        }

        static void Main(string[] args) {
            //Запрашиваем команду
            string command = CommandQuery(args);
            if (command == null) return;
            Console.WriteLine("");

            //Выводим справку
            if (command == "help") {
                PrintHelp();
                return;
            }

            //Запрашиваем путь к файлу
            string path = PathQuery(args);
            if (path == null) return;
            Console.WriteLine("");
            
            //Читаем файл
            string input = File.ReadAllText(path, Encoding.UTF8);
            
            //Лексический анализ
            Lexer lexer = new Lexer(input);
            List<Token> tokens;
            try {
                tokens = lexer.Tokenize();
            } catch (ParsingException exception) {
                PrintError(exception.Message);
                return;
            }

            //Выводим список токенов
            if (command == "tokens") {
                PrintTokens(tokens);
                return;
            }

            //Синтаксический анализ
            Parser parser = new Parser(tokens);
            List<Statement> statements;
            try {
                statements = parser.Parse();
            } catch (SyntaxException exception) {
                PrintError(exception.Message);
                return;
            }

            //Выводим список команд
            if (command == "trace") {
                PrintStatements(statements);
                return;
            }

            //Запуск программы
            if (command == "run") {
                foreach (Statement statement in statements)
                    statement.Execute();
            }
        }
    }
}
