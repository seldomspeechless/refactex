namespace RefactoringExercise.Interfaces;

public interface IUI {
    public void Write(string? data);
    public string Read(string? prompt);
}