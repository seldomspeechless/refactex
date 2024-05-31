// ReSharper disable All
using System.Text;
using RefactoringExercise.Classes;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise;
public static class Program {
    public static void Main() {
        Controller control = new Controller(new InConsole());
        while (true) {
            control.IsFirstLaunch = control.HandleOutput(control);
            string input = control.GetInput().Trim();
            if (!control.ProcessInput(Calculator.Stack, input))
                break;
        }
    }
}