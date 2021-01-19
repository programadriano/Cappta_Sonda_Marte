using Sonda.Servicos;
using System;

namespace Sonda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite as coordenadas da primeira Sonda:");
            var posicaoSonda1 = Console.ReadLine();

            Console.WriteLine("Digite os movimentos da primeira Sonda:");
            var movimentoSonda1 = Console.ReadLine();

            Console.WriteLine("Digite as coordenadas da segunda Sonda:");
            var posicaoSonda2 = Console.ReadLine();

            Console.WriteLine("Digite as coordenadas da segunda Sonda:");
            var movimentoSonda2 = Console.ReadLine();


            var primeiraSonda = SondaServicos.Monvimentar(posicaoSonda1, movimentoSonda1);
            var segundaSonda = SondaServicos.Monvimentar(posicaoSonda2, movimentoSonda2);

            Console.WriteLine(new { coordenadaFinalSonda1 = primeiraSonda, coordenadaFinalSonda2 = segundaSonda });
            Console.ReadLine();


        }
    }
}
