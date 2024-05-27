// ReSharper disable All
using System.Text;

namespace RefactoringExercise;
public class Program {
    public static void Main() {
        Controller controller = new Controller();
        bool isRunning = true;
        while (isRunning) {
            controller.isFirstLaunch = HandleOutput(controller);
            string input = Console.ReadLine()!.Trim();
            if (!ProcessInput(controller.stack, input))
                isRunning = false;
        }
    }

    public static bool HandleOutput(Controller control) {
        if (control.isFirstLaunch) {
            control.outputTarget.Write("Commands: q c + - * / number");
            control.outputTarget.Write("[]");
        }
        else control.outputTarget.Write(control.stack.StringRepresentation());
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

public class Controller {
    public IInterface outputTarget = new InConsole();
    public bool isFirstLaunch = true;
    public DoubleStack stack = new DoubleStack();
}

public class DoubleStack {
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

public class InConsole : IInterface {
    public void Write(string? data) => Console.WriteLine(data);
}

public class InWindow : IInterface {
    public void Write(string? data) { throw new NotImplementedException(); }
}