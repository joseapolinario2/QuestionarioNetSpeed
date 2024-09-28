using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesQuestionario
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questao1;
    using System;

    namespace TesteLogicaDescontoVeiculo
    {
        [TestClass]
        public class TestaLogicaDesconto
        {
            private DescontoAte2000 descontoAte2000;
            private DescontoAcima2000 descontoAcima2000;

            [TestInitialize]
            public void Inicializar()
            {
                descontoAte2000 = new DescontoAte2000();
                descontoAcima2000 = new DescontoAcima2000();
                descontoAte2000.SetNextDesconto(descontoAcima2000);
            }

            [TestMethod]
            public void TestarDescontoAte2000()
            {
                // Arrange
                var veiculo = new Veiculo(15000m, 1999);
                var gerenciadorCarros = new GerenciadorCarros();

                // Act
                decimal desconto = descontoAte2000.CalcularDesconto(veiculo);
                gerenciadorCarros.AdicionarCarroComDesconto(veiculo, desconto);

                // Assert
                Assert.AreEqual(1800m, desconto);
            }

            [TestMethod]
            public void TestarDescontoAcima2000()
            {
                var veiculo = new Veiculo(30000m, 2005);
                var gerenciadorCarros = new GerenciadorCarros();

                decimal desconto = descontoAte2000.CalcularDesconto(veiculo);
                gerenciadorCarros.AdicionarCarroComDesconto(veiculo, desconto);

                Assert.AreEqual(2100, desconto); 
            }


            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void TestarValorInvalidoDeEntrada()
            {
                // Act
                decimal valorVeiculo = Convert.ToDecimal("valorInvalido");
            }

            [TestMethod]
            public void TestarAdicionarCarroComDesconto()
            {
                // Arrange
                var veiculo = new Veiculo(20000m, 2002);
                decimal desconto = descontoAte2000.CalcularDesconto(veiculo);

                Assert.AreEqual(1400m, desconto); // 10% de desconto
            }

            [TestMethod]
            public void TestarMostrarCarrosAte2000()
            {
                // Arrange
                var gerenciadorCarros = new GerenciadorCarros();
                var veiculo2000 = new Veiculo(10000m, 2000);
                var veiculo1995 = new Veiculo(12000m, 1995);
                var veiculo2005 = new Veiculo(15000m, 2005);

                decimal desconto2000 = descontoAte2000.CalcularDesconto(veiculo2000);
                decimal desconto1995 = descontoAte2000.CalcularDesconto(veiculo1995);
                decimal desconto2005 = descontoAte2000.CalcularDesconto(veiculo2005);

                gerenciadorCarros.AdicionarCarroComDesconto(veiculo2000, desconto2000);
                gerenciadorCarros.AdicionarCarroComDesconto(veiculo1995, desconto1995);
                gerenciadorCarros.AdicionarCarroComDesconto(veiculo2005, desconto2005);

                // Act
                gerenciadorCarros.MostrarCarrosAte2000();

                // Assert
                // (A implementação real do teste de saída do console dependeria de captura de saída, o que poderia ser feito com redirecionamento de `Console.Out`)
            }
        }
    }

}
