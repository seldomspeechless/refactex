using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class InConsole : IInterface {
    public void Write(string? data) => Console.WriteLine(data);
}