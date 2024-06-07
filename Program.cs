// ReSharper disable All
using System.Text;
using RefactoringExercise.Classes;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise;
public static class Program {
    public static void Main() {
        IUI ui = new UIConsole();
        Controller control = new Controller(ui);
        while (true) {
            control.IsFirstLaunch = control.HandleOutput(control);
            string input = control.GetInput().Trim();
            if (!control.ProcessInput(Calculator.Stack, input))
                break;
        }
    }
}