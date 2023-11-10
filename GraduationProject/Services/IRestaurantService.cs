using GraduationProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GraduationProject.Services
{
    public interface IRestaurantService
    {
        Restaurant GetByResturantId(int id);
        List<Restaurant> getAll();
        int Create(Restaurant dto, IFormFile file);
        void Delete(int id);
        void Update(int id, Restaurant dto, IFormFile file);
        List<Restaurant> getAllByCateId(int CategoryId);
        Restaurant SearchByRestaurant(string name);
        List<MenuItem> searchByNameOfMeal(string name);
        List<MenuItem> GetmenuById(int menuId);
    }
}
