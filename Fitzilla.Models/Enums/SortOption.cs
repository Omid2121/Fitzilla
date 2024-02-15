using System.ComponentModel.DataAnnotations;

namespace Fitzilla.Models.Enums;

public enum SortOption
{
    /// <summary>
    /// Most Popular sort option
    /// </summary>
    [Display(Name = "Most Popular")] MostPopular,

    /// <summary>
    /// Most Recent sort option
    /// </summary>
    [Display(Name = "Most Recent")] MostRecent,

    /// <summary>
    /// Oldest sort option
    /// </summary>
    [Display(Name = "Oldest")] Oldest,

    /// <summary>
    /// Alphabetical sort option
    /// </summary>
    [Display(Name = "Alphabetical")] Alphabetical,

    /// <summary>
    /// Reverse Alphabetical sort option
    /// </summary>
    [Display(Name = "Reverse Alphabetical")] ReverseAlphabetical,
}
