<Query Kind="Statements" />

XDocument xml = XDocument.Load(@"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\MyBooks.xml");

var datum = from x in xml.Descendants("book")
	where x.Element("sell") == null
	select new {
		Title = x.Element("title").Value,
		//X = x
	};
	
datum.OrderBy(g => g.Title).Dump(); // 769 - 757 to 739/721/707/690/687/674/661/586/543/545/531