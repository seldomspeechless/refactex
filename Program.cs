// ReSharper disable All
using System.Text;
using RefactoringExercise.Classes;
using RefactoringExercise.Interfaces;

namespace RefactoringExercise;
public class Program {
    public static void Main() {
        Controller control = new Controller(new InConsole());
        while (true) {
            control.IsFirstLaunch = control.HandleOutput(control);
            string input = Console.ReadLine()!.Trim(); // maybe i should have InConsole or the IInterface handle this?
            if (!control.ProcessInput(control.Stack, input))
                break;
        }
    }
}