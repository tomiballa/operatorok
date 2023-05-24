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
    }
}
