using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; private set; }
    }
}
