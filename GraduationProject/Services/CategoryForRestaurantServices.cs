using GraduationProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraduationProject.Services
{
    public class CategoryForRestaurantServices : ICategoryForRestaurantRepository
    {
        Context context = new Context();
        IRestaurantService restaurantService;
        public CategoryForRestaurantServices(IRestaurantService _restaurantService)
        {
            restaurantService = _restaurantService;
        }
        public string getNameById(int id)
        {
            var cat = context.CategoryForRestaurant.SingleOrDefault(c => c.Id == id);
            return cat.Name;
        }
        public int getIdByName(string name)
        {
            return context.CategoryForRestaurant.FirstOrDefault(c => c.Name == name).Id;
        }
        public  CategoryForRestaurant getById(int id)
        {
            return context.CategoryForRestaurant.SingleOrDefault(c => c.Id == id);
        }
        public List<CategoryForRestaurant> getAll()
        {
            return context.CategoryForRestaurant.ToList();
        }
        public int Create(CategoryForRestaurant cata)
        {

            context.CategoryForRestaurant.Add(cata);
            int raw = context.SaveChanges();
            return raw;
        }
        public int Update(int id, CategoryForRestaurant cata)
        {
            var OldCata = context.CategoryForRestaurant.FirstOrDefault(u => u.Id == id);
            OldCata.Name = cata.Name;
            OldCata.Description = cata.Description;
            int raw = context.SaveChanges();
            return raw;
        }
        public int Delete(int  id)
        {
            var Cata = context.CategoryForRestaurant.FirstOrDefault(u => u.Id == id);
            List<Restaurant> restaurants =  restaurantService.getAllByCateId(id);
            foreach (var item in restaurants)
            {
                DeleteRestaurant(item.RestaurantId);
            }
            context.CategoryForRestaurant.Remove(Cata);
            int raw = context.SaveChanges();
            return raw;
        }

        public int DeleteRestaurant(int id)
        {
            Restaurant restaurant = restaurantService.GetByResturantId(id);
            context.Restaurants.Remove(restaurant);
            return context.SaveChanges();

        }

    }
}
