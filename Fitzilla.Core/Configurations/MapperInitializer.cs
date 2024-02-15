using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.Models.Data;

namespace Fitzilla.BLL.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Exercise, ExerciseDTO>().ReverseMap();
        CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();
        CreateMap<Exercise, UpdateExerciseDTO>().ReverseMap();

        CreateMap<ExerciseRecord, ExerciseRecordDTO>().ReverseMap();
        CreateMap<ExerciseRecord, CreateExerciseRecordDTO>().ReverseMap();
        CreateMap<ExerciseRecord, UpdateExerciseRecordDTO>().ReverseMap();

        CreateMap<ExerciseTemplate, ExerciseTemplateDTO>().ReverseMap();
        CreateMap<ExerciseTemplate, CreateExerciseTemplateDTO>().ReverseMap();
        CreateMap<ExerciseTemplate, UpdateExerciseTemplateDTO>().ReverseMap();

        CreateMap<Media, MediaDTO>().ReverseMap();
        CreateMap<Media, CreateMediaDTO>().ReverseMap();
        CreateMap<Media, UpdateMediaDTO>().ReverseMap();

        CreateMap<Rating, RatingDTO>().ReverseMap();
        CreateMap<Rating, CreateRatingDTO>().ReverseMap();
        CreateMap<Rating, UpdateRatingDTO>().ReverseMap();

        CreateMap<Session, SessionDTO>().ReverseMap();
        CreateMap<Session, CreateSessionDTO>().ReverseMap();
        CreateMap<Session, UpdateSessionDTO>().ReverseMap();

        CreateMap<Plan, PlanDTO>().ReverseMap();
        CreateMap<Plan, CreatePlanDTO>().ReverseMap();
        CreateMap<Plan, UpdatePlanDTO>().ReverseMap();

        CreateMap<Macro, MacroDTO>().ReverseMap();
        CreateMap<Macro, CreateMacroDTO>().ReverseMap();
        CreateMap<Macro, UpdateMacroDTO>().ReverseMap();

        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, CreateUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();
    }
}
