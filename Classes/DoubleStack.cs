// ReSharper disable All
using System.Text;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class DoubleStack : IStack {
    private readonly double[] _data = new double[1000];
    public int Depth { get; private set; }

    public void Push(double value) => _data[Depth++] = value;
    public double Pop() {
        if (Depth > 0)
            return _data[--Depth];
        Console.WriteLine("stack empty, returning 0");
        return 0;
    }

    public override string ToString() {
        StringBuilder builder = new StringBuilder();
        builder.Append('[');
        for (int i = Depth - 1; ; i--) {
            builder.Append(_data[i]);
            if (i == 0)
                return builder.Append(']').ToString();
            builder.Append(", ");
        }
    }

    public void Clear() => Depth = 0;
}