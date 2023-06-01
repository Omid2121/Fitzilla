using Fitzilla.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.Data.Configurations.Entities
{
    public class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {
            builder.HasData(
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Bench Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Incline Bench Press"

            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Decline Bench Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Dumbbell Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Incline Dumbbell Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Decline Dumbbell Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Cable Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Incline Cable Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Decline Cable Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Dumbbell Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Incline Dumbbell Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Decline Dumbbell Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Machine Press Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Machine Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Incline Machine Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Decline Machine Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "bench_press.png",
                Name = "Dips"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Close-Grip Bench Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Cable Rope Tricep Pushdown"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Lying Triceps Extension"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Tricep Dips"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Diamond Push-Ups"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Bench Dip"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "One-Arm Overhead Extension"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Standard Push-Up"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Triceps Machine Dip"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Dumbbell Overhead Triceps Extension"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Cable Overhead Extension With Rope"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Single-Arm Cable Kick-Back"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "triceps.png",
                Name = "Cable Push-Down"
            },

            //Back Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Lat Pulldown"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Deadlift"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Barbell Bent-Over Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Pull-Up"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Dumbbell Single-arm Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Chest-supported Dumbbell Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Single-arm T-Bar Rows"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Renegade Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Med Ball Wood Chop"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "T-Bar Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Seated Row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "lat_pulldown.png",
                Name = "Dumbbell Pull-Over"
            },

            //Biceps Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Standing Dumbbell Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Hammer Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Incline Dumbbell Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Zottman Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "EZ Bar Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Reverse Curl Straight Bar"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Concentration Curl",

            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Twisting Dumbbell Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Prone Dumbbell Spider Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Leant-Forward EZ Bar Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Standing Reverse Barbell Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Seated Alternating Dumbbell Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Standing Cable Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "biceps.png",
                Name = "Cable Flex Curl"
            },

            //Shoulders Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Barbell Overhead Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Standing Dumbbell Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Face Pull"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "High Pull"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Seated Dumbbell Clean"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Trap Raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Clean and Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Snatch-Grip High Pull"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Dumbbell Raise Complex"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Snatch-Grip Low Pull"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Dumbbell Bent-Over Lateral Raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Machine Shoulder Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Front Raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "Reverse Pec Deck Fly"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "shoulders.png",
                Name = "One-Arm Cable Lateral Raise"
            },

            //Abs Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Plank"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Mountain climber"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Reverse crunch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Grounded Russian twist"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Dead bug"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Leg raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Abs roll-out"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Bird-dog"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Dumbbell woodchop"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Medicine ball crunch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Flutter kicks"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "V-sit"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Bicycle Crunch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Tuck and crunch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Crunch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "abs.png",
                Name = "Hanging knee raise twist"
            },

            //Traps Exerscies
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Shoulder blade squeeze"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Shrug"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Upright row"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Pushup"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Face Pull"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Dumbbell Snatch"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Pullup Shrug"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Barbell Shrug"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Incline Dumbbell Shrug"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "traps.png",
                Name = "Barbell Behind-the-Back Shrug"
            },

            //Quads Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Bulgarian Split Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Barbell Front Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Goblet Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Barbell Box Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Diagonal Walking Lunges"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Hack Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Leg Press"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Sprints"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Weighted Jump Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Box Jump"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Seated Single-Leg Jump Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Walking Lunge"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Leg Extensions"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Barbell Back Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "quads.png",
                Name = "Deadlift"
            },

            //Hamstring Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Glute Bridge"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Hip Thrust"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Cable or Band Pull-through"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Dumbbell Romanian Deadlift"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Barbell Romanian Deadlift"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Deadlift"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Single-leg Romanian Deadlift"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Walking Lunges"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Rear-Foot Elevated Lunge"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Lying Leg Curl"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Back Extension"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "hamstrings.png",
                Name = "Glute-Ham Raise"
            },

            //Calves Exersices
            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Seated calf raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Farmer’s walk on toes"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Jump rope"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Standing Barbell Calf Raise"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Seated Calf Raise "
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Hill Runs"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Jumping Jack"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Seated Calf Raise Machine"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Agility Ladder"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "Bosu Ball Squat"
            },

            new ExerciseType
            {
                Id = Guid.NewGuid(),
                Icon = "calves.png",
                Name = "StairMaster"
            });
        }
    }
}
