using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq; 

namespace OdeToFood.Data
{
	public class SqlRestaurantData : IRestaurantData
	{
		private readonly OdeToFoodDbContext db;

		public SqlRestaurantData(OdeToFoodDbContext db)
		{
			this.db = db;
		}

		public int Commit()
		{
			return db.SaveChanges();
		}

		public Restaurant CreateNewRestaurant(Restaurant newRestaurant)
		{
			db.Add(newRestaurant);
			return newRestaurant;
		}

		public Restaurant DeleteRestaurant(int id)
		{
			var restaurant = GetRestaurantById(id);
			if (restaurant != null)
			{
				db.Remove(restaurant);
			}
			return restaurant;
		}

		public Restaurant GetRestaurantById(int id)
		{
			return db.Restaurants.Find(id);
		}

		public IEnumerable<Restaurant> GetRestaurantsByName(string name)
		{
			var query = from restaurant in db.Restaurants 
						where restaurant.Name.StartsWith(name) || string.IsNullOrEmpty(name) orderby restaurant.Name select restaurant;
			return query;
		}

		public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
		{
			var entity = db.Restaurants.Attach(updatedRestaurant);
			entity.State = EntityState.Modified;
			return updatedRestaurant;
		}
	}
}
