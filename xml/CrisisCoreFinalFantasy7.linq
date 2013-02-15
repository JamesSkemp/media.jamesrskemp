<Query Kind="Statements" />

String xml = @"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\CrisisCoreFinalFantasy7.xml";
Boolean dumpCategories = false, dumpMissions = true, dumpXml = true;

XDocument doc = XDocument.Load(xml);

var categories = from c in doc.Descendants("categories").Elements("category")
				select new {
					Id = int.Parse(c.Attribute("id").Value),
					Name = c.Attribute("name").Value,
					Subcategories = from s in c.Descendants("subcategories").Elements("subcategory")
									select new {
										Id = int.Parse(s.Attribute("id").Value),
										Name = s.Attribute("name").Value
									}
				};
if (dumpCategories) {
	categories.Dump();
}

var missions = from m in doc.Descendants("mission")
				select new {
					Name = m.Element("name").Value,
					Category = int.Parse(m.Attribute("category").Value),
					Subcategory = int.Parse(m.Attribute("subcategory").Value),
					Number = int.Parse(m.Attribute("order").Value),
					Missable = (m.Attribute("missable") != null ? Boolean.Parse(m.Attribute("missable").Value) : false),
					/*Chests = (m.Element("chests") != null ? (from c in m.Descendants("chests")
							select new {
								Name = c.Element("chest").Value,
								Quantity = c.Attribute("quantity").Value
							}).ToString() : "")*/
				};
if (dumpMissions) {
	missions.Where(m => m.Name != "").Dump();
}

if (dumpXml) {
	doc.Dump();
}