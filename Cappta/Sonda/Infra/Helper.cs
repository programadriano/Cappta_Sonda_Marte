using System;
using System.Collections.Generic;
using System.Text;

namespace Sonda.Infra
{
    class Helper
    {
        public static void ValidaCoordenadas(string posicaoAtual, string direcaoDoMovimento)
        {
            var validaPontos = (posicaoAtual != "N" && posicaoAtual != "E" && posicaoAtual != "S" && posicaoAtual != "W")
              && (direcaoDoMovimento != "L" && direcaoDoMovimento != "R") ? false : true;

            if (!validaPontos)
            {
                Console.WriteLine("Os pontos cardinais só podem ser N, E, S ou W");
                Environment.Exit(0);
            }
        }
    }
}
