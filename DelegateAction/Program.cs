using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DelegateAction
{
    class Program
    {
        public static void ExecutaAcao(string nome, int idade)
        {
            Console.WriteLine($"Olá {nome}, você tem {idade} anos.");
        }

        public static double Soma(int i, int j)
        {
            return i + j;
        }

        public static bool MaiorIdade(Pessoa p)
        {
            return p.Idade >= 18;
        }

        public static List<Pessoa> ObterMaioresDeIdade(List<Pessoa> pessoas, Predicate<Pessoa> pred)
        {
            var maiores = new List<Pessoa>();

            foreach (var pessoa in pessoas)
            {
                if (pred(pessoa))
                {
                    maiores.Add(pessoa);
                }
            }

            return maiores;
        }
        static void Main(string[] args)
        {
            var acao = new Action<string, int>(ExecutaAcao);
            acao("Igor", 32);

            var funcao = new Func<int, int, double>(Soma);
            Console.WriteLine(funcao(10, 20));


            var pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa(){Nome = "Igor", Idade = 32});
            pessoas.Add(new Pessoa() { Nome = "Pedro", Idade = 19 });
            pessoas.Add(new Pessoa() { Nome = "Ana", Idade = 16 });

            var maiores = ObterMaioresDeIdade(pessoas, MaiorIdade);


            foreach (var p in maiores)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
    }
}
