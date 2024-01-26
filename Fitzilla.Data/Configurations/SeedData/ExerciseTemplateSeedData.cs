using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;

namespace Fitzilla.DAL.Configurations.SeedData;

public static class ExerciseTemplateSeedData
{
    public static List<ExerciseTemplate> ExerciseTemplates()
    {
        User user = new();
        List<Media> medias = [];

        return
        [
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bench Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The bench press is an upper-body weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench. The exercise uses the pectoralis major, the anterior deltoids, and the triceps, among other stabilizing muscles.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Bench Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The incline bench press is an upper body strength training exercise that consists of pressing a weight at an angle, similar to but less than one hundred and eighty degrees, to the body. This angle is between 45 and 60 degrees, lower than that of a standard bench press.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Decline Bench Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The decline bench press is an exercise which helps you get the complete chest development. It recruits more of the inner pecs, i.e. the sternocostal head of the pectoralis major muscle. It is performed in a very similar manner to the flat bench press, the only difference is that the bench is set to a decline position of 15 to 30 degrees.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell bench press is a variation of the barbell bench press and an exercise used to build the muscles of the chest. Often times, the dumbbell bench press is recommended after reaching a certain point of strength on the barbell bench press to avoid pec and shoulder injuries.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Dumbbell Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The incline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only incline dumbbell bench press equipment that you really need is the following: dumbbells and incline bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Decline Dumbbell Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The decline dumbbell bench press is a free weights exercise that primarily targets the chest and to a lesser degree also targets the shoulders and triceps. The only decline dumbbell bench press equipment that you really need is the following: dumbbells and decline bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The cable fly or cable flye is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Cable Press Fly",
                CreatorId = user.Id,
                Creator = user,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Equipment = Equipment.Cable,
                Medias = medias,
                Description = "The incline cable fly or incline cable flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline cable fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Decline Cable Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The decline cable fly or decline cable fly is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline cable fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell fly or dumbbell fly is a strength training exercise similar in movement to a cable fly. It involves squeezing the arms together in front of the body. The difference is, in the dumbbell fly, the force is perpendicular to the body, while in the cable fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Dumbbell Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The incline dumbbell fly or incline dumbbell flye is a strength training exercise similar in movement to the incline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the incline dumbbell fly, the force is perpendicular to the body, while in the incline dumbbell fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Decline Dumbbell Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The decline dumbbell fly or decline dumbbell flye is a strength training exercise similar in movement to the decline dumbbell fly. It involves squeezing the arms together in front of the body. The difference is, in the decline dumbbell fly, the force is perpendicular to the body, while in the decline dumbbell fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Machine Press Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The machine press fly or machine fly is a strength training exercise similar in movement to the pec deck. It involves squeezing the arms together in front of the body. The difference is, in the pec deck, the force is perpendicular to the body, while in the machine fly the force is horizontal to the body.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Machine Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The machine press is a machine-based exercise targeting the chest. It is similar to the barbell bench press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the bench press.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Machine Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The incline machine press is a machine-based exercise targeting the chest. It is similar to the incline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the incline press.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Decline Machine Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The decline machine press is a machine-based exercise targeting the chest. It is similar to the decline barbell press, but it is performed using a machine. The machine press is a great exercise for beginners to learn the basic movement pattern of the decline press.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dips",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dip is a strength training exercise used to develop strength and size in triceps. Dips are an advanced bodyweight exercise that is primarily used to develop the triceps muscles. It is also a compound exercise that also involves the chest and shoulders, making it a great exercise for developing overall upper body strength.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Close-Grip Bench Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The close-grip bench press is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only close-grip bench press equipment that you really need is the following: barbell and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable Rope Tricep Pushdown",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The cable rope tricep pushdown is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable rope tricep pushdown equipment that you really need is the following: cable machine and rope attachment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Lying Triceps Extension",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The lying triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only lying triceps extension equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Tricep Dips",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The tricep dips is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only tricep dips equipment that you really need is the following: dip station.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Diamond Push-Ups",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The diamond push-ups is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only diamond push-ups equipment that you really need is the following: no equipment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bench Dip",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The bench dip is a bodyweight exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only bench dip equipment that you really need is the following: bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "One-Arm Overhead Extension",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The one-arm overhead extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only one-arm overhead extension equipment that you really need is the following: dumbbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standard Push-Up",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The standard push-up is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, lower back, middle back, shoulders and triceps. The only standard push-up equipment that you really need is the following: no equipment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Triceps Machine Dip",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The triceps machine dip is a machine-based exercise targeting the triceps. It is similar to the bench dip, but it is performed using a machine. The machine dip is a great exercise for beginners to learn the basic movement pattern of the dip.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Overhead Triceps Extension",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell overhead triceps extension is a free weights exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only dumbbell overhead triceps extension equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable Overhead Extension With Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The cable overhead extension with rope is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable overhead extension with rope equipment that you really need is the following: cable machine and rope attachment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Single-Arm Cable Kick-Back",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The single-arm cable kick-back is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the shoulders and forearms. The only single-arm cable kick-back equipment that you really need is the following: cable machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable Push-Down",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Triceps],
                Medias = medias,
                Description = "The cable push-down is a strength training exercise that primarily targets the triceps and to a lesser degree also targets the chest and shoulders. The only cable push-down equipment that you really need is the following: cable machine and v-bar attachment.",
            },

            //Back Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Lat Pulldown",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Lats, TargetMuscle.Biceps],
                Medias = medias,
                Description = "The lat pulldown is a machine-based exercise targeting the latissimus dorsi. It is performed in a seated position with a bar overhead. The lat pulldown is a great exercise for beginners to learn the basic movement pattern of the pull-up.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.LowerBack, TargetMuscle.Abdominals, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.Quadriceps],
                Medias = medias,
                Description = "The deadlift is a free weights exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only deadlift equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Bent-Over Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The barbell bent-over row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only barbell bent-over row equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Pull-Up",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Bodyweight,
                TargetMuscles = [TargetMuscle.Lats, TargetMuscle.Biceps, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The pull-up is a bodyweight exercise that primarily targets the lats and to a lesser degree also targets the abs, biceps, forearms, lower back, middle back, shoulders and traps. The only pull-up equipment that you really need is the following: pull-up bar.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Single-arm Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The dumbbell single-arm row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only dumbbell single-arm row equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Chest-supported Dumbbell Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The chest-supported dumbbell row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only chest-supported dumbbell row equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Single-arm T-Bar Rows",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The single-arm t-bar rows is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only single-arm t-bar rows equipment that you really need is the following: t-bar row machine and v-handle attachment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Renegade Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The renegade row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only renegade row equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Med Ball Wood Chop",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.MedicineBall,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.Chest, TargetMuscle.Forearms, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Obliques, TargetMuscle.Quadriceps, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The med ball wood chop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only med ball wood chop equipment that you really need is the following: medicine ball.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "T-Bar Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The t-bar row is a free weights exercise that primarily targets the middle back and to a lesser degree also targets the biceps, lats, lower back, shoulders and traps. The only t-bar row equipment that you really need is the following: t-bar row machine and v-handle attachment.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.MiddleBack, TargetMuscle.Biceps, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The seated row is a machine-based exercise targeting the middle back. It is performed in a seated position with a chest pad, two foot pads, and a handle to pull. The seated row is a great exercise for beginners to learn the basic movement pattern of the row.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Pull-Over",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Chest, TargetMuscle.Forearms, TargetMuscle.Lats, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Shoulders, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell pull-over is a free weights exercise that primarily targets the lats and to a lesser degree also targets the chest, forearms, lower back, middle back, shoulders and triceps. The only dumbbell pull-over equipment that you really need is the following: dumbbell.",
            },

            //Biceps Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standing Dumbbell Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The standing dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing dumbbell curl equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Hammer Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The hammer curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only hammer curl equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Dumbbell Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The incline dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only incline dumbbell curl equipment that you really need is the following: dumbbells and incline bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Zottman Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The zottman curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only zottman curl equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "EZ Bar Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only ez bar curl equipment that you really need is the following: ez curl bar.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Reverse Curl Straight Bar",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The reverse curl straight bar is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only reverse curl straight bar equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Concentration Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The concentration curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only concentration curl equipment that you really need is the following: dumbbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Twisting Dumbbell Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The twisting dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only twisting dumbbell curl equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Prone Dumbbell Spider Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The prone dumbbell spider curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only prone dumbbell spider curl equipment that you really need is the following: dumbbells and incline bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Leant-Forward EZ Bar Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The leant-forward ez bar curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only leant-forward ez bar curl equipment that you really need is the following: ez curl bar.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standing Reverse Barbell Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The standing reverse barbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing reverse barbell curl equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Alternating Dumbbell Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The seated alternating dumbbell curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only seated alternating dumbbell curl equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standing Cable Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The standing cable curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only standing cable curl equipment that you really need is the following: cable machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable Flex Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Biceps, TargetMuscle.Forearms],
                Medias = medias,
                Description = "The cable flex curl is a free weights exercise that primarily targets the biceps and to a lesser degree also targets the forearms and shoulders. The only cable flex curl equipment that you really need is the following: cable machine.",
            },

            //Shoulders Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Overhead Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The barbell overhead press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, quads, traps and triceps. The only barbell overhead press equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standing Dumbbell Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Chest, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The standing dumbbell fly is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the chest and traps. The only standing dumbbell fly equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Face Pull",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The face pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only face pull equipment that you really need is the following: cable machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "High Pull",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only high pull equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Dumbbell Clean",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The seated dumbbell clean is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, traps and triceps. The only seated dumbbell clean equipment that you really need is the following: dumbbells and flat bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Trap Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The trap raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only trap raise equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Clean and Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The clean and press is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only clean and press equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Snatch-Grip High Pull",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The snatch-grip high pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip high pull equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Raise Complex",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell raise complex is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only dumbbell raise complex equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Snatch-Grip Low Pull",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The snatch-grip low pull is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the biceps, calves, forearms, hamstrings, lats, lower back, middle back, quads, traps and triceps. The only snatch-grip low pull equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Bent-Over Lateral Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The dumbbell bent-over lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only dumbbell bent-over lateral raise equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Machine Shoulder Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The machine shoulder press is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, middle back, quads and triceps. The only machine shoulder press equipment that you really need is the following: shoulder press machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Front Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The front raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads and triceps. The only front raise equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Reverse Pec Deck Fly",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The reverse pec deck fly is a exercise machine exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only reverse pec deck fly equipment that you really need is the following: pec deck machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "One-Arm Cable Lateral Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Shoulders, TargetMuscle.Forearms, TargetMuscle.Trapezius, TargetMuscle.Triceps],
                Medias = medias,
                Description = "The one-arm cable lateral raise is a free weights exercise that primarily targets the shoulders and to a lesser degree also targets the abs, forearms, traps and triceps. The only one-arm cable lateral raise equipment that you really need is the following: cable machine.",
            },

            //Abs Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Plank",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.Chest, TargetMuscle.Forearms, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The plank is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, lower back, middle back, shoulders and traps. The only plank equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Mountain climber",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.Calves, TargetMuscle.Chest, TargetMuscle.Forearms, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Quadriceps, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The mountain climber is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the calves, chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, quads, shoulders and traps. The only mountain climber equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Reverse crunch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The reverse crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only reverse crunch equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Grounded Russian twist",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.MedicineBall,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The grounded russian twist is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only grounded russian twist equipment that you really need is the following: exercise ball.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dead bug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The dead bug is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only dead bug equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Leg raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The leg raise is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only leg raise equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Abs roll-out",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Wheel,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The abs roll-out is a exercise machine and pilates exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only abs roll-out equipment that you really need is the following: ab roller.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bird-dog",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The bird-dog is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bird-dog equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell woodchop",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.Chest, TargetMuscle.Forearms, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors, TargetMuscle.LowerBack, TargetMuscle.MiddleBack, TargetMuscle.Obliques, TargetMuscle.Quadriceps, TargetMuscle.Shoulders, TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The dumbbell woodchop is a free weights exercise that primarily targets the abs and to a lesser degree also targets the chest, forearms, glutes, hamstrings, hip flexors, lower back, middle back, obliques, quads, shoulders and traps. The only dumbbell woodchop equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Medicine ball crunch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.MedicineBall,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The medicine ball crunch is a medicine ball exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only medicine ball crunch equipment that you really need is the following: medicine ball.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Flutter kicks",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The flutter kicks is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only flutter kicks equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "V-sit",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The v-sit is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only v-sit equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bicycle Crunch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The bicycle crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only bicycle crunch equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Tuck and crunch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The tuck and crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and lower back. The only tuck and crunch equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Crunch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The crunch is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and neck. The only crunch equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Hanging knee raise twist",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.PullUpBar,
                TargetMuscles = [TargetMuscle.Abdominals, TargetMuscle.HipFlexors, TargetMuscle.Obliques],
                Medias = medias,
                Description = "The hanging knee raise twist is a bodyweight exercise that primarily targets the abs and to a lesser degree also targets the hip flexors and obliques. The only hanging knee raise twist equipment that you really need is the following: pull-up bar.",
            },

            //Traps Exerscies
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Shoulder blade squeeze",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The shoulder blade squeeze is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shoulder blade squeeze equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Shrug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only shrug equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Upright row",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The upright row is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only upright row equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Pushup",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The pushup is a bodyweight exercise that primarily targets the chest and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, outer thighs, quads, shoulders and triceps. The only pushup equipment that you really need is the following: exercise mat.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Face Pull",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The face pull is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only face pull equipment that you really need is the following: cable machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Snatch",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The dumbbell snatch is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only dumbbell snatch equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Pullup Shrug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.PullUpBar,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The pullup shrug is a bodyweight exercise that primarily targets the traps and to a lesser degree also targets the abs, biceps, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only pullup shrug equipment that you really need is the following: pull-up bar.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Shrug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The barbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell shrug equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Incline Dumbbell Shrug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The incline dumbbell shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only incline dumbbell shrug equipment that you really need is the following: dumbbells and incline bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Behind-the-Back Shrug",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Trapezius],
                Medias = medias,
                Description = "The barbell behind-the-back shrug is a free weights exercise that primarily targets the traps and to a lesser degree also targets the abs, calves, forearms, glutes, hamstrings, hip flexors, lower back, middle back, neck, obliques, outer thighs, quads, shoulders and triceps. The only barbell behind-the-back shrug equipment that you really need is the following: barbell.",
            },

            //Quads Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bulgarian Split Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Quadriceps,
                TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The bulgarian split squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bulgarian split squat equipment that you really need is the following: dumbbells and bench.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Front Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The barbell front squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell front squat equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Goblet Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The goblet squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only goblet squat equipment that you really need is the following: dumbbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Box Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The barbell box squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell box squat equipment that you really need is the following: barbell and box.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Diagonal Walking Lunges",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The diagonal walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only diagonal walking lunges equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Hack Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The hack squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only hack squat equipment that you really need is the following: hack squat machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Leg Press",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The leg press is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg press equipment that you really need is the following: leg press machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Sprints",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The sprints is a cardio exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only sprints equipment that you really need is the following: track.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Weighted Jump Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The weighted jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only weighted jump squat equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Box Jump",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The box jump is a plyometrics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only box jump equipment that you really need is the following: box.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Single-Leg Jump Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The seated single-leg jump squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only seated single-leg jump squat equipment that you really need is the following: box.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Walking Lunge",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The walking lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunge equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Leg Extensions",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The leg extensions is a exercise machine exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only leg extensions equipment that you really need is the following: leg extension machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Back Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The barbell back squat is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and lower back. The only barbell back squat equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Quadriceps, TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.",
            },

            //Hamstring Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Glute Bridge",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The glute bridge is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute bridge equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Hip Thrust",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The hip thrust is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only hip thrust equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Cable or Band Pull-through",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Cable,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The cable or band pull-through is a exercise machine and alternative exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Dumbbell Romanian Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The dumbbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only dumbbell romanian deadlift equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Barbell Romanian Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The barbell romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only barbell romanian deadlift equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes, lower back and quads. The only deadlift equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Single-leg Romanian Deadlift",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The single-leg romanian deadlift is a free weights exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only single-leg romanian deadlift equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Walking Lunges",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.Quadriceps, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The walking lunges is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only walking lunges equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Rear-Foot Elevated Lunge",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.Quadriceps, TargetMuscle.HipFlexors],
                Medias = medias,
                Description = "The rear-foot elevated lunge is a free weights exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only rear-foot elevated lunge equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Lying Leg Curl",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.Calves, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The lying leg curl is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only lying leg curl equipment that you really need is the following: leg curl machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Back Extension",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The back extension is a exercise machine exercise that primarily targets the lower back and to a lesser degree also targets the abs, glutes and hamstrings. The only back extension equipment that you really need is the following: hyperextension machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Glute-Ham Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Glutes, TargetMuscle.Hamstrings, TargetMuscle.LowerBack],
                Medias = medias,
                Description = "The glute-ham raise is a exercise machine exercise that primarily targets the hamstrings and to a lesser degree also targets the calves, glutes and lower back. The only glute-ham raise equipment that you really need is the following: glute ham raise machine.",
            },

            //Calves Exersices
            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated calf raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Farmer’s walk on toes",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Dumbbell,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The farmer’s walk on toes is a free weights exercise that primarily targets the calves and to a lesser degree also targets the forearms, glutes, hamstrings, hip flexors, lower back, quads and traps. The only farmer’s walk on toes equipment that you really need is the following: dumbbells.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Jump rope",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The jump rope is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Standing Barbell Calf Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Barbell,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The standing barbell calf raise is a exercise machine and free weights exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only standing barbell calf raise equipment that you really need is the following: barbell.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Calf Raise",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The seated calf raise is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise equipment that you really need is the following: calf raise machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Hill Runs",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The hill runs is a cardiovascular and calisthenics exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings, hip flexors, lower back, quads and traps.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Jumping Jack",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The jumping jack is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Seated Calf Raise Machine",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The seated calf raise machine is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes and hamstrings. The only seated calf raise machine equipment that you really need is the following: calf raise machine.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Agility Ladder",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.None,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The agility ladder is a calisthenics and cardiovascular exercise that primarily targets the calves and to a lesser degree also targets the abs, biceps, chest, forearms, glutes, groin, hamstrings, hip flexors, lats, lower back, middle back, obliques, quads, shoulders, traps and triceps.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "Bosu Ball Squat",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.BosuBall,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The bosu ball squat is a exercise machine and calisthenics exercise that primarily targets the quads and to a lesser degree also targets the calves, glutes, hamstrings and hip flexors. The only bosu ball squat equipment that you really need is the following: bosu ball.",
            },

            new ExerciseTemplate
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                Title = "StairMaster",
                CreatorId = user.Id,
                Creator = user,
                Equipment = Equipment.Machine,
                TargetMuscles = [TargetMuscle.Calves],
                Medias = medias,
                Description = "The stairmaster is a exercise machine exercise that primarily targets the calves and to a lesser degree also targets the abs, glutes, hamstrings and quads. The only stairmaster equipment that you really need is the following: stairmaster.,"
            }
        ];
    }
}