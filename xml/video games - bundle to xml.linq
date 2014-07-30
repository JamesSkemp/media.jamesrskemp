<Query Kind="Statements" />

var startingId = 1221;
var titles = new List<string>() {
"Thief Gold",
"Hitman: Codename 47",
"Hitman 2: Silent Assassin",
"Mini Ninjas",
"Daikatana",
"Anachronox",
"Deus Ex: The Fall",
"Battlestations: Midway",
"Hitman: Absolution",
"Deus Ex: Invisible War",
"Deus Ex: Human Revolution Director's Cut",
"Just Cause 2",
"Deus Ex: Game of the Year Edition",
"Lara Croft and the Guardian of Light",
"Kane &amp; Lynch 2: Dog Days",
"Hitman: Blood Money",
"Just Cause",
"Hitman: Contracts",
"Last Remnant, The"
};

var date = "2014-07-22";
var price = "0.79";
var place = "Humble Bundle";
var note = "Part of the Square Enix Bundle, which was $15 for 19 games.";

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