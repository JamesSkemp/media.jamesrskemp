<Query Kind="Statements" />

var currentDirectory = Path.GetDirectoryName(Util.CurrentQueryPath);
XDocument xml = XDocument.Load(Path.Combine(currentDirectory, "video_games.xml"));

var datum = from x in xml.Descendants("game")
			select x.Attribute("id").Value;

datum.Count().Dump();

datum.GroupBy(d => d).Where(d => d.Count() > 1).Dump();

var companies = from x in xml.Descendants("game")
				 select x.Element("purchase").Element("place").Value;
				 
companies
	//.Distinct()
	.GroupBy(c => c)
	.OrderBy(c => c.Key)
	.Select(c => new { Company = c.Key, Games = c.Count() })
	.Dump();
