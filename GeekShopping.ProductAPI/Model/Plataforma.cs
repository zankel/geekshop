using GGstore.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGstore.ProductAPI.Model
{
    [Table("plataforma")]
    public class Plataforma : BaseEntity
    {
        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public ICollection<GamePlataforma> GamePlataformas { get; set; }


    }
}
