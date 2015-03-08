<Query Kind="Statements" />

XDocument xml = XDocument.Load(@"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\video_games.xml");

var datum = from x in xml.Descendants("game")
	//where x.Element("own").Value == "yes" && x.Attribute("addOn") == null
		//&& x.Element("system").Element("console").Value == "PlayStation"
		//&& x.Attribute("electronic") == null
	where x.Element("system").Element("console").Value == "PlayStation"
		&& x.Element("purchase").Element("place").Value.StartsWith("PlayStation")
		&& x.Element("purchase").Element("price").Value == "0.00"
		&& x.Element("notes").Value.Contains("Plus")
		&& (x.Element("purchase").Element("date").Value.StartsWith("2014") || x.Element("purchase").Element("date").Value.StartsWith("2015"))
	select new {
		Id = x.Attribute("id").Value,
		Title = x.Element("title").Value,
		System = string.Concat(x.Element("system").Element("console").Value, " ", x.Element("system").Element("version").Value).Trim(),
		Notes = x.Element("notes").Value,
		Own = x.Element("own").Value,
		Date = x.Element("purchase").Element("date").Value,
		Price = x.Element("purchase").Element("price").Value,
		Place = x.Element("purchase").Element("place").Value,
		SellDate = x.Element("sell") == null || x.Element("sell").Element("date") == null ? "" : x.Element("sell").Element("date").Value,
		SellPrice = x.Element("sell") == null || x.Element("sell").Element("price") == null ? "" : x.Element("sell").Element("price").Value,
		SellPlace = x.Element("sell") == null || x.Element("sell").Element("place") == null ? "" : x.Element("sell").Element("place").Value,
		AddOn = x.Attribute("addOn") != null ? x.Attribute("addOn").Value : "",
		Electronic = x.Attribute("electronic") != null ? x.Attribute("electronic").Value : "",
		Beat = x.Attribute("beat") != null ? Boolean.Parse(x.Attribute("beat").Value) : false,
		//X = x
	};

datum
	//.Select (d => new { d.Title, d.System, d.Notes, d.Date })
	.Select (d => new { d.Title })
	.Distinct()
	.OrderBy (d => d.Title)
	.Dump();
