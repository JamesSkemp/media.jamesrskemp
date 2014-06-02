<Query Kind="Statements" />

XDocument xml = XDocument.Load(@"C:\Users\James\Projects\GitHub\JamesRSkemp\JamesRSkemp.Media.Web\xml\video_games.xml");

var datum = from x in xml.Descendants("game")
			select x.Attribute("id").Value;

datum.Count().Dump();

datum.GroupBy(d => d).Where(d => d.Count() > 1).Dump();