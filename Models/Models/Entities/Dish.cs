using System;

namespace sample_netcore.Models.Entities
{
    public class Dish
    {
        public Guid Id { get; set; }

        public Guid DishCategoryId { get; set; }

        public string DishName { get; set; }

        public double UnitPrice { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public DishCategory DishCategory { get; set; }
    }
}
