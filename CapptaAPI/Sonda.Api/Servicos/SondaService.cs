using Sonda.Api.Contratos;
using Sonda.Api.Infra;
using Sonda.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Api.Servicos
{
    public class SondaService : ISondaService
    {
        /// <summary>
        /// Método criado para alinhar a sonda
        /// </summary>
        /// <param name="posicaoAtual">Posição Atual</param>
        /// <param name="direcaoDoMovimento">Direção para alinhamento</param>
        /// <returns></returns>
        private string AlinharPosicao(string posicaoAtual, string direcaoDoMovimento)
        {
            posicaoAtual = posicaoAtual.ToUpper();
            direcaoDoMovimento = direcaoDoMovimento.ToUpper();
            Enum.TryParse(posicaoAtual.Substring(4, 1), out Coordenadas coordenada);

            var direcao = coordenada switch
            {
                Coordenadas.N => direcaoDoMovimento == "R" ? "E" : "W",
                Coordenadas.E => direcaoDoMovimento == "R" ? "S" : "N",
                Coordenadas.S => direcaoDoMovimento == "R" ? "W" : "E",
                Coordenadas.W => direcaoDoMovimento == "R" ? "N" : "S",
            };

            return string.Concat(posicaoAtual.Remove(4, 1), direcao);
        }

        /// <summary>
        /// Método criado para alterar a posição de uma sonda com base nas suas coordenadas atuais
        /// </summary>
        /// <param name="posicaoAtual">Posição Atual</param>
        /// <returns></returns>
        private string AlterarPosicao(string posicaoAtual)
        {
            Enum.TryParse(posicaoAtual.Substring(4, 1), out Coordenadas direcao);

            var x = Convert.ToInt32(posicaoAtual.Substring(0, 1));
            var y = Convert.ToInt32(posicaoAtual.Substring(2, 1));

            switch (direcao)
            {
                case Coordenadas.N:
                    y++;
                    posicaoAtual = posicaoAtual.Substring(0, 2) + Convert.ToString(y) + posicaoAtual[3..];
                    break;
                case Coordenadas.S:
                    y--;
                    posicaoAtual = posicaoAtual.Substring(0, 2) + Convert.ToString(y) + posicaoAtual[3..];
                    break;
                case Coordenadas.E:
                    x++;
                    posicaoAtual = Convert.ToString(x) + posicaoAtual[1..];
                    break;
                case Coordenadas.W:
                    x--;
                    posicaoAtual = Convert.ToString(x) + posicaoAtual[1..];
                    break;
            }
            return posicaoAtual;
        }

        /// <summary>
        /// Metedo buscar para pegar a posição atual de uma sonda
        /// </summary>
        /// <param name="sonda"></param>
        /// <returns></returns>
        private string PosicaoAtual(Models.Sonda sonda)
        {
            var totalDeMovimentos = sonda.Movimentos.Length;

            for (var i = 0; i < totalDeMovimentos; i++)
            {
                var movimento = sonda.Movimentos.Substring(i, 1);

                Helper.ValidaCoordenadas(sonda.Coordenadas);
                Helper.ValidaMovimento(movimento);

                sonda.Coordenadas = movimento != "M" ? AlinharPosicao(sonda.Coordenadas, movimento) : AlterarPosicao(sonda.Coordenadas);

            }

            return sonda.Coordenadas;
        }

        public ICollection<string> Monvimentar(IList<Models.Sonda> sondas)
        {
            var resultado = new List<string>();

            foreach (var item in sondas)
            {
                resultado.Add(PosicaoAtual(item));
            }

            return resultado;



        }
    }
}
