using System;

public class GasContainer : Container, IHazardNotifier
{
	public double Pressure { get; set; }

	public GasContainer(double loadWeight, double height, double weight, double depth, double maxLoad, double pressure):
		base(loadWeight, height, weight, depth, maxLoad)
	{
		this.Pressure = pressure;
	}

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD! Serial Number  {message} ");
    }
}
