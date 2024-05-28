// ReSharper disable SuggestVarOrType_BuiltInTypes
namespace RefactoringExercise.Classes;

public class Calculator {
    // this is where i want the stack??
    public static StackHandler Stack { get; set; }= new();

    public enum Operation {
        ADD,
        SUBSTRACT,
        MULTIPLY,
        DIVIDE
    }

    public static void DoMath(Operation op) {
        if (!Controller.ValidationStackHasTwoValues(Stack)) return;
        switch (op) {
            case Operation.ADD: { Stack.Push(Stack.Pop() + Stack.Pop()); break; }
            case Operation.MULTIPLY: { Stack.Push(Stack.Pop() * Stack.Pop()); break; }
            case Operation.SUBSTRACT: { double d = Stack.Pop(); Stack.Push(Stack.Pop() - d); break; }
            case Operation.DIVIDE: { double d = Stack.Pop(); Stack.Push(Stack.Pop() / d); break; }
        }
    }

    public Calculator() { }
}