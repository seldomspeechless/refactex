// ReSharper disable All

using System.Data;

namespace RefactoringExercise.Classes;

public static class Calculator {
    public static StackHandler Stack { get; set; }= new();

    public enum Operation {
        ADD,
        SUBSTRACT,
        MULTIPLY,
        DIVIDE
    }

    public static void DoMath(Operation op) {
        switch (op) {
            case Operation.ADD: { Stack.Push(Stack.Pop() + Stack.Pop()); break; }
            case Operation.MULTIPLY: { Stack.Push(Stack.Pop() * Stack.Pop()); break; }
            case Operation.SUBSTRACT: { double d = Stack.Pop(); Stack.Push(Stack.Pop() - d); break; }
            case Operation.DIVIDE: { double d = Stack.Pop(); Stack.Push(Stack.Pop() / d); break; }
        }
    }
    
    public static void Multiply() => Stack.Push(Stack.Pop() * Stack.Pop());
    public static void Add() => Stack.Push(Stack.Pop() + Stack.Pop());
    public static void Divide() {
        double d = Stack.Pop();
        Stack.Push(Stack.Pop() / d);
    }
    public static void Substract() { // todo: think we can merge all four of these
        double d = Stack.Pop();
        Stack.Push(Stack.Pop() - d);
    }

    public static void Calculate(char operation) {
        double d = Stack.Pop();
        Stack.Push(Convert.ToDouble(new DataTable().Compute($"{Stack.Pop()}{operation}{d}", null)));
    }
}