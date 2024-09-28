
namespace Questao2
{
    public class CalculadoraMediaPonderada : ICalculadoraMedia
    {
        public decimal CalcularMedia(List<decimal> notas)
        {
            if (notas.Count != 3)
            {
                throw new ArgumentException("Para realizar o cálculo da média, é necessário informar as 3 notas do aluno!");
            }

            var notasOrdenadas = notas.OrderByDescending(n => n).ToList();
            decimal maiorNota = notasOrdenadas[0] * 4;
            decimal segundaNota = notasOrdenadas[1] * 3;
            decimal terceiraNota = notasOrdenadas[2] * 3;

            return (maiorNota + segundaNota + terceiraNota) / 10;
        }
    }

}
