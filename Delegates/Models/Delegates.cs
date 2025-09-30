namespace Delegates.Models
{
    public class Delegates
    {
        public delegate int Calculate(int x, int y);
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        public int Divide(int x, int y)
        {
            return x / y;
        }
        public int Result(int x, int y, Calculate operation)
        {
            return operation(x, y);
        }

    }
}
