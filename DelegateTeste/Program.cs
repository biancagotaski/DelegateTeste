using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTeste
{
    public delegate int OpAritimetica(int i, int j);
    class Program
    {
        public static int Soma(int a, int b)
        {
            Console.WriteLine("Soma");
            return a + b;
        }

        public static void Main(string[] args)
        {
            var soma = new OpAritimetica(Program.Soma);
            
            Console.WriteLine(soma(10, 20));
            Console.ReadKey();
        }
    }
}
