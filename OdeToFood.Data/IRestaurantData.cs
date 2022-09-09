using System.Linq;
using OdeToFood.Core;
using System.Collections.Generic;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Country="USA", Location="Maryland", Cuisine=CuisineType.Italian, RatingStars="⭐⭐⭐⭐⭐" },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Country="Great Britain", Location="London", Cuisine=CuisineType.Italian, RatingStars="⭐⭐" },
                new Restaurant { Id = 3, Name = "La Costa", Country="USA", Location = "California", Cuisine=CuisineType.Mexican, RatingStars="⭐⭐⭐"},
                new Restaurant { Id = 4, Name = "Weeruska", Country="Finland", Location = "Helsinki", Cuisine=CuisineType.Finnish, RatingStars="⭐⭐⭐⭐" },
                new Restaurant { Id = 5, Name = "Wong Yong Hong", Country="China", Location = "Peking", Cuisine=CuisineType.Chinese, RatingStars="⭐⭐⭐⭐⭐" },
            };
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(restaurant => restaurant.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from restaurant in restaurants where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name) orderby restaurant.Name select restaurant;

        }

        //public IEnumerable<Restaurant> GetAll()
        //{
        //    return from restaurant in restaurants orderby restaurant.Name select restaurant;
        //}
    }
}
