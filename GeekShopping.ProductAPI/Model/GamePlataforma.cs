using GGstore.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGstore.ProductAPI.Model
{
    [Table("gameplataforma")]
    public class GamePlataforma 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("game_id")]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Column("plataforma_id")]
        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }

    }
}
