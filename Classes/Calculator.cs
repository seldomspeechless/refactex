// ReSharper disable All
using System.Data;

namespace RefactoringExercise.Classes;

public class Calculator {
    public static StackHandler Stack { get; set; }= new();
    
    private Dictionary<string, Func<double>> calc = new() {
        { "+", () => Stack.Pop() + Stack.Pop() },
        { "*", () => Stack.Pop() * Stack.Pop() },
        { "-", () => { double y = Stack.Pop(); return Stack.Pop() - y; } }, 
        { "/", () => { double y = Stack.Pop(); return Stack.Pop() / y; } }, 
        { "sin", () => Math.Sin(Stack.Pop()) },
    };
    public List<string> ListOfOperations => calc.Keys.ToList();

    public void Calculate(char op) => Calculate(op.ToString());
    public void Calculate(string op) => Stack.Push(calc[op].Invoke());
}