using GGstore.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGstore.ProductAPI.Model
{
    [Table("game")]
    public class Game :BaseEntity
    {

        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Column("descricao")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageURL { get; set; }

        // Relacionamento com os gêneros (muitos para muitos)
        public ICollection<Genero> Generos { get; set; }

        public ICollection<GameGenero> GameGeneros { get; set; }


        // Chave estrangeira para a tabela GamePlataforma
        public ICollection<Plataforma> Plataformas { get; set; }
        public ICollection<GamePlataforma> GamePlataformas { get; set; }

    }
}
