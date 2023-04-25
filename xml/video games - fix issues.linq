<Query Kind="Statements" />

var saveUpdates = false;

var currentDirectory = Path.GetDirectoryName(Util.CurrentQueryPath);
XDocument xml = XDocument.Load(Path.Combine(currentDirectory, "video_games.xml"), LoadOptions.PreserveWhitespace);

var gameElements = xml.Root.Elements("game");

var ids = gameElements.Select(e => e.Attribute("id"));
ids.GroupBy(i => i.Value).Where(g => g.Count() > 1).Dump();

var lastElement = 0;
foreach (var gameElement in gameElements)
{
	var gameId = int.Parse(gameElement.Attribute("id").Value);
	if (lastElement + 1 != gameId) {
		gameId.Dump();
		lastElement = gameId;
	}
	else
	{
		lastElement++;
	}
	if (gameId >= 3957) {
		gameElement.Attribute("id").SetValue(gameId - 1);
	}
	/*if (gameId >= 4000)
	{
		gameElement.Attribute("id").SetValue(gameId + 1);
	}*/
}

"===".Dump();

gameElements.Count().Dump();
ids.Count().Dump();

if (saveUpdates)
{
	xml.Save(Path.Combine(currentDirectory, "video_games-fixed.xml"));
}
