using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao4
{
    public class CalculoJurosFinalDeSemana : CalculoJurosMultaTemplate
    {
        public CalculoJurosFinalDeSemana(DateTime dataVencimento, DateTime dataPagamento, HashSet<DateTime> feriados)
            : base(dataVencimento, dataPagamento, feriados) { }


        public CalculoJurosFinalDeSemana(Boleto boleto, HashSet<DateTime> feriados) : base(boleto, feriados)
        {

        }
        protected override bool VerificaPagamentoAntecipado()
        {
            return DataPagamento < DataVencimento;
        }

        protected override bool VerificaMesmoDiaUtil()
        {
            return DataVencimento == DataPagamento && IsDiaUtil(DataVencimento);
        }

        protected override bool VerificaDiaUtilConsecutivo()
        {
            return ObterProximoDiaUtil(DataVencimento) == DataPagamento;
        }

        protected override bool VerificaForaDoPrazo()
        {
            DateTime proximoDiaUtil;

            if (IsDiaUtil(DataVencimento) && IsDiaUtil(DataPagamento) && DataPagamento == DataVencimento.AddDays(1))
            {
                return true;
            }

            proximoDiaUtil = ObterProximoDiaUtil(DataVencimento);

            return DataPagamento > proximoDiaUtil;
        }

        protected override Boleto CalcularJuros()
        {
            TimeSpan diferendaDias = (DataPagamento - DataVencimento);
            decimal diasAposVencimento = ((decimal)diferendaDias.TotalDays);

            if (!IsDiaUtil(DataVencimento) && DataPagamento != ObterProximoDiaUtil(DataVencimento))
            {
                diasAposVencimento += 1;
            }


            if (VerificaFeriado(DataVencimento) && DataPagamento > DataVencimento.AddDays(2))
            {
                diasAposVencimento = ((decimal)diferendaDias.TotalDays);
            }

            this.Boleto.Juros = (diasAposVencimento * 0.03m);


            this.Boleto.Multa = 2;
            this.Boleto.ValorRecalculado = this.Boleto.ValorOriginal + Boleto.Multa + Boleto.Juros;

            return this.Boleto;
        }

        private bool IsDiaUtil(DateTime data)
        {
            return VerificaFinalDeSemana(data) && !VerificaFeriado(data);
        }

        private bool VerificaFinalDeSemana(DateTime data)
        {
            return data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday;
        }

        private bool VerificaFeriado(DateTime data)
        {
            return Feriados.Contains(data);
        }

        private DateTime ObterProximoDiaUtil(DateTime data)
        {
            DateTime proximoDia = data.AddDays(1);
            while (!IsDiaUtil(proximoDia))
            {
                proximoDia = proximoDia.AddDays(1);
            }

            return proximoDia;
        }
        protected override Boleto CalcularJurosZero()
        {
            this.Boleto.ValorRecalculado = this.Boleto.ValorOriginal;
            return this.Boleto;
        }
    }

}
