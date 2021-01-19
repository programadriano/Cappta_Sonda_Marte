using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Api.Contratos
{
    public interface ISondaService
    {
        /// <summary>
        /// Método criado para pegar os movimentos que uma sonda e alterar as suas coordenadas
        /// </summary>
        /// <param name="posicao">Posições</param>
        /// <param name="movimentos">Movimentos</param>
        /// <returns></returns>
        ICollection<string> Monvimentar(IList<Models.Sonda> sondas);
    }
}
