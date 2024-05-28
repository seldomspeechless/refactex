// ReSharper disable All
using System.Text;
using RefactoringExercise.Classes;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise;
public static class Program {
    public static void Main() {
        ControllerNew control = new ControllerNew(new InConsole());
        while (true) {
            control.IsFirstLaunch = control.HandleOutput(control);
            string input = control.GetInput().Trim();
            if (!control.ProcessInput(Calculator.Stack, input))
                break;
        }
    }
}