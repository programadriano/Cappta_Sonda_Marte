using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sonda.Api.Infra
{
    class Helper
    {
        /// <summary>
        /// Método desenvolvido para validar a direção enviada pelo usuário
        /// </summary>
        /// <param name="direcao"></param>
        public static void ValidaMovimento(string direcao)
        {

            var validacao = new Regex(@"^(?!\s*$)(?:n|e|s|w|l|r|m|)+$");

            if (!validacao.IsMatch(direcao.ToLower()))
            {
                throw new Exception("Os pontos para movimentação só podem ser N, E, S ou W para os cardinais e para direção L e R");
            }
        }

        /// <summary>
        /// Método desenvolvido para validar as coordenadas enviadas pelo usuário
        /// </summary>
        /// <param name="posicao"></param>
        public static void ValidaCoordenadas(string posicao)
        {

            if (posicao.Length < 5)
            {
                throw new Exception("Por favor, preencha os campos corretamente!");
            }


        }
    }
}
