using System.Collections;
using System.Text;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class StackHandler : IStack {
    private readonly Stack _data = new();
    public int Depth {
        get => _data.Count;
        set => throw new NotImplementedException();
    }

    public void Push(double value) => _data.Push(value);

    public double Pop() {
        if (Depth > 0) return Convert.ToDouble(_data.Pop());
        
        Console.WriteLine("stack empty, returning 0");
        return 0;
    }

    public override string ToString() {
        StringBuilder builder = new StringBuilder();
        builder.Append('[');
        foreach (double? i in _data.ToArray().Reverse()) {
            builder.Append(i);
            builder.Append(", ");
        }
        builder.Append(']');
        return builder.ToString();
    }

    public void Clear() => _data.Clear();
}