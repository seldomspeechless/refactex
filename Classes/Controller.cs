// ReSharper disable All
using System.Security.Cryptography;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class Controller {
    public bool IsFirstLaunch = true;
    private IUI _ui = null!;
    private Calculator _calculator = new();

    public string GetInput(string? prompt = null) => _ui.Read(prompt);
    public bool HandleOutput(Controller control) {
        if (control.IsFirstLaunch) {
            var commandList = new List<string> {"q", "c", "number"};
            commandList.AddRange(_calculator.ListOfOperations);
            _ui.Write($"Commands: {string.Join(" ", commandList)}");
        }
        _ui.Write(Calculator.Stack.ToString());
        return false;
    }

    public bool ProcessInput<T>(T stack, string input) where T : IStack {
        switch (input.ToLower()) {
            case "+":
            case "-":
            case "/":
            case "*": {
                if (ValidationStackHasTwoValues(Calculator.Stack))
                    _calculator.Calculate(input);
                return true;
            }
            case "c": {
                Calculator.Stack.Clear();
                return true;
            }
            case "q": {
                return false;
            }
            default: {
                if (ValidationIsAllNumbers(input))
                    stack.Push(Convert.ToDouble(input));
                else
                    _ui.Write("Illegal command, ignored");
                return true;
            }
        }
    }

    private bool ValidationStackHasTwoValues<T>(T stack) where T : IStack {
        if (stack.Depth > 1) return true;
        _ui.Write("Calculator needs at least two values to compute");
        return false;
    }

    private bool ValidationIsAllNumbers(string input) {
        try {
            input.ToList().ForEach(c => {
                var test = Int16.TryParse(c.ToString(), out var _);
            });
        }
        catch {
            return false;
        }
        return true;
    }

    public Controller(IUI uiToUse) => _ui = uiToUse;
}