﻿using System;

public class RefrigeratedContainer : Container
{
    private static readonly Dictionary<string, double> RequiredTemperatures = new()
{
    { "Banany", 13.3 },
    { "Czekolada", 18 },
    { "Ryby", 2 },
    { "Mięso", -15 },
    { "Lody", -18 },
    { "Mrożona pizza", -30 },
    { "Ser", 7.2 },
    { "Kiełbasa", 5 },
    { "Masło", 20.5 },
    { "Jajka", 19 }
};

    private string ProductType { get; set; }
	private double Temperature { get; set; }

	public RefrigeratedContainer(double loadWeight, double height, double weight, double depth, double maxLoad, string ProductType, double Temperature):
		base(loadWeight, height, weight, depth, maxLoad)
	{
		this.ProductType = ProductType;
		this.Temperature = Temperature;
	}
    public void Load(double weight, string productType)
    {
        if (LoadWeight > 0 && ProductType != productType)
        {
            throw new InvalidOperationException("Cannot mix different products in one container.");
        }

        if (!RequiredTemperatures.ContainsKey(productType))
        {
            throw new ArgumentException("Unknown product type.");
        }

        double requiredTemp = RequiredTemperatures[productType];
        if (Temperature < requiredTemp)
        {
            throw new InvalidOperationException($"Temperature too low for {productType}. Minimum required: {requiredTemp}°C");
        }

        base.Load(weight);
        ProductType = productType;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"ProductType: {ProductType}");
        Console.WriteLine($"Temperature: {Temperature}");
    }

}
