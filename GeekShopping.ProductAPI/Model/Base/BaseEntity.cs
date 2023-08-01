using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGstore.ProductAPI.Model.Base
{
    public class BaseEntity
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
