using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Text;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.People
{
    public class User: IPerson, IKey
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
        public ICollection<NutritionProgram> NutritionPrograms { get; set; }

        public User()
        {
            TrainingPrograms = new List<TrainingProgram>();
            NutritionPrograms = new List<NutritionProgram>();
        }
    }
}
