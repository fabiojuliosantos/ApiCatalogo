namespace ApiCatalogo.Models;

public class CategoriaModel
{
    public int CategoriaId { get; set; } //=> Por convencao o EFCore reconhece como chave primaria
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
}
