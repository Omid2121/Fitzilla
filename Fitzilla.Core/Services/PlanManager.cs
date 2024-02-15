using Fitzilla.Models.Data;
using Fitzilla.Models.Enums;
using X.PagedList;

namespace Fitzilla.BLL.Services;

public class PlanManager
{

    public IOrderedQueryable<Plan> SortPlansByOptions(SortOption sortOption, IQueryable<Plan> plans)
    {
        return sortOption switch
        {
            SortOption.Alphabetical => plans.OrderBy(plan => plan.Title),
            SortOption.ReverseAlphabetical => plans.OrderByDescending(plan => plan.Title),
            SortOption.MostRecent => plans.OrderByDescending(plan => plan.CreatedAt),
            SortOption.Oldest => plans.OrderBy(plan => plan.CreatedAt),
            _ => plans.OrderBy(plan => plan.Title)
        };
    }
}
