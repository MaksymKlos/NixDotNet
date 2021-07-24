using System.Collections.Generic;
using AutoMapper;
using FitnessSuperiorMvc.BLL.BusinessModels.People;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Staff;
using FitnessSuperiorMvc.BLL.BusinessModels.People.Users;
using FitnessSuperiorMvc.BLL.BusinessModels.Services.Sport;
using FitnessSuperiorMvc.BLL.Dto.People;
using FitnessSuperiorMvc.BLL.Dto.People.Staff;
using FitnessSuperiorMvc.BLL.Dto.People.Users;
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
            CreateMap<SetOfExercises, SetOfExercisesDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<User, UserDto>();
            CreateMap<Trainer, TrainerDto>();
            CreateMap<Nutritionist, NutritionistDto>();
            CreateMap<Manager, ManagerDto>();
        }
    }
}
