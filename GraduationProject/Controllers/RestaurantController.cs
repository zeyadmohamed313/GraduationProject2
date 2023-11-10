using GraduationProject.Models;
using GraduationProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        ICategoryForRestaurantRepository categoryRestaurantServices;
        public RestaurantController(IRestaurantService restaurantService, ICategoryForRestaurantRepository _categoryRestaurantServices)
        {
            _restaurantService = restaurantService;
            categoryRestaurantServices = _categoryRestaurantServices;
        }

        [HttpPost("Create  Restaurant")]
        public ActionResult CreateRestaurant([FromBody] Restaurant restaurant, IFormFile file)
        {
            var id = _restaurantService.Create(restaurant,file);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet("Get All Restaurants")]
        public IActionResult GetAllRestaurants()
        {
            List<Restaurant> restaurants = _restaurantService.getAll();
            return Ok(restaurants);
        } 

        [HttpGet("Get Restaurant")]
        public IActionResult GetRestaurant(int id)
        {
            if (_restaurantService.getAll() == null)
            {
                return NotFound();
            }
            var Restaurant = _restaurantService.GetByResturantId(id);
            if (Restaurant == null)
            {
                return NotFound();
            }
            return Ok(Restaurant);
        }


        [HttpPut("Update Restaurant")]
        public ActionResult Update([FromRoute] int id, [FromBody] Restaurant restaurant, IFormFile file)
        {
            _restaurantService.Update(id, restaurant,file);
            return Ok("Update Resturant Done");
        }


        [HttpDelete("Delete Category For Restaurant")]
        public IActionResult DeleteCategoryForRestuarant(int id)
        {
            if (_restaurantService.getAll() == null)
            {
                return Problem("Entity set 'AppDbContext.Restuarant '  is null.");
            }
            var restauran = _restaurantService.GetByResturantId(id);
            if (restauran != null)
            {
                _restaurantService.Delete(id);
            }
            return Ok("Delete this Category For Restaurant Done");
        }
        [HttpDelete("Delete Restaurant")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return Ok("Delete Restaurant Done");
        }


        [HttpPost("Search By Name Restaurant")]
        public ActionResult<Restaurant> SearchRestaurant(string name)
        {
           Restaurant  restaurant = _restaurantService.SearchByRestaurant(name);
            return Ok(restaurant);
        }
        [HttpPost("Search By Name Name of meal")]
        public ActionResult  SearchByNameOfMealt(string name)
        {
            List <MenuItem> menuItems = _restaurantService.searchByNameOfMeal(name);
            return Ok(menuItems);
        }



        [HttpPost("Menu of Restaurant")]
        public ActionResult<MenuItem> SearchRestaurant(int menuId)
        {
           List<MenuItem> menuItems = _restaurantService.GetmenuById(menuId) ;
            return Ok(menuItems);
        }


    }
}
