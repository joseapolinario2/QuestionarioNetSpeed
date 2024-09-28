using Questao2;
namespace TestesQuestionario
{
    [TestClass]
    public class TestaCalculoMediaAluno
    {
        private ICalculadoraMedia calculadoraMedia;

        [TestInitialize]
        public void Inicializar()
        {
            calculadoraMedia = new CalculadoraMediaPonderada();
        }

        [TestMethod]
        public void TestarMediaPonderada_AlunoAprovado()
        {
            // Arrange
            List<decimal> notas = new List<decimal> { 8m, 9m, 7m };
            var aluno = new Aluno(1, notas, calculadoraMedia);

            // Act
            aluno.CalcularMediaAluno();

            // Assert
            Assert.AreEqual(8.1m, aluno.Media);
            Assert.AreEqual("APROVADO", aluno.Status);
        }

        [TestMethod]
        public void TestarMediaPonderada_AlunoReprovado()
        {
            // Arrange
            List<decimal> notas = new List<decimal> { 5m, 4m, 6m };
            var aluno = new Aluno(2, notas, calculadoraMedia);

            // Act
            aluno.CalcularMediaAluno();

            // Assert
            Assert.AreEqual(5.1m, aluno.Media);
            Assert.AreEqual("REPROVADO", aluno.Status);
        }

        [TestMethod]
        public void TestarMediaPonderada_ComNotasInvalidas()
        {
            // Arrange
            List<decimal> notasInvalidas = new List<decimal> { 8m, 9m }; // Menos de 3 notas

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => calculadoraMedia.CalcularMedia(notasInvalidas),
                "Para realizar o cálculo da média, é necessário informar as 3 notas do aluno!");
        }

        [TestMethod]
        public void TestarMediaPonderada_ComNotasExtremas()
        {
            // Arrange
            List<decimal> notas = new List<decimal> { 10m, 10m, 10m };
            var aluno = new Aluno(3, notas, calculadoraMedia);

            // Act
            aluno.CalcularMediaAluno();

            // Assert
            Assert.AreEqual(10m, aluno.Media);
            Assert.AreEqual("APROVADO", aluno.Status);
        }

        [TestMethod]
        public void TestarMediaPonderada_ComNotasBaixas()
        {
            // Arrange
            List<decimal> notas = new List<decimal> { 9m, 3m, 1m };
            var aluno = new Aluno(4, notas, calculadoraMedia);

            // Act
            aluno.CalcularMediaAluno();

            // Assert
            Assert.AreEqual(4.80m, aluno.Media);
            Assert.AreEqual("REPROVADO", aluno.Status);
        }

        [TestMethod]
        public void TestarOrdemNotasNaoAfetaResultado()
        {
            // Arrange
            List<decimal> notas1 = new List<decimal> { 6m, 8m, 7m };
            List<decimal> notas2 = new List<decimal> { 8m, 7m, 6m };

            var aluno1 = new Aluno(5, notas1, calculadoraMedia);
            var aluno2 = new Aluno(6, notas2, calculadoraMedia);

            // Act
            aluno1.CalcularMediaAluno();
            aluno2.CalcularMediaAluno();

            // Assert
            Assert.AreEqual(aluno1.Media, aluno2.Media);
            Assert.AreEqual(aluno1.Status, aluno2.Status);
        }

        
    }
}
