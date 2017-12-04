using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInstanceDelegate
{
    public class Program
    {
        public delegate int OpAritimetica(int i, int j);

        public int Soma(int a, int b)
        {
            return a + b;
        }
        public static void Main(string[] args)
        {
            var p = new Program();

            var soma = new OpAritimetica(p.Soma);

            Console.WriteLine(soma(10, 20));
            Console.ReadKey();
        }
    }
}
