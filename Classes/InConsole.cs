using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class InConsole : IInterface {
    public void Write(string? data) => Console.WriteLine(data);
    public string Read(string? prompt = null) {
        if (prompt is not null)
            Console.Write($"\n{prompt} ");
        return Console.ReadLine()!;
    }
}