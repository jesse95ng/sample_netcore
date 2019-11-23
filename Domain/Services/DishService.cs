using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Context;
using sample_netcore.Models.Entities;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// Dish service
    /// </summary>
    /// <seealso cref="sample_netcore.Services.IDishService" />
    public class DishService : IDishService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The database context
        /// </summary>
        private readonly SampleDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public DishService(SampleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext.ThrowIfNull(nameof(dbContext));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        /// <summary>
        /// Creates the dish category.
        /// </summary>
        public DishCategory CreateDishCategory(DishCategory dishCate)
        {
            try
            {
                _dbContext.DishCategories.Add(dishCate);
                _dbContext.SaveChanges();
                return dishCate;
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all dishes by category identifier.
        /// </summary
        public IEnumerable<Dish> GetAllDishesByCategoryId(Guid id)
        {
            try
            {
                return _dbContext.Dishes
                    .ToList()
                    .Where(dish => dish.DishCategoryId == id);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the dish categories.
        /// </summary>
        public IEnumerable<DishCategory> GetAllDishCategories()
        {
            try
            {
                return _dbContext.DishCategories
                    .OrderBy(dishCate => dishCate.Id)
                    .ToList();
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the dish category by identifier.
        /// </summary>
        public DishCategory GetDishCategoryById(Guid id)
        {
            try
            {
                return _dbContext.DishCategories
                    .FirstOrDefault(dishCate => dishCate.Id == id);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the dish category.
        /// </summary>
        public DishCategory UpdateDishCategory(Guid id, DishCategory dishCate)
        {
            try
            {
                var dishCateInDb = _dbContext.DishCategories.FirstOrDefault(dishCategory => dishCategory.Id == id);
                if(dishCateInDb != null)
                {
                    _mapper.Map(dishCate, dishCateInDb);
                    dishCate.Id = dishCateInDb.Id;
                    _dbContext.SaveChanges();
                }
                return dishCate;
            }
            catch
            {
                throw new Exception();
            }
        }

        public IEnumerable<DishCategory> FindDishCategoryByName(string name)
        {
            var categories = _dbContext.DishCategories.FromSql($"spFindDishCategoriesByName {name}").ToList();
            return categories;
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            try
            {
                return _dbContext.Dishes.OrderBy(dish => dish.Id).ToList();
            }
            catch
            {
                throw new Exception();
            }
        }

        public Dish CreateDish(Dish dish)
        {
            try
            {
                _dbContext.Dishes.Add(dish);
                _dbContext.SaveChanges();
                return dish;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
