using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GGstore.ProductAPI.Data.ValueObjects
{
    public class GameVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public List<GeneroVO> Generos { get; set; }
        public List<PlataformaVO> Plataformas { get; set; }
    }
}
