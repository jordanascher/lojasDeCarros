using System.ComponentModel.DataAnnotations;

namespace LojaDeCarros.Models
{
    public class Carro
    {
        public int Id { get; set; }
        
        [Required]
        public string Modelo { get; set; }
        
        [Required]
        [Range(1950, 2024, ErrorMessage = "O ano de fabricação deve estar entre 1900 e 2024.")]
        public int AnoFabricacao { get; set; }

        [Required]
        public string Chassi { get; set; }

        [Required]
        [Range(typeof(decimal), "1,00", "79999999,99", ErrorMessage = "O preço deve ser maior que 0.1.")]
        public decimal Preco { get; set; }
    }
}
