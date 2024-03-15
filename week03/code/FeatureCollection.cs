public class FeatureCollection //ALL EARTHQUAKES
{
    // The "features" array in the JSON is represented as a list of Feature objects in C#.
    public List<Feature> Features { get; set; }
}

public class Feature //EACH EARTHQUAKE
{
    // Each feature has a "properties" object, which is represented by the EarthquakeProperties class in C#.
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties //EACH EARTHQUAKE DETAILS
{
    // The "place" attribute in the JSON is mapped to this Place property in C#.
    public string Place { get; set; }
    // The "mag" attribute for magnitude in the JSON is mapped to this Mag property in C#.
    public double Mag { get; set; }
}
