using System;

namespace InstanceDelegateInfo
{
    public delegate int OpAritimetica(int i, int j);
    public class Program
    {
        public int Soma(int a, int b)
        {
            return a + b;
        }

        public int Subtracao(int a, int b)
        {
            return a - b;
        }

        public int Divisao(int a, int b)
        {
            if (b > 0)
            {
                return a / b;
            }

            return 0;
        }

        public int Multiplicacao(int a, int b)
        {
            return a * b;
        }


        public static void DisplayDelegateInfo(Delegate del)
        {
            foreach (var d in del.GetInvocationList())
            {
                Console.WriteLine($"Método: {d.Method}");
                Console.WriteLine($"Target: {d.Target}");
            }
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var ops = new OpAritimetica(p.Soma);
            ops += new OpAritimetica(p.Subtracao);
            ops += p.Divisao;
            ops += p.Multiplicacao;

            Program.DisplayDelegateInfo(ops);

            Console.ReadKey();
        }
    }
}
