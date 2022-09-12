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
        Restaurant DeleteRestaurant(int id);
        int Commit();
    }
}
