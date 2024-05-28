namespace RefactoringExercise.Interfaces;

public interface IInterface {
    public void Write(string? data);
    public string Read(string? prompt) { return string.Empty; }
}