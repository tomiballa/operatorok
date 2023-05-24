using System;

public class Expression
{
    public int Operand1 { get; set; }
    public string Operator { get; set; }
    public int Operand2 { get; set; }
}

namespace Operatorok
{
    class Program
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
    }
}
