using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Galeria.Models
{
    public class Imagem
    {
        [Key]
        public int IdImagem { get; set; }

        [Required]
        [Display(Name ="Titulo")]
        public string Titulo { get; set; }

        public int IdGaleria { get; set; }

        [ForeignKey("IdGaleria")]
        public GaleriaImg GaleriaImg { get; set; }

        [Required(ErrorMessage = "Erro!")]
        [NotMapped]
        [Display(Name ="Arquivo")]
        public IFormFile ArquivoImagem { get; set; }

        [NotMapped]
        public string CaminhoImagem
        {
            get
            {
                var caminhoArquivoImagem = Path.Combine($"\\img\\", IdImagem.ToString("D6" + ".webp"));
                return caminhoArquivoImagem;
            }
        }
    }
}
