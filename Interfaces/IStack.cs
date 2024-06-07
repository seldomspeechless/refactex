namespace RefactoringExercise.Interfaces;

public interface IStack {
    public int Depth { get; }
    public void Push(double value);
    public double Pop();
    public void Clear();
}