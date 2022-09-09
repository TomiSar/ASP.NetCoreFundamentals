namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Country { get; set; }
		public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
		public string RatingStars { get; set; }
	}
}
