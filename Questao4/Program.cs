namespace Questao4
{
    public class Program
    {
        static void Main()
        {
            // Exemplo de feriados
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


            List<Boleto> boletos = new List<Boleto>
        {
            new Boleto { DataVencimento = new DateTime(2023, 5, 6), DataPagamento = new DateTime(2023, 5, 6), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 5, 7), DataPagamento = new DateTime(2023, 5, 9), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 5, 1), DataPagamento = new DateTime(2023, 5, 2), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 4, 21), DataPagamento = new DateTime(2023, 4, 24), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 4, 7), DataPagamento = new DateTime(2023, 4, 11), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 5, 10), DataPagamento = new DateTime(2023, 5, 10), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 5, 11), DataPagamento = new DateTime(2023, 5, 10), ValorOriginal = 100m },
            new Boleto { DataVencimento = new DateTime(2023, 5, 8), DataPagamento = new DateTime(2023, 5, 9), ValorOriginal = 100m }
        };

            // Processando os cálculos
            foreach (var boleto in boletos)
            {
                CalculoJurosMultaTemplate calculo = new CalculoJurosFinalDeSemana(boleto, feriados);
                var resultado = calculo.Calcular();
                ImprimirBoleto(resultado);
            }
            Console.ReadKey();
        }
        static void ImprimirBoleto(Boleto boleto)
        {
            Console.WriteLine("===== Resultado do Boleto =====");
            Console.WriteLine($"Data de Vencimento: {boleto.DataVencimento.ToShortDateString()}");
            Console.WriteLine($"Data de Pagamento: {boleto.DataPagamento.ToShortDateString()}");
            Console.WriteLine($"Valor Original: {boleto.ValorOriginal:C}");
            Console.WriteLine($"Juros: {boleto.Juros:C}");
            Console.WriteLine($"Multa: {boleto.Multa:C}");
            Console.WriteLine($"Valor Recalculado: {boleto.ValorRecalculado:C}");
            Console.WriteLine("===============================\n");

            
        }
    }
}