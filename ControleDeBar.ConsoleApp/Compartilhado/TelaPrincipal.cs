using ClubeDaLeitura.ConsoleApp.ModuloDeAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloDeCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloDeEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloDeRevistas;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioCaixa repositorioCaixa;
    private RepositorioRevista repositorioRevista;
    private RepositorioEmprestimo repositorioEmprestimo;

    private TelaAmigo telaAmigo;
    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;
    private TelaEmprestimo telaEmprestimo;
    public TelaPrincipal()
    {
        repositorioAmigo = new RepositorioAmigo();
        telaAmigo = new TelaAmigo(repositorioAmigo);

        repositorioCaixa = new RepositorioCaixa();
        telaCaixa = new TelaCaixa(repositorioCaixa);

        repositorioRevista = new RepositorioRevista();
        telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);

        repositorioEmprestimo = new RepositorioEmprestimo();
        telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);
    }
    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|           Clube da Leitura           |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Amigos");
        Console.WriteLine("2 - Controle de Caixas");
        Console.WriteLine("3 - Controle de Revistas");
        Console.WriteLine("4 - Controle de Empréstimos");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()[0];

    }

    public TelaBase ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaAmigo;

        else if (opcaoEscolhida == '2')
            return telaCaixa;

        else if (opcaoEscolhida == '3')
            return telaRevista;

        else if (opcaoEscolhida == '4')
            return telaEmprestimo;

        return null;
    }
}
