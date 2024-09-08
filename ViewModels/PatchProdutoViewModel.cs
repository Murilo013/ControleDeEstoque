using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.ViewModels
{
    
    public class PatchProdutoViewModel
    {
        [Required(ErrorMessage = "O campo Quantidade é obrigatório!")]
        public int IdProduto { get; set; }
        
        [Required(ErrorMessage = "O campo Quantidade é obrigatório!")]
        [Range(1, int.MaxValue,ErrorMessage = "A quantidade deve ser maior que 0")]
        public int Quantidade { get; set; }
    }
}