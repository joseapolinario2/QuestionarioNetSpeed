using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1
{
    public class DescontoAcima2000 : Desconto
    {
        public override decimal CalcularDesconto(Veiculo veiculo)
        {
            if (veiculo.Ano > 2000)
            {
                return veiculo.Valor * 0.07m; // 7% de desconto
            }
            return NextDesconto?.CalcularDesconto(veiculo) ?? 0;
        }
    }
}
