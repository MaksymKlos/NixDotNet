using AutoMapper;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
using FitnessSuperiorMvc.BLL.Dto.Programs.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Programs.Sport;
using FitnessSuperiorMvc.DA.Entities.Nutrition;
using FitnessSuperiorMvc.DA.Entities.People;
using FitnessSuperiorMvc.DA.Entities.Sport;

namespace FitnessSuperiorMvc.WEB.Mapping
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<SetOfExercisesDto, SetOfExercises>();
            CreateMap<TrainingProgramDto, TrainingProgram>();

            CreateMap<FoodDto, Food>();
            CreateMap<MealPlanDto, MealPlan>();
            CreateMap<NutritionProgramDto, NutritionProgram>();


            CreateMap<UserDto, User>();
            CreateMap<TrainerDto, Trainer>();
            CreateMap<NutritionistDto, Nutritionist>();
            CreateMap<ManagerDto, Manager>();
        }
    }
}
