// ReSharper disable SuggestVarOrType_BuiltInTypes
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

    public override string ToString() {
        string res = string.Empty;
        var array = _data.Cast<double>();
        var enumerable = array.ToList();
        for (var i = 0; i < enumerable.Count; i++) {
            res += enumerable[i];
            if (i != enumerable.Count - 1) res += ", ";
        }

        return res.Insert(0, "[").Insert(res.Length+1, "]");
    }

    public void Clear() => _data.Clear();
}