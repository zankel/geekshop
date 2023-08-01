namespace GGstore.Web.Models
{
    public class GameModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public ICollection<GeneroModel> Generos { get; set; }
        public ICollection<PlataformaModel> Plataformas { get; set; }

    }
}
