using System;

public class LiquidContainer : Container, IHazardNotifier
{
	public bool IsHazardous { get; set; }

	public LiquidContainer(double loadWeight, double height, double weight, double depth, double maxLoad, bool isHazardous) :
		base(loadWeight, height, weight, depth, maxLoad)
	{
		this.IsHazardous = isHazardous;
	}

	public void NotifyHazard(string message)
	{
		Console.WriteLine($"HAZARD! Serial Number  {message} ");
	}
}
