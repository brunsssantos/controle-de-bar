using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.Compartilhado;

public abstract class RepositorioBaseEmArquivo<Tipo> where Tipo : EntidadeBase<Tipo>
{
    protected ContextoDados contextoDados;
    protected List<Tipo> registros = new List<Tipo>(); // Lista para armazenar os registros em memória
    protected int contadorIds = 0;

    protected RepositorioBaseEmArquivo(ContextoDados contextoDados)
    {
        this.contextoDados = contextoDados; // Inicializa o contexto de dados

        registros = ObterRegistros(); // Obtém os registros do contexto de dados
    }

    protected abstract List<Tipo> ObterRegistros(); // Método abstrato para obter os registros do contexto de dados
    public void CadastrarRegistro(Tipo novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);

        contextoDados.Salvar(); // Salva os dados no arquivo após adicionar um novo registro
    }

    public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
    {

        Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.AtualizarRegistro(registroAtualizado);

        contextoDados.Salvar();

        return true;
    }
    public bool ExcluirRegistro(int idSelecionado)
    {
        foreach (Tipo registro in registros)
        {
            if (registro.Id == idSelecionado)
            {
                registros.Remove(registro);

                contextoDados.Salvar();

                return true;
            }
        }

        return false;
    }

    public List<Tipo> SelecionarRegistros()
    {
        return registros;
    }
    public Tipo SelecionarRegistroPorId(int idSelecionado)
    {
        foreach (Tipo registro in registros)
        {

            if (registro.Id == idSelecionado)
                return registro;
        }

        return null;
    }

}

