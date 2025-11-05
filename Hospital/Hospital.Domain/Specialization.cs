namespace Hospital.Domain;

/// <summary>
/// Represents a medical specialization.
/// </summary>
public class Specialization
{
    /// <summary>
    /// Unique identifier for the specialization.
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    /// Name of the medical specialization.
    /// </summary>
    public required string Name { get; set; }
}