public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create base collection gather
    // Add Metadata, Bbox and Features Classes
    public string Type { get; set; }
    public Metadata Metadata { get; set; }
    public List<double> Bbox { get; set; }
    public List<Feature> Features { get; set; }
}

// Metadata for earthquakes of the day
public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
    public int Status { get; set; }
}

// Feature data set for earthquakes of the day
public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    public string Id { get; set; }
}

// Grab only necessary fields in the even properties section. 
//Magnitude and location

public class Properties
{
    public decimal? Mag { get; set; }
    public string Place { get; set; }
}