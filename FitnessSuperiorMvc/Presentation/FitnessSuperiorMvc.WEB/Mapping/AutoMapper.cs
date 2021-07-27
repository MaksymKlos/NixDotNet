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
            CreateMap<List<FoodDto>, List<Food>>()
                .ForMember(dest => dest.Select(f => f.Name), opt => opt.MapFrom(src => src.Select(f => f.Name)))
                .ForMember(dest => dest.Select(f => f.BeneficialFeatures),
                    opt => opt.MapFrom(src => src.Select(f => f.BeneficialFeatures)))
                .ForMember(dest => dest.Select(f => f.Calories),
                    opt => opt.MapFrom(src => src.Select(f => f.Calories)));
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
