using Questao1;

decimal valorVeiculo;
int anoVeiculo;

var descontoAte2000 = new DescontoAte2000();
var descontoAcima2000 = new DescontoAcima2000();
descontoAte2000.SetNextDesconto(descontoAcima2000);

var gerenciadorCarros = new GerenciadorCarros();

string continuar = "S";

do
{
    try
    {
        Console.WriteLine("Digite o valor do veículo:");
        valorVeiculo = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite o ano do veículo:");
        anoVeiculo = Convert.ToInt32(Console.ReadLine());

        // Cria o objeto Veiculo, a validação é feita aqui
        var veiculo = new Veiculo(valorVeiculo, anoVeiculo);

        decimal desconto = descontoAte2000.CalcularDesconto(veiculo);

        gerenciadorCarros.AdicionarCarroComDesconto(veiculo, desconto);

        Console.WriteLine($"Desconto: {desconto}");

        Console.WriteLine("Deseja continuar a calcular descontos? (S/N)");
        continuar = Console.ReadLine().ToUpper();
    }
    catch (FormatException ex)
    {
        Console.WriteLine("Valores de entrada inválidos");
    }
    catch (ArithmeticException ex)
    {
        Console.WriteLine("Ocorreu um erro aritmético: " + ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }catch(Exception ex)
    {
        Console.WriteLine("Ocorreu um erro durante a realização do cálculo!");
    }

} while (continuar != "N");


gerenciadorCarros.MostrarCarrosAte2000();

Console.ReadKey();