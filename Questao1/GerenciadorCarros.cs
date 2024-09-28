using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1
{
    public class GerenciadorCarros
    {
        private List<(Veiculo veiculo, decimal desconto)> _carrosComDesconto = new List<(Veiculo, decimal)>();

        public void AdicionarCarroComDesconto(Veiculo veiculo, decimal desconto)
        {
            _carrosComDesconto.Add((veiculo, desconto));
        }

        public void MostrarCarrosAte2000()
        {
            var carrosAte2000 = _carrosComDesconto
                .Where(cd => cd.veiculo.Ano <= 2000)
                .ToList();

            if (!carrosAte2000.Any())
            {
                Console.WriteLine("Nenhum carro encontrado até o ano 2000.");
                return;
            }

            decimal totalDesconto = 0;

            Console.WriteLine("Carros até o ano 2000 com desconto:");
            foreach (var (veiculo, desconto) in carrosAte2000)
            {
                Console.WriteLine($"Ano: {veiculo.Ano}, Valor: {veiculo.Valor}, Desconto: {desconto}");
                totalDesconto += desconto;
            }

            Console.WriteLine($"Total de descontos: {totalDesconto}");
        }
    }

}
