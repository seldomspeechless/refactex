namespace RefactoringExercise.Interfaces;

public class InConsole : IInterface {
    public void Write(string? data) => Console.WriteLine(data);
}