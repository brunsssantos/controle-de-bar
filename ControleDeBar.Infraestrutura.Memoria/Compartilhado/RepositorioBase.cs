using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Infraestrutura.Memoria.Compartilhado;

public abstract class RepositorioBase<Tipo> where Tipo : EntidadeBase<Tipo>
{
    protected List<Tipo> registros = new List<Tipo>();
    protected int contadorIds = 0;

    public void CadastrarRegistro(Tipo novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        registros.Add(novoRegistro);
    }

    public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
    {

        Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.AtualizarRegistro(registroAtualizado);

        return true;
    }
    public bool ExcluirRegistro(int idSelecionado)
    {
        foreach (Tipo registro in registros)
        {
            if (registro.Id == idSelecionado)
            {
                registros.Remove(registro);
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

