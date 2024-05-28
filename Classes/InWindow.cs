using RefactoringExercise.Interfaces;

namespace RefactoringExercise.Classes;

public class InWindow : IInterface {
    public void Write(string? data) { throw new NotImplementedException(); }
    public string Read(string? prompt = null) { throw new NotImplementedException(); }
}