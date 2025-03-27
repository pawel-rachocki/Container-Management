using System;

public class Container
{

public double LoadWeight { get; set; } // kg
public double Height { get; set; }     // cm
public double Weight { get; set; }     // kg
public double Depth { get; set; }      // cm
public double MaxLoad { get; set; }    // kg
public string SerialNum { get; private set; } // ustawimy później w generowaniu numeru

    public Container(double loadWeight, double height, double weight, double depth, double maxLoad)
    {
    LoadWeight = loadWeight;
    Height = height;
    Weight = weight;
    Depth = depth;
    MaxLoad = maxLoad;

    // TODO: Serial number generation
    }
}
