// ReSharper disable All
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class ControllerNew {
    public bool IsFirstLaunch = true;
    private static IInterface _target = null!;

    public string GetInput(string? prompt = null) => _target.Read(prompt);
    public bool HandleOutput(ControllerNew control) {
        if (control.IsFirstLaunch) {
            ControllerNew._target.Write("Commands: q c + - * / number");
            ControllerNew._target.Write("[]");
        }
        else ControllerNew._target.Write(Calculator.Stack.ToString());
        return false;
    }
    
    public bool ProcessInput<T>(T stack, string? input) where T : IStack {
        if (input is "" or null) input = " ";
        char command = input[0];
        if (char.IsDigit(command) && !Controller.ValidationHasTrailingTextOrSymbols(input)) {
            double value = Convert.ToDouble(input);
            stack.Push(value);
            return true;
        }

        switch (command) {
            case '+': { Calculator.DoMath(Calculator.Operation.ADD); break; }
            case '*': { Calculator.DoMath(Calculator.Operation.MULTIPLY); break; }
            case '-': { Calculator.DoMath(Calculator.Operation.SUBSTRACT); break; }
            case '/': { Calculator.DoMath(Calculator.Operation.DIVIDE); break; }
            case 'c': { Calculator.Stack.Clear(); break; }
            case 'q': { return false; }
            default: { _target.Write("Illegal command, ignored"); break; }
        }
        return true;
    }

    private static bool ValidationHasTrailingTextOrSymbols(string? input) {
        if (input is null) return true;
        Console.WriteLine(input[1..]);
        foreach (var x in input[1..])
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö+-/*".Contains(x)) return true;
        return false;
    }

    private bool ValidationStackHasTwoValues<T>(T stack) where T : IStack {
        if (stack.Depth > 1) return true;
        _target.Write("Calculator needs at least two values to compute");
        return false;
    }

    public ControllerNew(IInterface useInterface) => _target = useInterface;
}