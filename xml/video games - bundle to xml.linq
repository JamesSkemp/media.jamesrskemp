<Query Kind="Statements" />

var startingId = 990;
var titles = new List<string>() {
"In Search for Immortality",
"Legionwood: The Tale of Two Swords",
"Star Stealing Prince",
"Reconstruction, The",
"Homework Salesman",
"I Miss the Sunrise",
"Aetherion",
"Visions and Voices"
};
var date = "2014-05-31";
var price = "0.25";
var place = "Humble Bundle";
var note = "Part of RPG Maker weekly bundle. Paid $14 for RPG Makers (two versions), and a number of games. This was part of 4-game bundle.";

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
