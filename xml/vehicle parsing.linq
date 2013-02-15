<Query Kind="Statements" />

XDocument xml = XDocument.Load(@"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\vehicle_gas.xml");

//xml.Dump();

var fillUps = from f in xml.Descendants("vehicle").Where(f => f.Attribute("id").Value == "2").Descendants("fillup")
	select new {
		Id = int.Parse(f.Attribute("id").Value),
		Date = DateTime.Parse(f.Element("date").Value).ToShortDateString(),
		Miles = new {
			Total = int.Parse(f.Element("milesCar").Value),
			Driven = Double.Parse(f.Element("milesDriven").Value),
			PerGallon = Decimal.Parse((Double.Parse(f.Element("milesDriven").Value) / Double.Parse(f.Element("gallons").Value)).ToString())
		},
		Gallons = Double.Parse(f.Element("gallons").Value),
		Cost = new {
			Gallon = Decimal.Parse(f.Element("costGallon").Value),
			Total = Decimal.Parse(f.Element("costTotal").Value)
		},
		Notes = f.Element("notes").Value,
		Calculated = new {
			CostPerMile = Decimal.Parse((Double.Parse(f.Element("costTotal").Value) / Double.Parse(f.Element("milesDriven").Value)).ToString())
			
			//var totalCost = fillUps.Select(f => f.Cost.Total).Sum();
			//var totalMilesDriven = fillUps.Select(f => f.Miles.Driven).Sum();
			//("Cost per mile = " + (double)totalCost / totalMilesDriven).Dump();
		}
	};
	
var averageMilesPerGallon = fillUps.Select(f => f.Miles.PerGallon).Average();
var maximumMilesPerGallon = fillUps.Select(f => f.Miles.PerGallon).Max();
var minimumMilesPerGallon = fillUps.Select(f => f.Miles.PerGallon).Min();
var totalGallons = fillUps.Select(f => f.Gallons).Sum();
var totalCost = fillUps.Select(f => f.Cost.Total).Sum();
var totalMilesDriven = fillUps.Select(f => f.Miles.Driven).Sum();

("Average/maximum/minimum miles per gallon = " + averageMilesPerGallon + " / " + maximumMilesPerGallon + " / " + minimumMilesPerGallon).Dump();
("Total gallons = " + totalGallons).Dump();
("Total miles driven = " + totalMilesDriven).Dump();
("Total cost = " + totalCost).Dump();

("Miles driven per gallon = " + totalMilesDriven / totalGallons).Dump();
("Cost per mile = " + (double)totalCost / totalMilesDriven).Dump();
("Cost per gallon = " + (double)totalCost / totalGallons).Dump();

fillUps.Dump();