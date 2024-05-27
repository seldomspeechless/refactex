// ReSharper disable All
using System.Text;

namespace RefactoringExercise;
public class Program {
    public static void Main() {
        DoubleStack stack = new DoubleStack();
        bool isRunning = true;
        while (isRunning) {
            stack.isFirstLaunch = HandleOutput(stack);
            string input = Console.ReadLine()!.Trim();
            if (!ProcessInput(stack, input))
                isRunning = false;
        }
    }

    public static bool HandleOutput(DoubleStack stack) {
        if (stack.isFirstLaunch) {
            stack.outputTarget.Write("Commands: q c + - * / number");
            stack.outputTarget.Write("[]");
        }
        else stack.outputTarget.Write(stack.StringRepresentation());
        return false;
    }
    public static bool ProcessInput(DoubleStack stack, string? input) {
        if (input is "" or null) input = " ";
        char command = input[0];
        if (char.IsDigit(command) && !ValidationHasTrailingTextOrSymbols(input)) {
            double value = Convert.ToDouble(input);
            stack.Push(value);
            return true;
        }
        switch (command) {
            case '+': {
                stack.Push(stack.Pop() + stack.Pop());
                break;
            }
            case '*': {
                stack.Push(stack.Pop() * stack.Pop());
                break;
            }
            case '-': {
                double d = stack.Pop();
                stack.Push(stack.Pop() - d);
                break;
            }
            case '/': {
                double d = stack.Pop();
                stack.Push(stack.Pop() / d);
                break;
            }
            case 'c': {
                stack.Clear();
                break;
            }
            case 'q': {
                return false;
            }
            default: {
                Console.WriteLine("Illegal command, ignored");
                break;
            }
        }
        return true;
    }

    public static bool ValidationHasTrailingTextOrSymbols(string? input) {
        if (input is null) return true;
        Console.WriteLine(input[1..]);
        foreach (var x in input[1..])
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö+-/*".Contains(x)) return true;
        return false;
    }
}

public class DoubleStack {
    public IInterface outputTarget = new IConsole();
    public bool isFirstLaunch = true;
    private double[] _data = new double[1000];
    public int Depth { get; private set; }

    public void Push(double value) => _data[Depth++] = value;
    public double Pop() {
        if (Depth > 0) {
            return _data[--Depth];
        }
        else {
            Console.WriteLine("stack empty, returning 0");
            return 0;
        }
    }
    public string StringRepresentation() {
        StringBuilder b = new StringBuilder();
        b.Append('[');
        for (int i = Depth - 1; ; i--) {
            b.Append(_data[i]);
            if (i == 0)
                return b.Append(']').ToString();
            b.Append(", ");
        }
    }
    public void Clear() => Depth = 0;
}

public interface IInterface {
    public void Write(string? data);
}

public class IConsole : IInterface {
    public void Write(string? data) => Console.WriteLine(data);
}