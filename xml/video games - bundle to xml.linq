<Query Kind="Statements" />

var startingId = 1825;
var titles = new List<string>() {
"Dungeon Keeper Gold",
"Dungeon Keeper 2",
"Populous",
"Populous 2: Trials of the Olympian Gods",
"Populous: The Beginning",
"Syndicate Plus",
"Syndicate Wars",
"Magic Carpet Plus",
"Magic Carpet 2: The Netherworlds",
"Theme Park"
};

var date = "2015-06-19";
var price = "1.19";
var place = "GOG";
var note = "Normally $5.99, but on sale for 80% off. Part of the Best of Bullfrog collection.";

var xmlFormat = @"
	<game id=""{0}"" electronic=""true"">
		<title>{1}</title>
		<system>
			<console>PC</console>
			<version/>
		</system>
		<purchase>
			<date>{2}</date>
			<price>{3}</price>
			<place>{4}</place>
		</purchase>
		<own>yes</own>
		<notes>{5}</notes>
	</game>";

var finalXml = "";

foreach (var title in titles)
{
	finalXml += string.Format(xmlFormat, startingId, title, date, price, place, note);
	startingId++;
}

finalXml.Dump();