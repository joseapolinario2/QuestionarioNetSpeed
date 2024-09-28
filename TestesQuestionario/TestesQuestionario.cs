namespace TestesQuestionario
{
    using Questao4;
    [TestClass]
    public class TestesQuestionario
    {
        HashSet<DateTime> feriados = new HashSet<DateTime>
            {
                new DateTime(2023, 1, 1),   // Confraternização Universal (Ano Novo)
                new DateTime(2023, 2, 20),  // Carnaval (ponto facultativo) - Segunda-feira
                new DateTime(2023, 2, 21),  // Carnaval (ponto facultativo) - Terça-feira
                new DateTime(2023, 4, 7),   // Sexta-feira Santa (Paixão de Cristo)
                new DateTime(2023, 4, 21),  // Tiradentes
                new DateTime(2023, 5, 1),   // Dia do Trabalho
                new DateTime(2023, 6, 8),   // Corpus Christi (ponto facultativo)
                new DateTime(2023, 9, 7),   // Independência do Brasil
                new DateTime(2023, 10, 12), // Nossa Senhora Aparecida (Padroeira do Brasil)
                new DateTime(2023, 11, 2),  // Finados
                new DateTime(2023, 11, 15), // Proclamação da República
                new DateTime(2023, 12, 25)  // Natal
            };
        [TestMethod]
        public void TestaVencimentoFinalDeSemana()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataPagamento = new DateTime(2023, 05, 06),
                DataVencimento = new DateTime(2023, 05, 08),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataPagamento = new DateTime(2023, 05, 06),
                DataVencimento = new DateTime(2023, 05, 08),
                ValorOriginal = 100m,
                ValorRecalculado = 100m
            };

            Assert.AreEqual(testBoleto, resultCalculo);

        }

        [TestMethod]
        public void TestaPagamentoAposVencFinalSemanaFeriado()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 07),
                DataPagamento = new DateTime(2023, 05, 09),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 07),
                DataPagamento = new DateTime(2023, 05, 09),
                ValorOriginal = 100m,
                Juros = 0.09m,
                Multa = 2m,
                ValorRecalculado = 102.09m
            };

            Assert.AreEqual(testBoleto, resultCalculo);

        }

        [TestMethod]
        public void TestVencimentoFeriado()
        {


            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 01),
                DataPagamento = new DateTime(2023, 05, 02),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 01),
                DataPagamento = new DateTime(2023, 05, 02),
                ValorOriginal = 100m,
                Juros = 0,
                Multa = 0,
                ValorRecalculado = 100m
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }

        [TestMethod]
        public void TestaVencFinalSemanaAntFeriado()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 04, 21),
                DataPagamento = new DateTime(2023, 04, 24),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 04, 21),
                DataPagamento = new DateTime(2023, 04, 24),
                ValorOriginal = 100m,
                Juros = 0,
                Multa = 0,
                ValorRecalculado = 100m
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }

        [TestMethod]
        public void TestaVencFeriadoApos2Dias()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 04, 07),
                DataPagamento = new DateTime(2023, 04, 11),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 04, 07),
                DataPagamento = new DateTime(2023, 04, 11),
                ValorOriginal = 100m,
                Juros = 0.12m,
                Multa = 2m,
                ValorRecalculado = 102.12m
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }
        [TestMethod]
        public void PagamentoMesmoDiaUtil()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 10),
                DataPagamento = new DateTime(2023, 05, 10),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 10),
                DataPagamento = new DateTime(2023, 05, 10),
                ValorOriginal = 100m,
                Juros = 0,
                Multa = 0,
                ValorRecalculado = 100M
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }

        [TestMethod]
        public void PagamentoAntesVencimento()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 11),
                DataPagamento = new DateTime(2023, 05, 10),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();
            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 11),
                DataPagamento = new DateTime(2023, 05, 10),
                ValorOriginal = 100m,
                Juros = 0,
                Multa = 0,
                ValorRecalculado = 100M
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }

        [TestMethod]
        public void PagamentoDiaUtilConsecutivo()
        {
            CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 08),
                DataPagamento = new DateTime(2023, 05, 09),
                ValorOriginal = 100m
            }, feriados);

            var resultCalculo = calculo.Calcular();

            var testBoleto = new Boleto
            {
                DataVencimento = new DateTime(2023, 05, 08),
                DataPagamento = new DateTime(2023, 05, 09),
                ValorOriginal = 100m,
                Juros = 0.03m,
                Multa = 2,
                ValorRecalculado = 102.03m
            };

            Assert.AreEqual(testBoleto, resultCalculo);
        }
    }
}