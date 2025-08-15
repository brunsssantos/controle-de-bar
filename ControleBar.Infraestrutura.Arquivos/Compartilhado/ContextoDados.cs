using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ControleDeBar.Infraestrutura.Arquivos.Compartilhado;

public class ContextoDados
{
    public List<Mesa> Mesas { get; set; } = new List<Mesa>();
    public List<Garcom> Garcons { get; set; } = new List<Garcom>();
    public List<Conta> Contas { get; set; } = new List<Conta>();
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    private string pastaArmazenamento = "C:\\temp"; // Define o caminho onde os dados serão salvos
    private string arquivoArmazenmento = "dados-controle-bar.json"; // Define o nome do arquivo onde os dados serão salvos

    public ContextoDados() { }

    public ContextoDados(bool carregarDados)
    {
        if(carregarDados)
            Carregar(); // Se o parâmetro for verdadeiro, carrega os dados do arquivo ao criar a instância
    }

    public void Salvar()
    {
        // Implementa a lógica de salvar dados em arquivo
        // Serializando objetos para JSON e gravando em um arquivo

        //C:\temp\dados-controle-bar.json
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenmento); // Combina o caminho da pasta com o nome do arquivo

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions(); // Permite que seja configurado o formato de serialização - customização do JSON
        jsonOptions.WriteIndented = true; // Formatando o JSON para ser mais legível (com indentação)
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve; // Preserva referências entre as classes

        var jsonString = JsonSerializer.Serialize(this, jsonOptions);

        if(!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento); // Cria a pasta se não existir

        File.WriteAllText(caminhoCompleto, jsonString); // Escreve o JSON no arquivo especificado

    }

    public void Carregar()
    {
        // Implementa a lógica de carregar dados de arquivo
        // Lendo o arquivo e desserializando os objetos
        
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenmento); // Combina o caminho da pasta com o nome do arquivo

        if (File.Exists(caminhoCompleto)) return; // Verifica se o arquivo existe, se não existir, não faz nada

        string jsonString = File.ReadAllText(caminhoCompleto); // Lê o conteúdo do arquivo JSON

        if (string.IsNullOrWhiteSpace(jsonString)) return; // Verifica se o conteúdo do arquivo é vazio ou nulo, se for, não faz nada

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados? contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(jsonString, jsonOptions); // Desserializa o JSON para um objeto do tipo ContextoDados

        if (contextoArmazenado == null) return;

        Mesas = contextoArmazenado.Mesas; // Se o objeto desserializado não for nulo, atribui a lista de mesas do contexto armazenado à lista de mesas atual
        Garcons = contextoArmazenado.Garcons; 
        Contas = contextoArmazenado.Contas;     
        Produtos = contextoArmazenado.Produtos;     
    }
}
