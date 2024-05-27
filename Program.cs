using System.Text;

namespace RefactoringExercise;
public class Program {
    static void Main() {
        var isRunning = true;
        var stack = new DoubleStack();
        while (isRunning) {
            if (stack.Depth == 0) {
                Console.WriteLine("Commands: q c + - * / number");
                Console.WriteLine("[]");
            }
            else {
                Console.WriteLine(stack.ToString());
            }
            var input = Console.ReadLine()?.Trim();
            if (input is "" or null) input = " ";
            var command = input[0];
            switch (command) {
                case '+': {
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                }
                case '*': {
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                }
                case '-': {
                    var d = stack.Pop();
                    stack.Push(stack.Pop() - d);
                    break;
                }
                case '/': {
                    var d = stack.Pop();
                    stack.Push(stack.Pop() / d);
                    break;
                }
                case 'c': {
                    stack.Clear();
                    break;
                }
                case 'q': {
                    isRunning = false;
                    break;
                }
                default: {
                    if (char.IsDigit(command)) {
                        var value = Convert.ToDouble(input);
                        stack.Push(value);
                    }
                    else {
                        Console.WriteLine("Illegal command, ignored");
                    }
                    break;
                }
            }
        }
    }
}

class DoubleStack {
    private double[] _data = new double[1000];
    public int Depth { get; private set; }

    public void Push(double value) => _data[Depth++] = value;
    public double Pop() {
        if (Depth > 0) {
            return _data[--Depth];
        }
        else {
            Console.WriteLine("stack empty, returning 0");
            return 0;
        }
    }
    public override string ToString() {
        var b = new StringBuilder();
        b.Append('[');
        for (int i = Depth - 1; ; i--) {
            b.Append(_data[i]);
            if (i == 0)
                return b.Append(']').ToString();
            b.Append(", ");
        }
    }
    public void Clear() => Depth = 0;
}