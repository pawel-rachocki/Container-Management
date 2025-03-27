using System;

public class RefrigeratedContainer : Container
{
	private string ProductType { get; set; }
	private double Temperature { get; set; }

	public RefrigeratedContainer(double loadWeight, double height, double weight, double depth, double maxLoad, string ProductType, double Temperature):
		base(loadWeight, height, weight, depth, maxLoad)
	{
		this.ProductType = ProductType;
		this.Temperature = Temperature;
	}
}
