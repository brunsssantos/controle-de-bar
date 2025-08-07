namespace ControleDeBar.ConsoleApp.Compartilhado;

public interface ITela
{
    void CadastrarRegistro();
    void EditarRegistro();
    void ExcluirRegistro();
    void VisualizarRegistros(bool mostrarCabecalho);
    char ApresentarMenu();
}
