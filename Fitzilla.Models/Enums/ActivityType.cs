using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum ActivityType
{
    /// <summary>
    /// Weight Lifting, Bodybuilding, and Powerlifting
    /// </summary>
    [Display(Name = "Strength Training")] StrengthTraining,

    /// <summary>
    /// Running, Cycling, Swimming, High-Intensity Interval Training (HIIT)
    /// </summary>
    [Display(Name = "Cardiovascular Exercise")] CardiovascularExercise,

    /// <summary>
    /// Stretching, Yoga, Pilates
    /// </summary>
    [Display(Name = "Flexibility and Mobility")] FlexibilityAndMobility,

    /// <summary>
    /// CrossFit,  Functional Fitness, Circuit Training
    /// </summary>
    [Display(Name = "Functional Training")] FunctionalTraining,

    /// <summary>
    /// Long-Distance Running, Triathlon Training
    /// </summary>
    [Display(Name = "Endurance Training")] EnduranceTraining,

    /// <summary>
    /// Football, Basketball, Tennis, Martial Arts
    /// </summary>
    [Display(Name = "Sports Specific Training")] SportsSpecificTraining,

    /// <summary>
    /// Calisthenics, Gymnastics
    /// </summary>
    [Display(Name = "Bodyweight Training")] BodyweightTraining,

    /// <summary>
    /// Balance Exercises, Stability Ball Workouts
    /// </summary>
    [Display(Name = "Balance And Stability")] BalanceAndStability,

    /// <summary>
    /// Core Workouts, Abdominal Training
    /// </summary>
    [Display(Name = "Core Strength")] CoreStrength,

    /// <summary>
    /// Physical Therapy Exercises, Injury Prevention Routines
    /// </summary>
    [Display(Name = "Rehabilitation and Injury Prevention")] RehabilitationAndInjuryPrevention,

    /// <summary>
    /// Meditation, Mindful Movement
    /// </summary>
    [Display(Name = "Mind-Body Connection")] MindBodyConnection,

    /// <summary>
    /// Low-Impact Exercises, Senior Yoga
    /// </summary>
    [Display(Name = "Senior Fitness")] SeniorFitness,

    /// <summary>
    /// At-Home Cardio, Minimal Equipment Workouts
    /// </summary>
    [Display(Name = "Home Workouts")] HomeWorkouts,

    /// <summary>
    /// Trail Running, Outdoor Circuit Training
    /// </summary>
    [Display(Name = "Outdoor Training")] OutdoorTraining,

    /// <summary>
    /// Cardio for Weight Loss, High-Intensity Workouts
    /// </summary>
    [Display(Name = "Weight Loss Program")] WeightLossProgram,

    /// <summary>
    /// Meal Plans for Fitness, Nutritional Guidance
    /// </summary>
    [Display(Name = "Nutrition And Fitness")] NutritionAndFitness,

    /// <summary>
    /// Postpartum Workouts, Mom and Baby Exercise
    /// </summary>
    [Display(Name = "Postnatal Fitness")] PostnatalFitness,

    /// <summary>
    /// Desk Exercises, Office-Friendly Workouts
    /// </summary>
    [Display(Name = "Corporate Wellness")] CorporateWellness,

    /// <summary>
    /// Kids' Exercise, Teen Fitness
    /// </summary>
    [Display(Name = "Youth Fitness")] YouthFitness,

    /// <summary>
    /// Adaptive Fitness, Pregnancy Workouts
    /// </summary>
    [Display(Name = "Special Populations")] SpecialPopulations
}