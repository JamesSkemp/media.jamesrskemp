<Query Kind="Statements" />

var startingId = 1275;
var titles = new List<string>() {
"Unholy Heights0.33Historical Lowest Price: $1.59",
"One Way Heroics0.33Historical Lowest Price: $0.87",
"GIGANTIC ARMY0.34Historical Lowest Price: $2.99",
"Ys Origin1.67Historical Lowest Price: $4.99",
"Mitsurugi Kamui Hikae1.67Historical Lowest Price: $2.49",
"PixelJunk Shooter1.66Historical Lowest Price: $1.25",
"Astebreed4.00Historical Lowest Price: $9.994.00"
};

var date = "2014-08-07";
var price = "";
var place = "Humble Bundle";
var note = "Part of the Humble Weekly Bundle: Japan Edtion! - $10 for 7 games.";

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