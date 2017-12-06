using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEventUsage
{
    class Program
    {
        public static void ExibirMensagem(string msg)
        {
            Console.WriteLine(msg);
        }
        static void Main(string[] args)
        {
            var carro = new Carro();
            carro.Explodiu += ExibirMensagem;
            carro.QuaseExplodindo += ExibirMensagem;

            for (int i = 1; i <= 100; i++)
            {
                carro.Acelerarar(10);
            }

            Console.ReadKey();

        }
    }
}
