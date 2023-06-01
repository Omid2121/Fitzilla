using AutoMapper;
using Fitzilla.Core.DTOs;
using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();
            CreateMap<Exercise, UpdateExerciseDTO>().ReverseMap();

            CreateMap<ExerciseType, ExerciseTypeDTO>().ReverseMap();
            CreateMap<ExerciseType, CreateExerciseTypeDTO>().ReverseMap();
            CreateMap<ExerciseType, UpdateExerciseTypeDTO>().ReverseMap();

            CreateMap<Workout, WorkoutDTO>().ReverseMap();
            CreateMap<Workout, CreateWorkoutDTO>().ReverseMap();
            CreateMap<Workout, UpdateWorkoutDTO>().ReverseMap();

            CreateMap<User , UserDTO>().ReverseMap();
        }
    }
}
