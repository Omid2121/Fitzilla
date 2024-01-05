using AutoMapper;
using Fitzilla.DAL.DTOs;
using Fitzilla.Models.Data;

namespace Fitzilla.BLL.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();
            CreateMap<Exercise, UpdateExerciseDTO>().ReverseMap();

            CreateMap<ExerciseTemplate, ExerciseTemplateDTO>().ReverseMap();
            CreateMap<ExerciseTemplate, CreateExerciseTemplateDTO>().ReverseMap();
            CreateMap<ExerciseTemplate, UpdateExerciseTemplateDTO>().ReverseMap();

            CreateMap<Workout, WorkoutDTO>().ReverseMap();
            CreateMap<Workout, CreateWorkoutDTO>().ReverseMap();
            CreateMap<Workout, UpdateWorkoutDTO>().ReverseMap();

            CreateMap<Macro, MacroDTO>().ReverseMap();
            CreateMap<Macro, CreateMacroDTO>().ReverseMap();
            CreateMap<Macro, UpdateMacroDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }
    }
}
