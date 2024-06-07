// ReSharper disable All
using System.Collections;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class StackHandler : IStack {
    private readonly Stack _data = new();
    public int Depth => _data.Count;

    public void Push(double value) => _data.Push(value);

    public double Pop() {
        if (Depth > 0) return Convert.ToDouble(_data.Pop());
        
        Console.WriteLine("stack empty, returning 0");
        return 0;
    }

    public override string ToString() => "[" + string.Join(", ", _data.ToArray()) + "]";

    public void Clear() => _data.Clear();
}