<Query Kind="Statements" />

var startingId = 1191;
var titles = new List<string>() {
"Two Worlds Epic Edition",
"Two Worlds II",
"Pirates of the Flying Fortress DLC",
"Septerra Core: Legacy of the Creator",
"Enclave",
"Gorky 17",
};
var date = "2014-06-27";
var price = "0.83";
var place = "Bundle Stars";
var note = "Part of the RPG Champions Bundle, which was $4.99 for 5 games and 1 DLC.";

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