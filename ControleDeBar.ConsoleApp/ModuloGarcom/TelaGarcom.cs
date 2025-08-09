using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesa;

namespace ControleDeBar.ConsoleApp.ModuloGarcom;

public class TelaGarcom : TelaBase<Garcom>, ITela
{
    public TelaGarcom(RepositorioGarcom repositorio) : base("Garçom", repositorio)
    {
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Garçons");

        Console.WriteLine();

        Console.WriteLine("{0, -10} | {1, -30} | {2, -30}","Id", "Nome", "CPF");

       List<Garcom> garcons = repositorio.SelecionarRegistros();

        foreach (Garcom g in garcons)
        {
            Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", g.Id, g.Nome, g.Cpf);
        }

        ApresentarMensagem("Digite ENTER para continuar...", ConsoleColor.DarkYellow);
    }

    protected override Garcom ObterDados()
    {
        string nome = string.Empty; //inicia a string como vazia

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.Write("Digite o nome do garçom: ");
            nome = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(nome))
            {
                ApresentarMensagem("O nome não pode ser vazio ou nulo!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        string cpf = string.Empty; //inicia a string como vazia

        while (string.IsNullOrWhiteSpace(cpf))
        {
            Console.Write("Digite o CPF do garçom: ");
            cpf = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                ApresentarMensagem("O CPF não pode ser vazio ou nulo!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Garcom(nome,cpf);
    }
}
