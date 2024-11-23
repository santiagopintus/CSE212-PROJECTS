#nullable enable

public class FeatureCollection
{
    public string? Type { get; set; }
    public required Metadata Metadata { get; set; }
    public List<Feature> Features { get; set; } = new List<Feature>(); // Initialize list
}

public class Metadata
{
    public long Generated { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public int Status { get; set; }
    public string? Api { get; set; }
    public int Count { get; set; }
}

public class Feature
{
    public string? Type { get; set; }
    public Properties? Properties { get; set; } // Mark as nullable, in case it can be null
    public Geometry? Geometry { get; set; } // Mark as nullable
    public string? Id { get; set; }
}

public class Properties
{
    public float? Mag { get; set; }
    public string? Place { get; set; }
    public long? Time { get; set; }
    public long? Updated { get; set; }
    public object? Tz { get; set; }
    public string? Url { get; set; }
    public string? Detail { get; set; }
    public int? Felt { get; set; }
    public float? Cdi { get; set; }
    public float? Mmi { get; set; }
    public string? Alert { get; set; }
    public string? Status { get; set; }
    public int? Tsunami { get; set; }
    public int? Sig { get; set; }
    public string? Net { get; set; }
    public string? Code { get; set; }
    public string? Ids { get; set; }
    public string? Sources { get; set; }
    public string? Types { get; set; }
    public int? Nst { get; set; }
    public float? Dmin { get; set; }
    public float? Rms { get; set; }
    public float? Gap { get; set; }
    public string? MagType { get; set; }
    public string? Type { get; set; }
    public string? Title { get; set; }
}

public class Geometry
{
    public string? Type { get; set; }
    public List<float> Coordinates { get; set; } = new List<float>(); // Initialize list
}
