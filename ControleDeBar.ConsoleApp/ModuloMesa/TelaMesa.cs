using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Memoria.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloMesa;

internal class TelaMesa : TelaBase<Mesa>, ITela
{

    public TelaMesa(RepositorioMesa repositorioMesa) : base("Mesa", repositorioMesa)
    {
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Mesas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}",
            "Id", "Número", "Capacidade", "Status"
        );

        List<Mesa> mesas = repositorio.SelecionarRegistros();

        foreach (Mesa mesa in mesas)
        {
            string statusMesa = mesa.EstaOcupada ? "Ocupada" : "Disponível";
            Console.WriteLine(
              "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                mesa.Id, mesa.Numero, mesa.Capacidade, statusMesa
            );
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    protected override Mesa ObterDados()
    {
        bool conseguiuConverterNumero = false;

        int numero = 0;

        while (!conseguiuConverterNumero)
        {
            Console.Write("Digite o número da mesa: ");
            conseguiuConverterNumero = int.TryParse(Console.ReadLine(), out numero);

            if (!conseguiuConverterNumero)
            {
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        bool conseguiuConverterCapacidade = false;

        int capacidade = 0;

        while (!conseguiuConverterCapacidade)
        {
            Console.Write("Digite a capacidade da mesa: ");
            conseguiuConverterCapacidade = int.TryParse(Console.ReadLine(), out capacidade);

            if (!conseguiuConverterNumero)
            {
                ApresentarMensagem("Digite um número válido!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Mesa(numero, capacidade);
    }

}

