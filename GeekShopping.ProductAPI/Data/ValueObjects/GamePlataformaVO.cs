using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GGstore.ProductAPI.Data.ValueObjects
{
    public class GamePlataformaVO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlataformaId { get; set; }
    }
}
