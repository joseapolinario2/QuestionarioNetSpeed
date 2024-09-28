using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao4
{
    public class Boleto
    {
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorRecalculado { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Boleto)obj;

            // Comparando todas as propriedades relevantes
            return DataVencimento == other.DataVencimento &&
                   DataPagamento == other.DataPagamento &&
                   Juros == other.Juros &&
                   Multa == other.Multa &&
                   ValorOriginal == other.ValorOriginal &&
                   ValorRecalculado == other.ValorRecalculado;
        }

    }
}
