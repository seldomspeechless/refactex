// ReSharper disable All
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class Controller {
    public bool IsFirstLaunch = true;
    private IInterface _target = null!;

    public string GetInput(string? prompt = null) => _target.Read(prompt);
    public bool HandleOutput(Controller control) {
        if (control.IsFirstLaunch)
            _target.Write("Commands: q c + - * / number");
        _target.Write(Calculator.Stack.ToString());
        return false;
    }

    public bool ProcessInput<T>(T stack, string? input) where T : IStack {
        if (input is "" or null) input = " ";
        char command = input[0];
        if (char.IsDigit(command) && !Controller.ValidationHasTrailingTextOrSymbols(input)) {
            stack.Push(Convert.ToDouble(input));
            return true;
        }
        else if ("+-/*".Contains(command)) {
            if (ValidationStackHasTwoValues(Calculator.Stack))
                Calculator.Calculate(command);
            return true;
        }
        else if (command is 'c') Calculator.Stack.Clear();
        else if (command is 'q') return false;
        else _target.Write("Illegal command, ignored");
        return true;
    }

    private static bool ValidationHasTrailingTextOrSymbols(string? input) {
        if (input is null) return true;
        foreach (var x in input[1..])
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö+-/*".Contains(x)) return true;
        return false;
    }

    private bool ValidationStackHasTwoValues<T>(T stack) where T : IStack {
        if (stack.Depth > 1) return true;
        _target.Write("Calculator needs at least two values to compute");
        return false;
    }

    public Controller(IInterface useInterface) => _target = useInterface;
}