using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NutritionProgram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Food> Foods { get; set; }

        public NutritionProgram(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
