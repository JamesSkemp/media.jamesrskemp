<Query Kind="Statements" />

XDocument xml = XDocument.Load(Path.GetDirectoryName(Util.CurrentQueryPath) + @"\video_games.xml");

var datum = from x in xml.Descendants("game")
	//where x.Element("own").Value == "yes" && x.Attribute("addOn") == null
		//&& x.Element("system").Element("console").Value == "PlayStation"
		//&& x.Attribute("electronic") == null
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

//var consoles = datum.GroupBy (g => g.System).Select (g => new { g.Key, Count = g.Count() }).OrderBy (g => g.Key);
//consoles.Dump();

var output = datum
	.Where(g => g.Own == "yes" && g.Electronic != "true")
	.OrderBy (g => g.System).ThenBy (g => g.Title).ThenBy (g => g.Date)
	.Select (g => new { g.Title, g.System, g.Date, g.Price, g.Place })
	;

output
	//.Where (g => g.System.Contains("PlayStation 2 (")) //PlayStation Portable
	.Where (g => g.System == "PlayStation 3")
	.Dump();

var consoles = output.GroupBy (g => g.System).Select (g => new { g.Key, Count = g.Count() }).OrderBy (g => g.Key);

"Games that aren't electronic:".Dump();
consoles.Dump();