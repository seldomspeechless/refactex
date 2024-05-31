// ReSharper disable All
using System.Data;

namespace RefactoringExercise.Classes;

public static class Calculator {
    public static StackHandler Stack { get; set; }= new();

    public static void Calculate(char op) {
        double y = Stack.Pop();
        double x = Stack.Pop();
        Dictionary<char, Func<double, double, double>> calc = new() {
            { '+', (x, y) => x + y },
            { '-', (x, y) => x - y },
            { '*', (x, y) => x * y },
            { '/', (x, y) => x / y },
        };
        Stack.Push(calc[op].Invoke(x, y));
    }
}