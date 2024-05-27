// ReSharper disable All
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class Controller {
    public bool IsFirstLaunch = true;
    private readonly IInterface _target;
    public readonly DoubleStack Stack = new();
    
    public bool HandleOutput(Controller control) {
        if (control.IsFirstLaunch) {
            control._target.Write("Commands: q c + - * / number");
            control._target.Write("[]");
        }
        else control._target.Write(control.Stack.StringRepresentation());
        return false;
    }
    public bool ProcessInput(DoubleStack stack, string? input) {
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

    private bool ValidationHasTrailingTextOrSymbols(string? input) {
        if (input is null) return true;
        Console.WriteLine(input[1..]);
        foreach (var x in input[1..])
            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖabcdefghijklmnopqrstuvwxyzåäö+-/*".Contains(x)) return true;
        return false;
    }

    public Controller(IInterface useInterface) => _target = useInterface;
}