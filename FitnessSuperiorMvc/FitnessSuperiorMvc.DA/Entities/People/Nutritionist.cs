using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Binders;
using FitnessSuperiorMvc.DA.Entities.Interaction;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.People
{
    public class Nutritionist: IPerson, IStaff, IKey
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
        public string Education { get; set; }
        public int WorkExperience { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public string AgeSpecialization { get; set; }
        public ICollection<NutritionProgram> NutritionPrograms { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
        public ICollection<AddingFood> AddingFood { get; set; }
        public ICollection<AddingMealPlans> AddingMealPlans { get; set; }

        public Nutritionist()
        {
            NutritionPrograms = new List<NutritionProgram>();
            MealPlans = new List<MealPlan>();
            AddingMealPlans = new List<AddingMealPlans>();
            AddingFood= new List<AddingFood>();
        }

    } 
}
