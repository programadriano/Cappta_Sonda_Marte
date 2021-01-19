using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonda.Infra
{
    class Helper
    {
        public static void ValidaMovimento(string direcao)
        {

            var validacao = new Regex(@"^(?!\s*$)(?:n|e|s|w|l|r|m|)+$");

            if (!validacao.IsMatch(direcao.ToLower()))
            {
                Console.WriteLine("Os pontos para movimentação só podem ser N, E, S ou W para os cardinais e para direção L e R");
                Environment.Exit(0);
            }
        }


        public static void ValidaCoordenadas(string posicao)
        {

            if (posicao.Length < 5)
            {
                Console.WriteLine("Por favor, preencha os campos corretamente!");
                Environment.Exit(0);
            }
        }
    }
}
