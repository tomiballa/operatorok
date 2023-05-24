using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Operatorok
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressions = File.ReadAllLines("kifejezesek.txt")
                .Select(line => line.Split(' '))
                .Select(parts => new Expression
                {
                    Operand1 = int.Parse(parts[0]),
                    Operator = parts[1],
                    Operand2 = int.Parse(parts[2])
                })
                .ToList();

            Console.WriteLine($"2. feladat: Kifejezesek száma: {expressions.Count}");
            Console.WriteLine($"3. feladat: Kifejezesek maradékos osztással: {expressions.Count(e => e.Operator == "mod")}");
            Console.WriteLine($"4. feladat: {(expressions.Any(e => e.Operand1 % 10 == 0 && e.Operand2 % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!")}");

            var operators = new[] { "mod", "/", "div", "-", "*", "+" };
            Console.WriteLine("5. feladat: Statisztika");
            operators.ToList().ForEach(op => Console.WriteLine($"{op} -> {expressions.Count(e => e.Operator == op)} db"));

            while (true)
            {
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                var input = Console.ReadLine();
                if (input == "vége") break;

                var parts = input.Split(' ');
                var expression = new Expression
                {
                    Operand1 = int.Parse(parts[0]),
                    Operator = parts[1],
                    Operand2 = int.Parse(parts[2])
                };
                Console.WriteLine($"{input} = {EvaluateExpression(expression)}");
            }

            Console.WriteLine("8. feladat: eredmenyek.txt");
            File.WriteAllLines("eredmenyek.txt", expressions.Select(e => $"{e.Operand1} {e.Operator} {e.Operand2} = {EvaluateExpression(e)}"));
        }

        static string EvaluateExpression(Expression expression)
        {
            try
            {
                return expression.Operator switch
                {
                    "+" => (expression.Operand1 + expression.Operand2).ToString(),
                    "-" => (expression.Operand1 - expression.Operand2).ToString(),
                    "*" => (expression.Operand1 * expression.Operand2).ToString(),
                    "/" => ((double)expression.Operand1 / expression.Operand2).ToString(),
                    "div" => (expression.Operand1 / expression.Operand2).ToString(),
                    "mod" => (expression.Operand1 % expression.Operand2).ToString(),
                    _ => "Hibás operátor!"
                };
            }
            catch
            {
                return "Egyéb hiba!";
            }
        }
    }
}
