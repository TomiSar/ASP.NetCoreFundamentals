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
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateNewRestaurant(Restaurant newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Country="USA", Location="Maryland", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Country="Great Britain", Location="London", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 3, Name = "La Costa", Country="USA", Location = "California", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 4, Name = "Weeruska", Country="Finland", Location = "Helsinki", Cuisine=CuisineType.Finnish },
                new Restaurant { Id = 5, Name = "Wong Yong Hong Sushi", Country="China", Location = "Peking", Cuisine=CuisineType.Chinese },
            };
        }

        public int Commit()
		{
            return 0;
		}

        public Restaurant CreateNewRestaurant(Restaurant newRestaurant)
		{
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
		}

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
		{
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
			{
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Country = updatedRestaurant.Country;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
			}
            return restaurant;
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
