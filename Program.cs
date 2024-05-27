// ReSharper disable All
using System.Text;
using RefactoringExercise.Classes;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise;
public class Program {
    public static void Main() {
        Controller control = new Controller(new InConsole());
        bool isRunning = true;
        while (isRunning) {
            control.IsFirstLaunch = control.HandleOutput(control);
            string input = Console.ReadLine()!.Trim();
            if (!control.ProcessInput(control.Stack, input))
                isRunning = false;
        }
    }
}