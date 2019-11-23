using System;
using System.Collections.Generic;

namespace sample_netcore.Models.Entities
{
    public class DishCategory
    {
        public Guid Id { get; set; }

        public string DishCategoryName { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Dish> Dishs { get; set; }
    }
}
