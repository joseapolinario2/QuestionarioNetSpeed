using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao4
{
    public abstract class CalculoJurosMultaTemplate
    {
        protected DateTime DataVencimento;
        protected DateTime DataPagamento;
        protected HashSet<DateTime> Feriados;
        protected Boleto Boleto;

        public CalculoJurosMultaTemplate(Boleto boleto, HashSet<DateTime> feriados)
        {
            this.Boleto = boleto; ;
            DataVencimento = boleto.DataVencimento;
            DataPagamento = boleto.DataPagamento;
            Feriados = feriados;
        }

        public CalculoJurosMultaTemplate(DateTime dataVencimento, DateTime dataPagamento, HashSet<DateTime> feriados)
        {
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            Feriados = feriados;
        }

        public Boleto Calcular()
        {
            if (VerificaPagamentoAntecipado())
            {

                return this.CalcularJurosZero();
            }
            else if (VerificaMesmoDiaUtil())
            {
                return this.CalcularJurosZero();
            }
            else if (VerificaDiaUtilConsecutivo())
            {
                if (VerificaForaDoPrazo())
                {
                    return this.CalcularJuros();
                }
                else
                {
                    return this.CalcularJurosZero();
                }
            }
            else
            {
                return this.CalcularJuros();
            }

            return this.Boleto;
        }

        protected abstract bool VerificaPagamentoAntecipado();
        protected abstract bool VerificaMesmoDiaUtil();
        protected abstract bool VerificaDiaUtilConsecutivo();
        protected abstract bool VerificaForaDoPrazo();
        protected abstract Boleto CalcularJuros();
        protected abstract Boleto CalcularJurosZero();
    }

}
