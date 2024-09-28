
namespace Questao2
{
    public class Aluno
    {
        public int Codigo { get; }
        public List<decimal> Notas { get; }
        private ICalculadoraMedia _calculadoraMedia;
        public decimal Media { get; private set; }
        public string Status { get; private set; }

        public Aluno(int codigo, List<decimal> notas, ICalculadoraMedia calculadoraMedia)
        {
            Codigo = codigo;
            Notas = notas;
            _calculadoraMedia = calculadoraMedia;
        }


        public void CalcularMediaAluno()
        {
            this.Media = _calculadoraMedia.CalcularMedia(Notas);
            this.AtualizaStatus();
        }

        public void AtualizaStatus()
        {
            this.Status = (this.Media >= 6 ? "APROVADO" : "REPROVADO");
        }

        public void ExibirResultado()
        {
            this.CalcularMediaAluno();
            Console.WriteLine($"Aluno {Codigo}:");
            Console.WriteLine($"Notas: {string.Join(", ", Notas)}");
            Console.WriteLine($"Média: {this.Media:F2} - {this.Status}");
            Console.WriteLine();
        }
    }
}
