using GraduationProject.Models;
using System.Collections.Generic;

namespace GraduationProject.Services
{
    public interface ICategoryForRestaurantRepository
    {

        string getNameById(int id);
        int getIdByName(string name);
        CategoryForRestaurant getById(int id);
        List<CategoryForRestaurant> getAll();
        int Create(CategoryForRestaurant cata);
        int Update(int id, CategoryForRestaurant cata);
        int Delete(int id);
        int DeleteRestaurant(int id);
    }
}
