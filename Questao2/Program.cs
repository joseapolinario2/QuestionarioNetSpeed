using Questao2;

var calculadoraMedia = new CalculadoraMediaPonderada();
List<Aluno> alunos = new List<Aluno>();
int codigoAluno;

do
{
    Console.WriteLine("Digite o código do aluno ou 0 para encerrar:");
    codigoAluno = Convert.ToInt32(Console.ReadLine());

    if (codigoAluno == 0)
    {
        break;
    }

    Console.WriteLine("Digite as três notas do aluno:");
    List<decimal> notas = new List<decimal>();

    for (int i = 1; i <= 3; i++)
    {
        Console.Write($"Nota {i}: ");
        notas.Add(Convert.ToDecimal(Console.ReadLine()));
    }

    var aluno = new Aluno(codigoAluno, notas, calculadoraMedia);
    alunos.Add(aluno);

} while (codigoAluno != 0);

foreach (var aluno in alunos)
{
    aluno.ExibirResultado();
}

Console.ReadKey();
        