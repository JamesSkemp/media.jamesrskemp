<Query Kind="Statements" />

string xmlFile = @"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\KingdomHeartsBirthBySleep.xml";

XDocument document = XDocument.Load(xmlFile);

string characterName = "Ven"; // Terra Ven Aqua
string ingredientName = "";
string commandName = "Renewal Block"; // Wind Raid
string ability = "";//EXP Walker

var allMelds = (from x in document.Descendants("Meld")
			where x.Attribute("Command").Value != ""
			select new {
				Meld = x
			});

var filteredMelds = allMelds;

if (characterName != null && characterName != "") {
	filteredMelds = filteredMelds.Where(c => c.Meld.Element("Characters") == null || c.Meld.Element("Characters").Attribute(characterName) == null);
}
if (ingredientName != null && ingredientName != "") {
	filteredMelds = filteredMelds.Where(c => c.Meld.Elements("Ingredient").ElementAt(0).Value == ingredientName || c.Meld.Elements("Ingredient").ElementAt(1).Value == ingredientName);
}
if (commandName != null && commandName != "") {
	filteredMelds = filteredMelds.Where(c => c.Meld.Attribute("Command").Value == commandName);
}
if (ability != null && ability != "") {
	filteredMelds = filteredMelds.Where(
					c
					=>
					c.Meld.Descendants("Crystals").Elements("Crystal").Any(ch => ch.Attribute("Ability").Value.Contains(ability))
					);
}

Console.WriteLine("There are " + filteredMelds.Count() + " matching melds." + Environment.NewLine);

foreach (var element in filteredMelds.OrderBy(c => c.Meld.Attribute("Command").Value))
{
	bool rareMeld = false;
	if (element.Meld.Attribute("Rare") != null) {
		rareMeld = true;
	}

	Console.WriteLine(element.Meld.Attribute("Command").Value + (rareMeld ? "*" : "") + " (" + element.Meld.Attribute("Type").Value + ") = " + element.Meld.Elements("Ingredient").ElementAt(0).Value + " and " + element.Meld.Elements("Ingredient").ElementAt(1).Value + " [" + element.Meld.Attribute("Id").Value + "]");
	foreach (var element2 in element.Meld.Descendants("Crystals").Elements("Crystal"))
	{
		if (String.IsNullOrWhiteSpace(ability) || (element2.Attribute("Ability").Value.Contains(ability))) {
			Console.WriteLine("	" + element2.Attribute("Name").Value + " Crystal = " + element2.Attribute("Ability").Value);
		}
	}
}

//filteredMelds.Dump();