using NUnit.Framework;
using Sonda.Servicos;

namespace Sonda.Testes
{
    public class Tests
    {
        [Test]
        public void ValidarAMovimentacaoEAlinhamentoDeDuasSondas()
        {
            //Arrange
            var posicaoSonda1 = "1 2 N"; 
            var movimentoSonda1 = "LMLMLMLMM"; 
            var posicaoSonda2 = "3 3 E";
            var movimentoSonda2 = "MMRMMRMRRM";

            //Act
            var primeiraSonda = SondaServicos.Monvimentar(posicaoSonda1, movimentoSonda1);
            var segundaSonda = SondaServicos.Monvimentar(posicaoSonda2, movimentoSonda2);

            //Assert
            Assert.AreEqual("1 3 N", primeiraSonda);
            Assert.AreEqual("5 1 E", segundaSonda);
        }
    }
}