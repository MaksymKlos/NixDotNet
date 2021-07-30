using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessSuperiorMvc.BLL.BusinessModels.People;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Staff;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Users;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Nutrition;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;
using FitnessSuperiorMvc.BLL.Dto.People;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
using FitnessSuperiorMvc.BLL.Dto.Services.Nutrition;
using FitnessSuperiorMvc.BLL.Dto.Services.Sport;

namespace FitnessSuperiorMvc.WEB.Mapping
{
    internal class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<List<ExerciseDto>, List<Exercise>>();
                
            CreateMap<SetOfExercises, SetOfExercisesDto>()
                .ForMember(dest =>
                    dest.MuscleGroup, opt =>
                    opt.MapFrom(src => src.MuscleGroups));
            CreateMap<TrainingProgram, TrainingProgramDto>();

            CreateMap<Food, FoodDto>();
            CreateMap<FoodDto, Food>();
            CreateMap<List<Food>, List<FoodDto>>();

            CreateMap<MealPlan, MealPlanDto>();
            
            CreateMap<NutritionProgram, NutritionProgramDto>();

            CreateMap<Person, PersonDto>();
            CreateMap<User, UserDto>();
            CreateMap<Trainer, TrainerDto>();
            CreateMap<Nutritionist, NutritionistDto>();
            CreateMap<Manager, ManagerDto>();
        }
    }
}
