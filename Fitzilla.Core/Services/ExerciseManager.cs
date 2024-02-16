using Fitzilla.DAL.Models;
using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using X.PagedList;

namespace Fitzilla.BLL.Services;

public class ExerciseManager
{

    public ExerciseManager()
    {
    }

    public double CalculateOneRepMax(double weight, int rep)
    {
        return Math.Round(weight * (36 / (37 - rep)), 2);
    }

    public double CalculateTenRepMax(double weight, int rep)
    {
        return Math.Round(weight * (36 / (37 - rep)) * 0.75, 2);
    }

    public IOrderedQueryable<ExerciseTemplate> SortExerciseTemplatesByOptions(SortOption sortOption, IQueryable<ExerciseTemplate> exerciseTemplates)
    {
        return sortOption switch
        {
            SortOption.Alphabetical => exerciseTemplates.OrderBy(exerciseTemplate => exerciseTemplate.Title),
            SortOption.ReverseAlphabetical => exerciseTemplates.OrderByDescending(exerciseTemplate => exerciseTemplate.Title),
            SortOption.MostPopular => exerciseTemplates.OrderByDescending(exerciseTemplate => exerciseTemplate.Ratings!.Count > 0 ? CalculateRatingsAverage(exerciseTemplate) : 0),
            SortOption.MostRecent => exerciseTemplates.OrderByDescending(exerciseTemplate => exerciseTemplate.CreatedAt),
            SortOption.Oldest => exerciseTemplates.OrderBy(exerciseTemplate => exerciseTemplate.CreatedAt),
            _ => exerciseTemplates.OrderBy(exerciseTemplate => exerciseTemplate.Title)
        };
    }

    private static double CalculateRatingsAverage(ExerciseTemplate exerciseTemplate)
    {
        return exerciseTemplate.Ratings!.Average(rating => rating.Value);
    }

    public IPagedList<ExerciseTemplate> FilterExerciseTemplatesByQuery(ExerciseFilterQuery filterQuery, IPagedList<ExerciseTemplate> exerciseTemplates)
    {
        if (filterQuery.TargetMuscles.Count > 0)
        {
            exerciseTemplates = (IPagedList<ExerciseTemplate>)exerciseTemplates.Where(
                et => et.TargetMuscles.Any(tm => filterQuery.TargetMuscles.Contains(tm))).ToList();
        }

        if (filterQuery.Equipments.Count > 0)
        {
            exerciseTemplates = (IPagedList<ExerciseTemplate>)exerciseTemplates.Where(
                et => filterQuery.Equipments.Contains(et.Equipment)).ToList();
        }

        return exerciseTemplates;
    }
}