using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;
public abstract class TelaBase
{
    protected string nomeEntidade;
    protected RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();
        Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
        Console.WriteLine($"2 - Visualizar {nomeEntidade}");
        Console.WriteLine($"3 - Editar {nomeEntidade}");
        Console.WriteLine($"4 - Excluir {nomeEntidade}");
        Console.WriteLine($"S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;

    }
    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.WriteLine();

        EntidadeBase novoRegistro = ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(erros);
            Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine("\nDigite ENTER para contnuar...");
            Console.ReadLine();

    
            CadastrarRegistro();
            return;
        }

        repositorio.CadastrarRegistro(novoRegistro);

        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso");
        Console.ReadLine();
    }

    public void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine($"Edição de {nomeEntidade}");
        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine($"Digite o id do {nomeEntidade} que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        EntidadeBase registroAtualizado = ObterDados();

        repositorio.EditarRegistro(idSelecionado, registroAtualizado);

        Console.WriteLine($"\n{nomeEntidade} editado com sucesso");
        Console.ReadLine();
    }

    public void ExcluirRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine($"Exclusão de {nomeEntidade}");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.WriteLine($"Digite o id do {nomeEntidade} que deseja selecionar:");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExluir = repositorio.ExcluirRegistro(idSelecionado);

        if (!conseguiuExluir)
        {
            Console.WriteLine($"Não foi possível encontrar o {nomeEntidade} selecionado");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\n{nomeEntidade} excluído com sucesso");
        Console.ReadLine();
    }

    public abstract void VisualizarRegistros(bool exibirCabecalho);
    protected void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine();
    }
    protected abstract EntidadeBase ObterDados();
}

