namespace Questao1
{
    public class DescontoAte2000 : Desconto
    {
        public override decimal CalcularDesconto(Veiculo veiculo)
        {
            if (veiculo.Ano <= 2000)
            {
                return veiculo.Valor * 0.12m; // 12% de desconto
            }
            return NextDesconto?.CalcularDesconto(veiculo) ?? 0;
        }
    }
}