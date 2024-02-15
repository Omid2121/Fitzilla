namespace Fitzilla.BLL.DTOs;

public class CreateExerciseRecordDTO
{
    public int Rep { get; set; }

    public double Weight { get; set; }
    
    public Guid ExerciseId { get; set; }
}

public class ExerciseRecordDTO : CreateExerciseRecordDTO
{
    public Guid Id { get; set; }
    
    public double OneRepMax { get; set; }

    public string ExerciseTitle { get; set; }
}

public class UpdateExerciseRecordDTO
{
    public int Rep { get; set; }

    public double Weight { get; set; }
}
