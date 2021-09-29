using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class NutritionProgramService
    {
        private readonly IRepository<NutritionProgram> _programRepository;
        private readonly IRepository<MealPlan> _mealPlanRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IFitnessServicesRepository _fitnessServicesRepository;

        public NutritionProgramService() {}
        public NutritionProgramService(
            IRepository<NutritionProgram> programRepository,
            IRepository<MealPlan> mealPlanRepository,
            IStaffRepository staffRepository,
            IFitnessServicesRepository fitnessServicesRepository)
        {
            _programRepository = programRepository;
            _mealPlanRepository = mealPlanRepository;
            _staffRepository = staffRepository;
            _fitnessServicesRepository = fitnessServicesRepository;
        }

        public virtual List<NutritionProgram> GetAll() => _programRepository.GetAll().OrderBy(s => s.Id).ToList();

        public virtual NutritionProgram GetById(int id)
        {
            var program = _programRepository.GetById(id);
            program.MealPlans = _fitnessServicesRepository.GetMealPlansOfProgram(id);
            program.Nutritionist = _fitnessServicesRepository.GetNutritionistOfProgram(id);
            return program;
        }

        public virtual List<NutritionProgram> GetNutritionPrograms(int id)
            => _fitnessServicesRepository.GetNutritionPrograms(id);

        public virtual List<MealPlan> GetAddingMealPlans(Nutritionist user)
            => _staffRepository.GetMealPlans(user);

        public virtual void DeleteAddingMealPlans(Nutritionist user)
        {
            _staffRepository.DeleteMealPlan(user);
        }
        public virtual void Update(NutritionProgram program) => _programRepository.Update(program);

        public virtual void Remove(int id)
        {
            var program = _programRepository.GetById(id);
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program), $"Cannot find program plan with id '{id}'");
            }
            foreach (var mealPlan in program.MealPlans.ToList())
            {
                _mealPlanRepository.Remove(mealPlan.Id);
            }
            _programRepository.Remove(id);
        }

        public virtual NutritionProgram Create(NutritionProgram program) => _programRepository.Create(program);
    }
}
