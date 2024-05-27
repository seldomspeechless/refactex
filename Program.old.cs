using System;
using System.Text;

namespace CalculatorRPN
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleStack stack = new DoubleStack();
            while (true)
            {
                if (stack.Depth == 0)
                {
                    Console.WriteLine("Commands: q c + - * / number");
                    Console.WriteLine("[]");
                }
                else
                {
                    Console.WriteLine(stack.ToString());
                }
                string input = Console.ReadLine().Trim();
                if (input == "") input = " ";
                char command = input[0];
                if (Char.IsDigit(command))
                {
                    double value = Convert.ToDouble(input);
                    stack.Push(value);
                }
                else if (command == '+')
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (command == '*')
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (command == '-')
                {
                    double d = stack.Pop();
                    stack.Push(stack.Pop() - d);
                }
                else if (command == '/')
                {
                    double d = stack.Pop();
                    stack.Push(stack.Pop() / d);
                }
                else if (command == 'c')
                {
                    stack.Clear();
                }
                else if (command == 'q')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Illegal command, ignored");
                }

            }
        }
    }

    class DoubleStack
    {
        private double[] data;
        public int Depth { get; private set; }

        public DoubleStack()
        {
            data = new double[1000];
            Depth = 0;
        }

        public void Push(double value)
        {
            data[Depth++] = value;
        }

        public double Pop()
        {
            if (Depth > 0)
            {
                return data[--Depth];
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public double Peek()
        {
            if (Depth > 0)
            {
                return data[Depth - 1];
            }
            else
            {
                Console.WriteLine("stack empty, returning 0");
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append('[');
            for (int i = Depth - 1; ; i--)
            {
                b.Append(data[i]);
                if (i == 0)
                    return b.Append(']').ToString();
                b.Append(", ");
            }
        }

        public void Clear()
        {
            Depth = 0;
        }
    }
}
