
namespace Questao1
{
    public class Veiculo
    {
        private decimal _valor;
        private int _ano;

        public decimal Valor
        {
            get => _valor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O valor do veículo não pode ser negativo.");
                }
                _valor = value;
            }
        }

        public int Ano
        {
            get => _ano;
            private set
            {
                if (value.ToString().Length != 4)
                {
                    throw new ArgumentException("O ano do veículo deve ter 4 dígitos.");
                }

                _ano = value;
            }
        }

        public Veiculo(decimal valor, int ano)
        {
            Valor = valor; // Chama o set para validar o valor
            Ano = ano; // Chama o set para validar o ano
        }
    }

}
