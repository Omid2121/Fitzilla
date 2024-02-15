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
}
