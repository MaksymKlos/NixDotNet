using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.BLL.BusinessModels;
using FitnessSuperiorMvc.DA.EF;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class NutritionProgramService
    {
        private readonly IRepository<NutritionProgram> _programRepository;
        private readonly IRepository<MealPlan> _mealPlanRepository;
        public NutritionProgramService() {}
        public NutritionProgramService(IRepository<NutritionProgram> programRepository, IRepository<MealPlan> mealPlanRepository)
        {
            _programRepository = programRepository;
            _mealPlanRepository = mealPlanRepository;
        }

        public virtual List<NutritionProgram> GetAll() => _programRepository.GetAll().OrderBy(s => s.Id).ToList();

        public virtual NutritionProgram GetById(int id, FitnessAppContext context)
        {
            var binder = new Binder(context);
            var program = _programRepository.GetById(id);
            program.MealPlans = binder.GetMealPlansOfProgram(id);
            program.Nutritionist = binder.GetNutritionistOfProgram(id);
            return program;
        }
        public virtual List<MealPlan> GetAddingMealPlans(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            var mealPlans = controller.GetMealPlans(user);
            return mealPlans;
        }
        public virtual void DeleteAddingMealPlans(Nutritionist user, FitnessAppContext context)
        {
            AddingController controller = new AddingController(context);
            controller.DeleteMealPlan(user);
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
