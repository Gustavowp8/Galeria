using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Galeria.Models
{
    public class GaleriaImg
    {
        [Key]
        [Display(Name = "Codigo")]
        public int IdGaleriaImg { get; set; }

        [Required]
        [Display(Name = "Titulo galeria")]
        public string Titulo { get; set; }

        public ICollection<Imagem> Imagens { get; set; }
    }
}