using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateInfo
{

    public delegate int OpAritimetica(int i, int j);
    public class Program
    {
        public static int Soma(int a, int b)
        {
            return a + b;
        }

        public static int Subtracao(int a, int b)
        {
            return a - b;
        }

        public static int Divisao(int a, int b)
        {
            if (b > 0)
            {
                return a / b;
            }

            return 0;
        }

        public static int Multiplicacao(int a, int b)
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
            var ops = new OpAritimetica(Program.Soma);
            ops += new OpAritimetica(Program.Subtracao);
            ops += Program.Divisao;
            ops += Program.Multiplicacao;

            Program.DisplayDelegateInfo(ops);

            Console.ReadKey();
        }
    }
}
