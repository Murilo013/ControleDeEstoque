using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoque.ViewModels
{
    
    public class CreateProdutoViewModel
    {
        [Required(ErrorMessage = "O campo ID é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório!")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório!")]
        public double Valor { get; set; }
    }
}