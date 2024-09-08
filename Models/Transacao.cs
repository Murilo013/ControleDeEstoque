
public class Transacao
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public string? NomeProduto { get; set; }
    public string? Tipo { get; set; }
    public int QuantidadeAntes { get; set; }
    public int QuantidadeDepois { get; set; }
    public int QuantidadeTransacao {get; set; }
    public DateTime DataTransacao { get; set; }
}