using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraduationProject.Services
{

    
    public class RestaurantService : IRestaurantService
    {
        Context context = new Context();
        public Restaurant GetByResturantId(int id)
        {
            var restaurant = context.Restaurants.Include(r => r.menu).FirstOrDefault(r => r.RestaurantId == id);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");
           return restaurant;
        }
        public List<Restaurant> getAllByCateId(int CategoryId)
        {
            var cate = context.CategoryForRestaurant.Include(r => r.Restaurants).FirstOrDefault(c => c.Id == CategoryId);
            return cate.Restaurants.ToList() ;
        }
        public List<Restaurant> getAll()
        {
            return context.Restaurants.ToList();
        }

        public int Create(Restaurant restaurant,IFormFile file)
        {

            string fileName = file.FileName;//Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imgs"));
            using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            restaurant.Image = fileName;
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            return restaurant.RestaurantId;
        }
        public void Delete(int id)
        {
            var restaurant = context.Restaurants.FirstOrDefault(r => r.RestaurantId== id);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");
            context.Restaurants.Remove(restaurant);
            context.SaveChanges();
        }

        public void Update(int id,Restaurant restaurant, IFormFile file)
        {
            string fileName = file.FileName;
            string filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imgs"));
            using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            Restaurant OldRestaurant= context.Restaurants.FirstOrDefault(u => u.RestaurantId == id);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");
            OldRestaurant.Name = restaurant.Name;
            OldRestaurant.Email = restaurant.Email;
            OldRestaurant.Street = restaurant.Street;
            OldRestaurant.HasDelivery = restaurant.HasDelivery;
            OldRestaurant.Phone = restaurant.Phone;
            OldRestaurant.Image = fileName;
            OldRestaurant.City = restaurant.City;
            context.SaveChanges();
        }

           public  Restaurant  SearchByRestaurant(string name)
         {
               Restaurant restaurants = context.Restaurants.Include(r => r.menu)
              .Where(r => r.Name.Contains(name)).FirstOrDefault();
            if(restaurants==null)
            {
                restaurants = context.Restaurants.FirstOrDefault(r => name.Contains(r.Name));
            }
            return restaurants;
        }

        public List<MenuItem> searchByNameOfMeal (string name)
        {
            List<MenuItem> menuItems   = context.MenuItems.Where(r => r.Name.Contains(name)).ToList();
            return menuItems;
            //if (menuItems == null)
            //{
            //    List<MenuItem> menuItems2 = new List<MenuItem>();
            //    foreach(var  im in menuItems)
            //    {
            //        MenuItem menuItem = context.MenuItems.FirstOrDefault(r => name.Contains(r.Name));
            //        if ( menuItem !=null)
            //        {
            //            menuItems2.Add(menuItem);
            //        }
            //    }
            //    return menuItems2;
            //}

        }
        public List<MenuItem> GetmenuById(int menuId)
        {
            List<MenuItem> menuItems = context.MenuItems.Where(m => m.MenuId== menuId).ToList();
            return menuItems;
        }
    }
}
