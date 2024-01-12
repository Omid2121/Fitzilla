using AutoMapper;
using Fitzilla.BLL.DTOs;
using Fitzilla.Models.Data;

namespace Fitzilla.BLL.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();
            CreateMap<Exercise, UpdateExerciseDTO>().ReverseMap();

            CreateMap<ExerciseTemplate, ExerciseTemplateDTO>().ReverseMap();
            CreateMap<ExerciseTemplate, CreateExerciseTemplateDTO>().ReverseMap();
            CreateMap<ExerciseTemplate, UpdateExerciseTemplateDTO>().ReverseMap();

            CreateMap<EntityDetail, EntityDetailDTO>().ReverseMap();
            CreateMap<EntityDetail, CreateEntityDetailDTO>().ReverseMap();
            CreateMap<EntityDetail, UpdateEntityDetailDTO>().ReverseMap();

            CreateMap<RecordLog, RecordLogDTO>().ReverseMap();
            CreateMap<RecordLog, CreateRecordLogDTO>().ReverseMap();
            CreateMap<RecordLog, UpdateRecordLogDTO>().ReverseMap();

            CreateMap<Media, MediaDTO>().ReverseMap();
            CreateMap<Media, CreateImageDTO>().ReverseMap();
            CreateMap<Media, UpdateImageDTO>().ReverseMap();

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
}
