namespace Project05.Dictionary.Models;

/// <summary>
/// Represents a lake in the United States.
/// </summary>
public class Lake
{
    public string Name { get; set; } = string.Empty;
    public decimal Depth { get; set; }
    public decimal WidestPoint { get; set; }
    public decimal FarthestLength { get; set; }
    public decimal Elevation { get; set; }
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Validates the lake properties. Throws ArgumentException if invalid.
    /// </summary>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Lake name is required.");
        if (Depth <= 0)
            throw new ArgumentException("Depth must be positive.");
        if (WidestPoint <= 0)
            throw new ArgumentException("WidestPoint must be positive.");
        if (FarthestLength <= 0)
            throw new ArgumentException("FarthestLength must be positive.");
        // Elevation can be negative (e.g., below sea level)
        if (string.IsNullOrWhiteSpace(State))
            throw new ArgumentException("State is required.");
    }
}
