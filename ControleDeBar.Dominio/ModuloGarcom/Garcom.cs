using ControleDeBar.Dominio.Compartilhado;
using System.Text.RegularExpressions;

namespace ControleDeBar.Dominio.ModuloGarcom;

public class Garcom : EntidadeBase<Garcom> //Generic
{
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public Garcom(string nome, string cpf) //argumentos
    {
        Nome = nome;
        Cpf = cpf;  
    }

    public override void AtualizarRegistro(Garcom registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Cpf = registroAtualizado.Cpf;
    }

    public override string Validar()
    {
        string erros = string.Empty;

        if (Nome.Length < 3 || Nome.Length > 100)
            erros += "O campo \"Nome\" deve conter entre 3 e 100 caracteres";

        if (Regex.IsMatch(Cpf, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$") == false)
            erros += "O campo \"CPF\" deve estar no formato 000.000.000-00";

        return erros;
    }
}
