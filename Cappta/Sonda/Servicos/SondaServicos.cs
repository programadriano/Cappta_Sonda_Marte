using Sonda.Infra;
using Sonda.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sonda.Servicos
{
    public class SondaServicos
    {

        /// <summary>
        /// Método criado para pegar os movimentos que uma sonda e alterar as suas coordenadas
        /// </summary>
        /// <param name="posicao">Posições</param>
        /// <param name="movimentos">Movimentos</param>
        /// <returns></returns>
        public static string Monvimentar(string posicao, string movimentos)
        {
            var totalDeMovimentos = movimentos.Length;

            for (var i = 0; i < totalDeMovimentos; i++)
            {             
                var movimento = movimentos.Substring(i, 1);

                Helper.ValidaCoordenadas(posicao);
                Helper.ValidaMovimento(movimento);

                posicao = movimento != "M" ? AlinharPosicao(posicao, movimento) : AlterarPosicao(posicao);

            }
            return posicao;

        }

        /// <summary>
        /// Método criado para alinhar a sonda
        /// </summary>
        /// <param name="posicaoAtual">Posição Atual</param>
        /// <param name="direcaoDoMovimento">Direção para alinhamento</param>
        /// <returns></returns>
        private static string AlinharPosicao(string posicaoAtual, string direcaoDoMovimento)
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
        private static string AlterarPosicao(string posicaoAtual)
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
    }


}
