using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirQualityFunctions;


public class GeocodingData
{
    public string type { get; set; }
    public Feature[] features { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public Geometry1 geometry { get; set; }
    public float[] bbox { get; set; }
}

public class Properties
{
    public Address address { get; set; }
    public string type { get; set; }
    public string confidence { get; set; }
    public string[] matchCodes { get; set; }
    public Geocodepoint[] geocodePoints { get; set; }
}

public class Address
{
    public Countryregion countryRegion { get; set; }
    public Admindistrict[] adminDistricts { get; set; }
    public string formattedAddress { get; set; }
    public string locality { get; set; }
}

public class Countryregion
{
    public string name { get; set; }
}

public class Admindistrict
{
    public string shortName { get; set; }
}

public class Geocodepoint
{
    public Geometry geometry { get; set; }
    public string calculationMethod { get; set; }
    public string[] usageTypes { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public float[] coordinates { get; set; }
}

public class Geometry1
{
    public string type { get; set; }
    public float[] coordinates { get; set; }
}
