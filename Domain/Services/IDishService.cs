using sample_netcore.Models.Entities;
using System;
using System.Collections.Generic;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// Dish service interface
    /// </summary>
    public interface IDishService
    {
        /// <summary>
        /// Gets the dish categories.
        /// </summary>
        IEnumerable<DishCategory> GetAllDishCategories();

        /// <summary>
        /// Creates the dish category.
        /// </summary>
        DishCategory CreateDishCategory(DishCategory dishCate);

        /// <summary>
        /// Updates the dish category.
        /// </summary>
        DishCategory UpdateDishCategory(Guid id, DishCategory dishCate);

        /// <summary>
        /// Gets the dish category by identifier.
        /// </summary>
        DishCategory GetDishCategoryById(Guid id);

        /// <summary>
        /// Gets all dishes by category identifier.
        /// </summary>
        IEnumerable<Dish> GetAllDishesByCategoryId(Guid id);

        /// <summary>
        /// Gets all dishes.
        /// </summary>
        IEnumerable<Dish> GetAllDishes();

        /// <summary>
        /// Creates the dish.
        /// </summary>
        /// <param name="dish">The dish.</param>
        Dish CreateDish(Dish dish);

        /// <summary>
        /// Finds the name of the dish category by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IEnumerable<DishCategory> FindDishCategoryByName(string name);
    }
}
