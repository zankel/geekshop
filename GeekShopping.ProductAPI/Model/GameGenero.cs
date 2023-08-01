using GGstore.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGstore.ProductAPI.Model
{
    [Table("gamegenero")]
    public class GameGenero 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("game_id")]
        public int GameId { get; set; }
        public Game Game { get; set; }


        [Column("genero_id")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
