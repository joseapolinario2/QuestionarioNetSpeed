using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1
{
    public abstract class Desconto
    {
        protected Desconto NextDesconto;

        public void SetNextDesconto(Desconto nextDesconto)
        {
            NextDesconto = nextDesconto;
        }

        public abstract decimal CalcularDesconto(Veiculo veiculo);
    }

}
